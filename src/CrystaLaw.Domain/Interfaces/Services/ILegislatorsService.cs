using CrystaLaw.Domain.DTOs;

namespace CrystaLaw.Domain.Interfaces.Services
{
    public interface ILegislatorsService
    {
        Task<IEnumerable<LegislatorWithVoteCountsDto>> GetLegislatorsWithVoteCountsAsync();
    }
}