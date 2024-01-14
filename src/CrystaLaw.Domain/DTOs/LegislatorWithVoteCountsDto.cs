namespace CrystaLaw.Domain.DTOs
{
    public record LegislatorWithVoteCountsDto(int Id, string Name, int NumSupportedBills, int NumOpposedBills);
}