using thoth_api.Domain.Exceptions;

namespace thoth_api.Domain
{
    public class Assessment : Entity
    {
        public Guid ProfileId { get; set; }
        public string Title { get; set; }
        public Guid AssessorUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private List<Metric> _assessmentMetrics { get; set; } = new();
        public IReadOnlyCollection<Metric> AssessmentMetrics => _assessmentMetrics.AsReadOnly();


        protected Assessment() { }
        public Assessment(Guid profileId, string title, Guid assessorUserId, DateTime startDate, DateTime endDate)
        {
            ProfileId = profileId;
            Title = title;
            AssessorUserId = assessorUserId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void AddMetric(Metric metric)
        {
            if (_assessmentMetrics.Exists(m => m.Id == metric.Id)) 
                throw new DomainException("Metric already exists in Assessment");

            _assessmentMetrics.Add(metric);
        }

        public void RemoveMetric(Guid metricId)
        {
            var metric = _assessmentMetrics.FirstOrDefault(m => m.Id == metricId);
            if (metric is null) throw new DomainException("Metric is not found");

            _assessmentMetrics.Remove(metric);
        }
    }
}
