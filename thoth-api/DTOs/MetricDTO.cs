using thoth_api.Enums;

namespace thoth_api.DTOs
{
    public record MetricDTO(
        string Name,
        string? Description,
        MetricType Type,
        decimal Weight,
        AssessmentSource Source,
        Periodicity Periodicity,
        string? Rule);
}
