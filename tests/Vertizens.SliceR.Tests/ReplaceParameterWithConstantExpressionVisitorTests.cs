using Vertizens.SliceR.Operations;

namespace Vertizens.SliceR.Tests;

public class ReplaceParameterWithConstantExpressionVisitorTests
{
    private class TestEntity
    {
        public int Id { get; set; }
    }

    [Fact]
    public void ReplaceParameterFilter()
    {
        var entities = new List<TestEntity> { new() { Id = 14 }, new() { Id = 15 }, new() { Id = 16 } };
        var predicateExpression = ReplaceParameterWithConstantExpressionVisitor.ReplaceParameter<TestEntity, int>((e, id) => e.Id == id, 15);

        var predicate = predicateExpression.Compile();

        var filteredEntities = entities.Where(predicate).ToList();

        Assert.NotNull(filteredEntities);
        Assert.Single(filteredEntities);
        Assert.Equal(15, filteredEntities.First().Id);
    }
}