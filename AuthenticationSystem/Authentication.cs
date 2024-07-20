using Police_Database_Management_System.CriminalDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police_Database_Management_System.AuthenticationSystem
{
    public static class Authentication
    {
        public static bool IsCalledFromPoliceCriminalDatabase()
        {
            var frame = new System.Diagnostics.StackFrame(2);//It skips "IsCalledFromPoliceCriminalDatabase" function plus with properties get function so we can retrieve the class that a CriminaRecords member has been called.
            var method = frame.GetMethod();
            return method.DeclaringType == typeof(PoliceCriminalDatabase);
        }
    }

    public class UnauthorisedInformationRetrievalException : Exception
    {
        public UnauthorisedInformationRetrievalException()
        {
        }

        public UnauthorisedInformationRetrievalException(string message)
            : base(message)
        {
        }

        public UnauthorisedInformationRetrievalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class UnauthorisedInformationModificationException : Exception
    {
        public UnauthorisedInformationModificationException()
        {
        }

        public UnauthorisedInformationModificationException(string message)
            : base(message)
        {
        }

        public UnauthorisedInformationModificationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
