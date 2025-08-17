using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.exceptions
{
    public class NoTokenFoundException : Exception
    {
        public NoTokenFoundException(string message) : base(message)
        {
        }

        public NoTokenFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NoTokenFoundException() : base("No token found in the inverted index storage.")
        {
        }
    }
}
