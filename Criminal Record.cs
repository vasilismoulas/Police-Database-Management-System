using System;
using System.Xml.Linq;
using Police_Database_Management_System.CriminalDatabase;
using Police_Database_Management_System.AuthenticationSystem;
using System.Runtime.CompilerServices;
using CsvHelper.Configuration.Attributes;

namespace Police_Database_Management_System
{
    public record class CriminalRecord
    {
        // Private backing fields
        private readonly string _name;
        private readonly string _nickname;
        private readonly DateTime _birthDate;
        public Accusation AccusationDetails { get; private set; }
        public CriminalGroup GroupAffiliation { get; private set; }

        //Properties
        public string Name
        {
            get
            {
                if (Authentication.IsCalledFromPoliceCriminalDatabase())
                    return _name;
                else
                    throw new UnauthorisedInformationRetrievalException();
            }
        }

        public string Nickname
        {
            get
            {
                if (Authentication.IsCalledFromPoliceCriminalDatabase())
                    return _nickname;
                else
                    throw new UnauthorisedInformationRetrievalException();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                if (Authentication.IsCalledFromPoliceCriminalDatabase())
                    return _birthDate;
                else
                    throw new UnauthorisedInformationRetrievalException();
            }
        }


        public CriminalRecord(string name, string nickname, DateTime birthdate, Accusation AccusationDetails, CriminalGroup GroupAffiliation)
        {
            this._name = name;
            this._nickname = nickname;
            this._birthDate = birthdate;
            this.AccusationDetails = AccusationDetails;
            this.GroupAffiliation = GroupAffiliation;
        }

        // Method to update mutable properties (only accessible by PoliceCriminalDatabase)
        public void UpdateAccusationDetails(Accusation newDetails)
        {
            if (Authentication.IsCalledFromPoliceCriminalDatabase())
                AccusationDetails = newDetails;
            else
                throw new UnauthorisedInformationRetrievalException();
        }

        public void UpdateGroupAffiliation(CriminalGroup newGroup)
        {
            if (Authentication.IsCalledFromPoliceCriminalDatabase())
                GroupAffiliation = newGroup;
            else
                throw new UnauthorisedInformationRetrievalException();
        }

        public string toString()
        {
            return this._name+" "+this._nickname+" "+this._birthDate+" "+ this.AccusationDetails+" "+ this.GroupAffiliation;
        }

    }

}