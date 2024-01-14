namespace CrystaLaw.Domain.Entities
{
    public enum VoteType
    {
        Yes = 1,
        No = 2
    }

    public class VoteResult
    {
        public int Id { get; set; }
        public int LegislatorId { get; set; }
        public int VoteId { get; set; }
        public VoteType VoteType { get; set; }
    }
}