namespace Poc.SDD.Domain.Sectors;

public class SectorId : AggregateRootId
{
    public SectorId(Guid value) : base(value) { }

    public static SectorId CreateUnique() => new(Guid.NewGuid());
}