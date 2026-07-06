namespace thoth_api.Domain.Exceptions
{
    public class DomainException: Exception
    {
        public DomainException(string exception)  : base(exception) { }
    }
}
