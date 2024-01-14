using CrystaLaw.ConsoleApp.Infra.Helpers;
using CrystaLaw.ConsoleApp.Infra.Repositories;
using CrystaLaw.Domain.Interfaces.Repositories;
using CrystaLaw.Domain.Interfaces.Services;
using CrystaLaw.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CrystaLaw.ConsoleApp
{
    internal class Program
    {
        private static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ILegislatorsService, LegislatorsService>()
                .AddScoped<ILegislatorsRepository, CSVLegislatorsRepository>()
                .AddScoped<IBillsService, BillsService>()
                .AddScoped<IBillsRepository, CSVBillsRepository>()
                .BuildServiceProvider();

            var legislatorsService = serviceProvider.GetRequiredService<ILegislatorsService>();
            var legislatorsVotesCountResult = await legislatorsService.GetLegislatorsWithVoteCountsAsync(CancellationToken.None);

            CSVParser.WriteRecords($"Data{Path.DirectorySeparatorChar}legislators-support-oppose-count.csv", legislatorsVotesCountResult);

            var billsService = serviceProvider.GetRequiredService<IBillsService>();
            var billsVotesCountResult = await billsService.GetBillsWithVouteCountsAsync(CancellationToken.None);

            CSVParser.WriteRecords($"Data{Path.DirectorySeparatorChar}bills-supported-opposed-count.csv", billsVotesCountResult);
        }
    }
}