using thoth_api.Domain.Exceptions;

namespace thoth_api.Domain
{
    public class Profile : AggregateRoot
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        private List<Skill> _skills { get; set; } = new();
        public IReadOnlyCollection<Skill> Skills => _skills.AsReadOnly();
        private List<Assessment> _assessments { get; set; } = new();
        public IReadOnlyCollection<Assessment> Assessments => _assessments.AsReadOnly();

        protected Profile() { }
        public Profile(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new DomainException("Name can not be null");
            Name = name;
        }

        public void AddSkill(Skill skill)
        {
            if(skill is not null)
                throw new DomainException("Skill can not be null");

            if (_skills.Exists(s => s.Id == skill.Id))
                throw new DomainException("Skill already exists in this profile");

            _skills.Add(skill);
        }
            
        public void RemoveSkill(Guid skillId)
        {
            var skill = _skills.FirstOrDefault(s => s.Id == skillId);
            if (skill is null)
                throw new DomainException("Skill not found!");

            _skills.Remove(skill);
        }

        public void AddAssessment(Assessment assessment)
        {
            if (_assessments.Exists(a => a.Id == assessment.Id))
            {
                throw new Exception("Assessment already exists");
            }

            _assessments.Add(assessment);
        }

        public void RemoveAssessment(Guid assessementId)
        {
            var assessement = _assessments.FirstOrDefault(a => a.Id == assessementId);
            if (assessement is null)
                throw new Exception("Assessement not found!");

            _assessments.Remove(assessement);
        }

        public void AddMetricToAssessement(Guid assessementId, Metric metric)
        {
            var assessement = _assessments.FirstOrDefault(a => a.Id == assessementId);
            if (assessement is null)
                throw new Exception("Assessement not found!");

            assessement.AddMetric(metric);
        }

        public void RemoveMetricFromAssessement(Guid assessementId, Guid metricId)
        {
            var assessement = _assessments.FirstOrDefault(a => a.Id == assessementId);
            if (assessement is null)
                throw new Exception("Assessement not found!");

            assessement.RemoveMetric(metricId);
        }


    }
}
