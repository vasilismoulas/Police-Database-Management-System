using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceDatabaseManagementSystem
{
    public enum CrimeType
    {  
        Theft,
        Assault,
        Fraud,
        Homicide,
        Burglary,
        Robbery,
        Arson,
        DrugTrafficking,
        Shoplifting,
        Embezzlement
    }
    public enum CrimeSeverity { Low, Medium, High }

    internal interface IAccusation
    {
        CrimeType TypeOfCrime { get; }
        CrimeSeverity Severity { get; }
        string Description { get; }
        DateTime DateOccurred { get; }
    }
}