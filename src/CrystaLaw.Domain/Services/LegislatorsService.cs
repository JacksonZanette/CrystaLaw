using CrystaLaw.Domain.DTOs;
using CrystaLaw.Domain.Interfaces.Repositories;
using CrystaLaw.Domain.Interfaces.Services;

namespace CrystaLaw.Domain.Services
{
    public class LegislatorsService : ILegislatorsService
    {
        private readonly ILegislatorsRepository _legislatorsRepository;

        public LegislatorsService(ILegislatorsRepository legislatorsRepository)
            => _legislatorsRepository = legislatorsRepository;

        public Task<IEnumerable<LegislatorWithVoteCountsDto>> GetLegislatorsWithVoteCountsAsync()
            => _legislatorsRepository.GetLegislatorsWithVoteCountsAsync();
    }
}