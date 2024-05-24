using System;

public enum CrimeType { Theft, Assault, Fraud, Homicide }
public enum CrimeSeverity { Low, Medium, High }

namespace PDMS
{
    public class Accusation
    {
        public CrimeType TypeOfCrime { get; }
        public CrimeSeverity Severity { get; }
        public string Description { get; }
        public DateTime DateOccurred { get; }

        public Accusation(CrimeType TypeOfCrime, CrimeSeverity Severity, string Description, DateTime DateOccurred)
        {
            this.TypeOfCrime = TypeOfCrime;
            this.Severity = Severity;
            this.Description = Description;
            this.DateOccurred = DateOccurred;
        }
    }
}
