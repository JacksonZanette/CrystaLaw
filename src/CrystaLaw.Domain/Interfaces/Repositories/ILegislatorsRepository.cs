using CrystaLaw.Domain.DTOs;

namespace CrystaLaw.Domain.Interfaces.Repositories
{
    public interface ILegislatorsRepository
    {
        Task<IEnumerable<LegislatorWithVoteCountsDto>> GetLegislatorsWithVoteCountsAsync(CancellationToken cancellationToken);
    }
}