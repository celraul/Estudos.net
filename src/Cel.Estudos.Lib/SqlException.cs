using System.Runtime.Serialization;

namespace Cel.Estudos.Lib
{
    public class SqlException : Exception
    {
        public SqlException() { }

        public SqlException(string message) : base(message) { }

        public SqlException(string message, Exception exception) : base(message, exception) { }

        protected SqlException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}