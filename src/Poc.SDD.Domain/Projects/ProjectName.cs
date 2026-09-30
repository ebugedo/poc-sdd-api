namespace Poc.SDD.Domain.Projects;

public class ProjectName : ValueObject
{
    public string Value { get; }

    public ProjectName(string name)
    {
        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}