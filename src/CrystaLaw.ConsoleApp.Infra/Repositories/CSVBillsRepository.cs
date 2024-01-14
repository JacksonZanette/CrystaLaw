using CrystaLaw.ConsoleApp.Infra.Helpers;
using CrystaLaw.Domain.DTOs;
using CrystaLaw.Domain.Entities;
using CrystaLaw.Domain.Interfaces.Repositories;

namespace CrystaLaw.ConsoleApp.Infra.Repositories
{
    public class CSVBillsRepository : IBillsRepository
    {
        public async Task<IEnumerable<BillWithVoteCountsDto>> GetBillsWithVouteCountsAsync(CancellationToken cancellationToken)
        {
            var bills = CSVParser.GetRecords<Bill>($"Data{Path.DirectorySeparatorChar}bills.csv");
            if (!bills.Any())
                return Enumerable.Empty<BillWithVoteCountsDto>();

            var votes = CSVParser.GetRecords<Vote>($"Data{Path.DirectorySeparatorChar}votes.csv")
                .Where(vote => bills.Select(e => e.Id).Contains(vote.BillId));

            if (!votes.Any())
                return Enumerable.Empty<BillWithVoteCountsDto>();

            var voteResults = CSVParser.GetRecords<VoteResult>($"Data{Path.DirectorySeparatorChar}vote_results.csv")
                .Where(voteResult => votes.Select(billVotes => billVotes.Id).Contains(voteResult.VoteId));

            var legislators = CSVParser.GetRecords<Legislator>($"Data{Path.DirectorySeparatorChar}legislators.csv")
                .Where(legislator => bills.Select(bill => bill.SponsorId).Contains(legislator.Id));

            return await Task.FromResult(bills.Select(bill => new BillWithVoteCountsDto
            (
                Id: bill.Id,
                Title: bill.Title,
                SupporterCount: voteResults.Count(voteResult => voteResult.VoteType == VoteType.Yes),
                OpposerCount: voteResults.Count(voteResult => voteResult.VoteType == VoteType.No),
                PrimarySponsor: legislators.FirstOrDefault(legislator => legislator.Id == bill.SponsorId)?.Name ?? "Unknown"
            )));
        }
    }
}