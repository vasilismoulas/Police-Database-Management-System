using System;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using CsvHelper.Configuration.Attributes;

namespace PoliceDatabaseManagementSystem
{
    // Read & Write access for different kinds of classes is implemented through interfaces
    // Basically if we pass interface as  is going to hide the  
    internal sealed record class CriminalRecord : ICriminalRecord
    {
        // Private backing fields
        private readonly string _name;
        private readonly string _nickname;
        private readonly DateTime _birthDate;
        private IAccusation _accusationDetails;
        private ICriminalGroup _groupAffiliation;

        public IAccusation AccusationDetails => _accusationDetails;
        public ICriminalGroup GroupAffiliation => _groupAffiliation;


        public string Nickname
        {
            get { return _nickname; }
        }

        public DateTime BirthDate
        {
            get{ return _birthDate; }
        }


        public CriminalRecord(string name, string nickname, DateTime birthdate, Accusation AccusationDetails, CriminalGroup GroupAffiliation)
        {
            this._name = name;
            this._nickname = nickname;
            this._birthDate = birthdate;
            this._accusationDetails = AccusationDetails;
            this._groupAffiliation = GroupAffiliation;
        }

        public string GetName() => _name;

        public void UpdateAccusationDetails(IAccusation newDetails)
        {
            _accusationDetails = newDetails;     
        }

        public void UpdateGroupAffiliation(ICriminalGroup newGroup)
        {
            _groupAffiliation = newGroup;
        }


    }

}