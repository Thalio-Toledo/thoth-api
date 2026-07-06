using thoth_api.Enums;

namespace thoth_api.DTOs
{
    public record SkillDTO(Guid ProfileId, string Name, Level Level);
}
