using thoth_api.Enums;

namespace thoth_api.Domain
{
    public class Metric : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public MetricType Type { get; set; }
        public decimal Weight { get; set; }
        public AssessmentSource Source { get; set; }
        public Periodicity Periodicity { get; set; }
        public string? Rule { get; set; }

        protected Metric() { }
        public Metric(
            string name,
            string description,
            MetricType type,
            decimal weight,
            AssessmentSource source,
            Periodicity periodicity,
            string rule)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name");

            Name = name;
            Description = description ?? "";
            Type = type;
            Weight = weight;
            Source = source;
            Periodicity = periodicity;
            Rule = rule ?? "";
        }
    }
}
