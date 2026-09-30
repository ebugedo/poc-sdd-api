using Poc.SDD.Domain.Sectors;

namespace Poc.SDD.Domain.Shared;

public interface ISectorRepository
{
    Task<Sector?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Sector>> ListAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Sector sector, CancellationToken cancellationToken = default);
    Task UpdateAsync(Sector sector, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}