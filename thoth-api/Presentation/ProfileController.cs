using Microsoft.AspNetCore.Mvc;
using thoth_api.Application;
using thoth_api.Domain;
using thoth_api.DTO;
using thoth_api.DTOs;

namespace thoth_api.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController(ProfileService service) : ControllerBase
    {
        private readonly ProfileService _profileService = service;

        [HttpGet]
        public async Task<IActionResult> Get() => 
            Ok(await _profileService.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id) => 
            Ok(await _profileService.FindById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfileDTO dto) => 
            Ok(await _profileService.Create(dto));

        [HttpDelete("{profileId}")]
        public async Task<IActionResult> Delete(Guid profileId) => 
            Ok(await _profileService.Delete(profileId));

        [HttpPost("profile/add-skill")]
        public async Task<IActionResult> AddSkill([FromBody] SkillDTO dto) => 
            Ok(await _profileService.AddSkill(dto));

        [HttpDelete("profile/remove-skill/{profileId}/{skillId}")]
        public async Task<IActionResult> RemoveSkill(Guid profileId, Guid skillId) => 
            Ok(await _profileService.RemoveSkill(profileId, skillId));

        [HttpPost("profile/add-assessment")]
        public async Task<IActionResult> AddAssessement([FromBody] AssessementDTO dto) => 
            Ok(await _profileService.AddAssessement(dto));

        [HttpDelete("profile/remove-assessement/{profileId}/{assessementId}")]
        public async Task<IActionResult> RemoveAssessement(Guid profileId, Guid assessementId) =>
           Ok(await _profileService.RemoveAssessement(profileId, assessementId));

        [HttpPost("profile/add-metric/{profileId}/{assessementId}")]
        public async Task<IActionResult> AddMetricToAssessement(Guid profileId, Guid assessementId, [FromBody] MetricDTO dto) =>
            Ok(await _profileService.AddMetricToAssessement(profileId, assessementId, dto));

        [HttpDelete("profile/remove-metric/{profileId}/{assessementId}/{metricId}")]
        public async Task<IActionResult> RemoveMetricFromAssessement(Guid profileId, Guid assessementId, Guid metricId) =>
           Ok(await _profileService.RemoveMetricFromAssessement(profileId, assessementId, metricId));
    }
}
