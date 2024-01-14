using AutoFixture.Xunit2;
using CrystaLaw.Domain.DTOs;
using CrystaLaw.Domain.Interfaces.Repositories;
using CrystaLaw.Domain.Interfaces.Services;
using CrystaLaw.Domain.Services;
using Moq;
using Moq.AutoMock;

namespace CrystaLaw.Domain.Test
{
    public class BillsServiceTests
    {
        private readonly AutoMocker _autoMocker;

        public BillsServiceTests() =>
            _autoMocker = new AutoMocker();

        [Theory, AutoData]
        public async Task GetBillsWithVoteResultCounts_WhenRequestedWithDataPresent_ShouldReturnFilled(
            IEnumerable<BillWithVoteCountsDto> expected)
        {
            //Arrange
            var cancellationToken = new CancellationToken();
            var repositoryMock = _autoMocker.GetMock<IBillsRepository>()
                .Setup(e => e.GetBillsWithVouteCountsAsync(cancellationToken))
                .ReturnsAsync(expected);

            var service = CreateService();

            //Act
            var result = await service.GetBillsWithVouteCountsAsync(cancellationToken);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equivalent(expected, result);
        }

        private IBillsService CreateService()
            => _autoMocker.CreateInstance<BillsService>();
    }
}