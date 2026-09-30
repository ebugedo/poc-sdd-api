namespace Poc.SDD.Domain.Projects;

public class ProjectDescription : ValueObject
{
    public string Value { get; }

    public ProjectDescription(string description)
    {
        Value = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}