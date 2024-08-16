using System;

namespace PoliceDatabaseManagementSystem
{

    internal class Accusation : IAccusation
    {
        private readonly CrimeType _typeofcrime;
        private readonly CrimeSeverity _severity;
        private readonly string _description;
        private readonly DateTime _dateOccurred;

        public CrimeType TypeOfCrime
        {
            get { return _typeofcrime; }
        }

        public CrimeSeverity Severity
        {
            get { return _severity; }
        }

        public string Description
        {
            get { return _description; }
        }

        public DateTime DateOccurred
        {
            get { return _dateOccurred; }
        }


        public Accusation(CrimeType TypeOfCrime, CrimeSeverity Severity, string Description, DateTime DateOccurred)
        {
            this._typeofcrime = TypeOfCrime;
            this._severity = Severity;
            this._description = Description;
            this._dateOccurred = DateOccurred;
        }
    }
}
