using AutoFixture.Xunit2;
using CrystaLaw.Domain.DTOs;
using CrystaLaw.Domain.Interfaces.Repositories;
using CrystaLaw.Domain.Interfaces.Services;
using CrystaLaw.Domain.Services;
using Moq;
using Moq.AutoMock;

namespace CrystaLaw.Domain.Test
{
    public class LegislatorServiceTests
    {
        private readonly AutoMocker _autoMocker;

        public LegislatorServiceTests() =>
            _autoMocker = new AutoMocker();

        [Theory, AutoData]
        public async Task GetLegislatorWithVoteCounts_WhenRequestedWithDataPresent_ShouldReturnFilledLegislatorWithVoteCountsDtoCollection(
            IEnumerable<LegislatorWithVoteCountsDto> expected)
        {
            //Act
            var repositoryMock = _autoMocker.GetMock<ILegislatorsRepository>()
                .Setup(e => e.GetLegislatorsWithVoteCountsAsync())
                .ReturnsAsync(expected);

            var service = CreateService();

            //Arrange
            var result = await service.GetLegislatorsWithVoteCountsAsync();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equivalent(expected, result);
        }

        private ILegislatorsService CreateService()
            => _autoMocker.CreateInstance<LegislatorsService>();
    }
}