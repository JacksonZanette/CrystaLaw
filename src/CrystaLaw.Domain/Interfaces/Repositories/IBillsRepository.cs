using CrystaLaw.Domain.DTOs;

namespace CrystaLaw.Domain.Interfaces.Repositories
{
    public interface IBillsRepository
    {
        Task<IEnumerable<BillWithVoteCountsDto>> GetBillsWithVouteCountsAsync(CancellationToken cancellationToken);
    }
}