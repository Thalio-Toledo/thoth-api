using Microsoft.EntityFrameworkCore;
using thoth_api.Domain;
using thoth_api.DTO;
using thoth_api.DTOs;
using thoth_api.Infrastructure;

namespace thoth_api.Application
{
    public class ProfileService(Context context)
    {
        private readonly Context _context = context;

        public async Task<IEnumerable<Profile>> Get() => await _context.Profiles.ToListAsync();
        
        public async Task<Profile> FindById(Guid profileId) => await _context.Profiles.FirstOrDefaultAsync(p => p.Id == profileId);
        public async Task<bool> Create(ProfileDTO dto)
        {
            var profile = new Profile(dto.Name);

            _context.Profiles.Add(profile);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid profileId)
        {
            var profile = await _context.Profiles
                .Include(p => p.Skills)
                .FirstAsync(p => p.Id == profileId);

            if (profile is not null)
            {
                profile.Active = false;
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> AddSkill(SkillDTO dto)
        {
           var profile = await _context.Profiles
                .Include(p => p.Skills)
                .FirstAsync(p => p.Id == dto.ProfileId);

            if(profile is not null)
                profile.AddSkill(new Skill(dto.ProfileId, dto.Name, dto.Level));

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveSkill(Guid profileId, Guid skillId)
        {
            var profile = await _context.Profiles
                .Include(p => p.Skills)
                .FirstAsync(p => p.Id == profileId);

            if (profile is not null)
            {
                profile.RemoveSkill(skillId);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> AddAssessement(AssessementDTO dto)
        {
            var profile = await _context.Profiles
               .Include(p => p.Assessments)
               .FirstAsync(p => p.Id == dto.ProfileId);

            if(profile is not null)
            {
                profile.AddAssessment(new Assessment(dto.ProfileId, dto.Title, dto.AssessorUserId, dto.StartDate, dto.EndDate));
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> RemoveAssessement(Guid profileId, Guid assessementId)
        {
            var profile = await _context.Profiles
              .Include(p => p.Assessments)
              .FirstAsync(p => p.Id == profileId);

            if(profile is not null)
            {
                profile.RemoveAssessment(assessementId);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> AddMetricToAssessement(Guid profileId, Guid assessementId, MetricDTO dto)
        {
            var profile = await _context.Profiles
              .Include(p => p.Assessments)
              .FirstAsync(p => p.Id == profileId);

            if (profile is not null)
            {
                profile.AddMetricToAssessement(
                    assessementId, 
                    new Metric(
                        dto.Name,
                        dto.Description, 
                        dto.Type,
                        dto.Weight,
                        dto.Source,
                        dto.Periodicity,
                        dto.Rule)
                );
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> RemoveMetricFromAssessement(Guid profileId, Guid assessementId, Guid metricId)
        {
            var profile = await _context.Profiles
              .Include(p => p.Assessments)
              .FirstAsync(p => p.Id == profileId);

            if(profile is not null)
            {
                profile.RemoveMetricFromAssessement(assessementId, metricId);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
 