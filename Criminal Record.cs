using System;
using System.Xml.Linq;

namespace Police_Database_Management_System
{
    public class CriminalRecord
    {
        // Private backing fields
        private readonly string _name;
        private readonly string  _nickname;
        private readonly DateTime _birthDate;

        //Properties
        public string Name
        {
            get
            {
                if (IsCalledFromPoliceCriminalDatabase())
                    return _name;
                else
                    throw new UnauthorisedInformationRetrievalException();
            }
        }

        public string Nickname
        {
            get
            {
                if (IsCalledFromPoliceCriminalDatabase())
                    return _nickname;
                else
                    throw new UnauthorisedInformationRetrievalException();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                if (IsCalledFromPoliceCriminalDatabase())
                    return _birthDate;
                else
                    throw new UnauthorisedInformationRetrievalException();
            }
        }

        public Accusation AccusationDetails { get; private set; }
        public CriminalGroup GroupAffiliation { get; private set; }


        public CriminalRecord(string name, string nickname, DateTime birthdate, Accusation AccusationDetails, CriminalGroup GroupAffiliation)
        {
             this._name = name;
             this._nickname = nickname;
             this._birthDate = birthdate;
             this.AccusationDetails = AccusationDetails;
             this.GroupAffiliation = GroupAffiliation;
        }

        // Method to update mutable properties (only accessible by PoliceCriminalDatabase)
        internal void UpdateAccusationDetails(Accusation newDetails)
        {
            AccusationDetails = newDetails;
        }

        internal void UpdateGroupAffiliation(CriminalGroup newGroup)
        {
            GroupAffiliation = newGroup;
        }

        private bool IsCalledFromPoliceCriminalDatabase()
        {
            var frame = new System.Diagnostics.StackFrame(2);//It skips "IsCalledFromPoliceCriminalDatabase" function plus with properties get function so we can retrieve the class that a CriminaRecords member has been called.
            var method = frame.GetMethod();
            return method.DeclaringType == typeof(PoliceCriminalDatabase);
        }

    }

    public class UnauthorisedInformationRetrievalException : Exception
    {
        public UnauthorisedInformationRetrievalException() { }
        public UnauthorisedInformationRetrievalException(string message) : base(message) { }
        public UnauthorisedInformationRetrievalException(string message, Exception inner) : base(message, inner) { }
    }
}