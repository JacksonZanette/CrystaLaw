using CrystaLaw.Domain.DTOs;

namespace CrystaLaw.Domain.Interfaces.Services
{
    public interface IBillsService
    {
        Task<IEnumerable<BillWithVoteCountsDto>> GetBillsWithVouteCountsAsync(CancellationToken cancellationToken);
    }
}