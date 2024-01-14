using CrystaLaw.ConsoleApp.Infra.Helpers;
using CrystaLaw.Domain.DTOs;
using CrystaLaw.Domain.Entities;
using CrystaLaw.Domain.Interfaces.Repositories;

namespace CrystaLaw.ConsoleApp.Infra.Repositories
{
    public class CSVLegislatorsRepository : ILegislatorsRepository
    {
        public async Task<IEnumerable<LegislatorWithVoteCountsDto>> GetLegislatorsWithVoteCountsAsync(CancellationToken cancellationToken)
        {
            var legislators = CSVParser.GetRecords<Legislator>($"Data{Path.DirectorySeparatorChar}legislators.csv");

            if (!legislators.Any())
                return Enumerable.Empty<LegislatorWithVoteCountsDto>();

            var voteResults = CSVParser.GetRecords<VoteResult>($"Data{Path.DirectorySeparatorChar}vote_results.csv")
                .Where(voteResult => legislators.Select(legislator => legislator.Id).Contains(voteResult.LegislatorId));

            return await Task.FromResult(legislators.Select(legislator => new LegislatorWithVoteCountsDto
            (
                Id: legislator.Id,
                Name: legislator.Name,
                NumSupportedBills: voteResults.Count(voteResult => voteResult.VoteType == VoteType.Yes &&
                    voteResult.LegislatorId == legislator.Id),
                NumOpposedBills: voteResults.Count(voteResult => voteResult.VoteType == VoteType.No &&
                    voteResult.LegislatorId == legislator.Id)
            )));
        }
    }
}