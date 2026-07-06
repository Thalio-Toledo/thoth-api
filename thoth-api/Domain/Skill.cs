using thoth_api.Enums;

namespace thoth_api.Domain
{
    public class Skill : Entity
    {
        public Guid ProfileId { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }

        protected Skill() { }
        public Skill(Guid profileId, string name, Level level)
        {
            if(profileId == Guid.Empty) throw new ArgumentNullException("ProfileId");
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("name"); 

            ProfileId = profileId;
            Name = name;
            Level = level;
        }
    }

}
