using System;

namespace TFS.Models
{
    public class DomainModelException : Exception
    {
        public DomainModelException()
        {
        }
        public DomainModelException(string message)
            : base(message)
        {
        }
        public DomainModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
