using CrystaLaw.Domain.DTOs;
using CrystaLaw.Domain.Interfaces.Repositories;
using CrystaLaw.Domain.Interfaces.Services;

namespace CrystaLaw.Domain.Services
{
    public class BillsService : IBillsService
    {
        private readonly IBillsRepository _billsRepository;

        public BillsService(IBillsRepository billsRepository)
        {
            _billsRepository = billsRepository;
        }

        public async Task<IEnumerable<BillWithVoteCountsDto>> GetBillsWithVouteCountsAsync(CancellationToken cancellationToken)
            => await _billsRepository.GetBillsWithVouteCountsAsync(cancellationToken);
    }
}