namespace thoth_api.DTOs
{
    public record AssessementDTO(Guid ProfileId, string Title, Guid AssessorUserId, DateTime StartDate, DateTime EndDate);
}
