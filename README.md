# SliceR
.NET Vertical Slice inspired approach of turning code into pipelines

## Getting Started

At its heart SliceR is nothing more than a pattern to follow of using the IHandler interface for all flow of code execution.  Its target audience is to create a Minimal API but its works with anything that uses DI.

    services.AddSliceRHandlers();


This call adds any defined classes you create in the calling assembly that implement `IHandler<Request,Result>` or `IHandler<Request>`.  There are other overloads to be more specific but this is the most likely scenario.

`IHandler<Request,Result>` represents a method call with request/result types you create. Subsequently a void method is modeled as `IHandler<Request>`.  What do we do with methods that don't take in any parameters?  Well because we will be looking in DI for services that implement an interface, what we are looking for has to differentiate itself from other calls that also don't take any input.  So in the vain of CQRS every request needs a type that is combined with any result type to make the IHandler interface unique per 'method call'.

The good thing is the request/result have no requirements on each other.  So its very open to what you can do but this also means you have to be specific and explicit.

## Example Handler


    internal class Example1Handler : IHandler<Example1Request,Example1Result>
    {
        pubilc Task<Example1Result> Handle(Example1Request request, CancellationToken cancellationToken = default)
        {
            //do things and return an Example1Result
        }
    }

Now use this implementation

    internal class Example1OtherHandler(
        IHandler<Example1Request,Example1Result> example1Handler
    ) : IHandler<Example1OtherRequest,Example1OtherResult>
    {
        pubilc async Task<Example1OtherResult> Handle(Example1OtherRequest request, CancellationToken cancellationToken = default)
        {
            var example1Result = await example1Handler.Handle(new Example1Request(), cancellationToken);

            //do things and return Example1OtherResult
        }
    }

Now imagine if you created a handler that needed 10 other handlers, the constructor gets busy but that lets you know you are possibly doing too many things in this one handler anyway and it might be time to break it up.  

So this can lead to constructor bloat because each traditional method is now modeled as its own interface but its clear what a handler is doing and encourages breaking up code into smaller files.  Implementation is as it always is, up to you.

Good news is that you don't create interfaces any more and no longer write any code to register anygthing in DI as its found by the one registration method.  You spend your time in smaller code files either creating domain classes or Handlers.  

## ValidatedHandler

So now we add on to Handlers that always want to validate the request.  This is definitely more suited for APIs.  The key is that its a shortcut for including the Result pattern.

    public interface IValidatedHandler<TRequest, TResult> : IHandler<TRequest, ValidatedResult<TResult>>

    public interface IValidatedHandler<TRequest> : IHandler<TRequest, ValidatedResult>

So makes sense these are what endpoints would call, whether something is being returned we want to possibly authorize or validate the request and have a result that helps us determine what to return in an API.

    public class ValidatedResult
    {
        public virtual bool IsSuccessful { get { return !IsNotAuthorized && !IsNotFound && Messages.Count == 0; } }
        public bool IsNotAuthorized { get; set; }
        public bool IsNotFound { get; set; }
        public Dictionary<string, IEnumerable<string>> Messages { get; set; } = [];
    }

It has high level concepts of authorization, special case for not found, and validation messages.
Here is how it holds a return domain:

    public class ValidatedResult<TResult> : ValidatedResult
    {
        ... more code
        public TResult? Result { get; set; }
        ... more code
    }

## Pipeline

So where does this pipeline notion come into play? Well inspired by API middleware, we want to be able to add a handler between handlers that call each other in a chain or 'pipeline'.  So how does this work?  

####  ServiceProxy

Now that all the methods are turned into basically the same interface, we can now get clever with DI.  ServiceProxy is another nuget library and repository in this same organization.  Look to it for a brief overview first.

A good example of something handled by middleware, regardless of an implementation for an API endpoint, is Authentication.  So what other cross cutting concerns could we do?  Validation of a request model would be nice to handle separately and without cluttering up the handler for a request.  So ServiceProxy gives us the capability to create a generic implementation of `IHandler<Request,Result>` that can proxy the 'real' implementation or 'next' downstream handler.  If we extend this idea we chain any number of generic handlers to handle cross cutting concerns just like API middleware.

#### Example Pipeline

Now that you implemented handlers and have an idea what can be done with ServiceProxy, let's see it.

Here is a generic class that looks to use a `IModelValidator` to validate the request before calling the 'next' handler.

    internal class DefaultValidatorProxyValidatedHandler<TRequest, TResult>(
        IValidatedHandler<TRequest, TResult> _nextHandler,
        IModelValidator _modelValidator
        ) : IValidatedHandler<TRequest, TResult>
    {
        public async Task<ValidatedResult<TResult>> Handle(TRequest request, CancellationToken cancellationToken = default)
        {
            var modelValidatedResult = await _modelValidator.Validate(request);
            var validatedResult = new ValidatedResult<TResult>(modelValidatedResult);
            if (modelValidatedResult.IsSuccessful)
            {
                validatedResult = await _nextHandler.Handle(request, cancellationToken);
            }

            return validatedResult;
        }
    }

registered with 

    services.AddServiceProxy(typeof(DefaultValidatorProxyValidatedHandler<,>));

the above line is internal so use this if needed

    services.AddSliceRValidatorProxy();

Any `IValidatedHandler<TRequest, TResult>` now has this class as part of its `pipeline` for the request.  Think of it as wrapping already registered services and the pipeline is built up as registering our pipeline from the last handler first and working our way up to registering the first handler last.  So in short register in reverse order of execution.

## Operations

These are default patterns for working with entities and will be more clearly used in extensions to SliceR.  Helps with reducing boilerplate code for Creating, Reading, Updating, and Deleting entities if those patterns match your requirements.

***

Look to SliceR.Samples repository for how it all works together.