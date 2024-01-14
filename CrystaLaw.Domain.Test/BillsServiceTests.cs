namespace CrystaLaw.Domain.Test
{
    public class BillsServiceTests
    {
        public BillsServiceTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void BillsVoteResults_WhenRequested_ShouldReturnDataSet()
        {
            //Act
            var service = CreateService();

            //Arrange

            //Assert
        }

        private object CreateService() => throw new NotImplementedException();
    }
}