namespace CrystaLaw.Domain.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SponsorId { get; set; }
    }
}