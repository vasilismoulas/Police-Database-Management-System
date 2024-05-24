using System;
using System.Xml.Linq;

namespace PDMS
{
    public class CriminalRecord
    {
        // Private backing fields
        private readonly string _name;
        private readonly string _nickname;
        private readonly DateTime _birthDate;



        public string Name { get; }
        public string Nickname{ get; }
        public DateTime BirthDate{ get; }
        public Accusation AccusationDetails;
        public CriminalGroup GroupAffiliation; 

        

       
        public CriminalRecord(string name,string nickname,DateTime birthdate)
        {
             this.Name = name;
             this.Nickname = nickname;
             this.BirthDate = birthdate;

        }

    }

}