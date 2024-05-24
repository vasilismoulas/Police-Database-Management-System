using System;
using System.Collections.Generic;
using PDMS;

namespace PDMS
{
    public class CrimesInsider3rdPartyCompany
    {
        private readonly PoliceCriminalDatabase _database;
        public CrimesInsider3rdPartyCompany(PoliceCriminalDatabase database)
        {
            _database = database;
        }
        //public CriminalRecord GetMostDangerousCriminal()
        //{
            // Implementation to calculate the most dangerous criminal
            //return new CriminalRecord();
        //}
        public double GetAverageAgeOfCriminals()
        {
            // Implementation to calculate the average age of criminals
            return 0.0;
        }
        public List<CriminalRecord> SortCriminalsBySeverity()
        {
            // Implementation to sort criminals by severity
            return new List<CriminalRecord>();
        }
    }

}