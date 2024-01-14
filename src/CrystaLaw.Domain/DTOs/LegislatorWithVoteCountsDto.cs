namespace CrystaLaw.Domain.DTOs
{
    public class LegislatorWithVoteCountsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupportedBillsCount { get; set; }
        public int OpposedBillsCount { get; set; }
    }
}