namespace CrystaLaw.Domain.DTOs
{
    public record BillWithVoteCountsDto(int Id, string Title, int SupporterCount, int OpposerCount, string PrimarySponsor)
    {
    }
}