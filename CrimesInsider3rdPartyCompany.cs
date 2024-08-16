using System;
using System.Collections.Generic;
using System.Linq;


namespace PoliceDatabaseManagementSystem
{

    internal class CrimesInsider3rdPartyCompany
    {
        private readonly IPoliceCriminalDatabase policeDatabase;

        public CrimesInsider3rdPartyCompany(IPoliceCriminalDatabase policeDatabase)
        {
            this.policeDatabase = policeDatabase;
        }

        public ICriminalRecord GetMostDangerousCriminal()
        {
            return policeDatabase.CriminalRecords.OrderByDescending(c => c.AccusationDetails.Severity).FirstOrDefault();
        }

        public IEnumerable<ICriminalRecord> GetCriminalsSortedBySeverity()
        {
            return policeDatabase.CriminalRecords.OrderBy(c => c.AccusationDetails.Severity);
        }

        public double GetAverageAgeOfCriminals()
        {
            return policeDatabase.CriminalRecords.Select(c => (DateTime.Now - c.BirthDate).TotalDays / 365.25).Average();
        }

        public ICriminalRecord GetMostConnectedCriminal()
        {
          
            Dictionary<ICriminalRecord, int> connectionsCount = new Dictionary<ICriminalRecord, int>();

        
            foreach (var criminal in policeDatabase.CriminalRecords)
            {
                int connections = CountGroupConnections(criminal);
                connectionsCount.Add(criminal, connections);
            }

            var mostConnectedCriminal = connectionsCount.OrderByDescending(x => x.Value).FirstOrDefault();

            return mostConnectedCriminal.Key;
        }

        private int CountGroupConnections(ICriminalRecord criminal)
        {
            int connections = 0;
            foreach (var otherCriminal in policeDatabase.CriminalRecords)
            {
                if (otherCriminal != criminal && otherCriminal.GroupAffiliation != null && otherCriminal.GroupAffiliation.Members.Contains(criminal))
                {
                    connections++;
                }
            }
            return connections;
        }


    }
}