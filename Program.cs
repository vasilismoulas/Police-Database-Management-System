using System;
using CsvHelper;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using Microsoft.SqlServer.Dac.Extensibility;
using System.Linq.Expressions;
using System.IO;
using Tuple;

namespace PoliceDatabaseManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tuple.Tuple<List<CriminalRecord>, List<CriminalGroup>> recordgrouptuple;
               
            string filePath = "criminal_dataset.csv";
            if (File.Exists(filePath))
            {
                recordgrouptuple = ExtractCriminalRecordsandGroups(filePath);
            }
            else
            {
                throw new IOException("Given file does not exist\nERROR!");
            }

            // Initialise PoliceCriminal Database
            PoliceCriminalDatabase policeDatabase = new PoliceCriminalDatabase(recordgrouptuple.item1, recordgrouptuple.item2);
            
            // Pass the database to the CrimesInsider3rdPartyCompany
            var crimesInsider = new CrimesInsider3rdPartyCompany(policeDatabase);

            // Get and display the most dangerous criminal
            var mostDangerousCriminal = crimesInsider.GetMostDangerousCriminal();
            //Console.WriteLine($"Most Dangerous Criminal: {mostDangerousCriminal.Name}, Severity: {mostDangerousCriminal.Severity}");

            // Get and display the average age of criminals
            var averageAge = crimesInsider.GetAverageAgeOfCriminals();
            Console.WriteLine($"Average Age of Criminals: {averageAge}");

            // Get and display the sorted list of criminals by severity
            var sortedCriminals = crimesInsider.GetCriminalsSortedBySeverity();
            Console.WriteLine("Criminals sorted by severity:");

            foreach (var criminal in sortedCriminals)
            {
                Console.WriteLine($"Severity: {criminal.AccusationDetails.Severity}");
                Console.WriteLine($"Severity: {criminal.AccusationDetails.Severity}");
            }

        }

        static Tuple.Tuple<List<CriminalRecord>, List<CriminalGroup>> ExtractCriminalRecordsandGroups(string csvFilePath)
        {
            var criminalRecords = new List<CriminalRecord>();
            var criminalGroups =  new List<CriminalGroup>();

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    // Extract Accusation Details from the CSV
                    var accusationDetails = new Accusation(
                        csv.GetField<CrimeType>("CrimeType"),
                        csv.GetField<CrimeSeverity>("Severity"),
                        csv.GetField<string>("Description"),
                        csv.GetField<DateTime>("DateOccurred")       
                    );

                    // Extract Criminal Record Details
                    var record = new CriminalRecord(
                        csv.GetField<string>("Name"),
                        csv.GetField<string>("Nickname"),
                        csv.GetField<DateTime>("BirthDate"),
                        accusationDetails, // Pass the extracted accusation details
                        null // Placeholder for GroupAffiliation, will be set below
                    );

                    // Handle Criminal Group Affiliation
                    var groupName = csv.GetField<string>("GroupName");
                    var cg = new CriminalGroup(groupName, new List<ICriminalRecord>());
                    var comparer = new CriminalGroupEqualityComparer();

                    if (!criminalGroups.Contains(cg, comparer))
                    {
                        criminalGroups.Add(cg);
                        record.UpdateGroupAffiliation(cg);
                    }
                    else
                    {
                        var existingGroup = criminalGroups.FirstOrDefault(g => comparer.Equals(g, cg));
                        record.UpdateGroupAffiliation(existingGroup);
                        existingGroup.AddCriminalRecord(record);                
                    }
                    criminalRecords.Add(record);
                }

            }

            return new Tuple.Tuple<List<CriminalRecord>, List<CriminalGroup>>(criminalRecords, criminalGroups);
        }

    }
}