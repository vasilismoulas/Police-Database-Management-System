using System;
using CsvHelper;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using Microsoft.SqlServer.Dac.Extensibility;
using System.Linq.Expressions;

namespace PoliceDatabaseManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PoliceCriminalDatabase policeDatabase = new PoliceCriminalDatabase();

            List<CriminalGroup> cg_list = new List<CriminalGroup>();
            List<CriminalRecord> cr_list = new List<CriminalRecord>();

            try
            {
               
                string filePath = "criminal_dataset.csv";
                if (File.Exists(filePath))
                {
                    // Data preprocessing
                    var lines = File.ReadAllLines(filePath);
                    lines = lines.Skip(1).ToArray();


                    foreach (var line in lines)
                    {
                        // Split line delimiter(',')
                        String[] attribute = line.Split(",", 10);

                        string h = attribute[5];
                        Console.WriteLine(h);
                        CrimeType crimeType;
                        if (!Enum.TryParse(attribute[5], out crimeType))
                        {
                            // Handle invalid CrimeType
                            Console.WriteLine($"Invalid CrimeType: {attribute[5]}");
                            
                        }
                        var p2 = (CrimeSeverity)Enum.Parse(typeof(CrimeSeverity), attribute[4]);
                        var p3 = attribute[6];
                        var p4 = DateTime.Parse(attribute[7]);

                        Accusation accusationdetails = new Accusation((CrimeType)Enum.Parse(typeof(CrimeType),
                                                                       attribute[5]),
                                                                       (CrimeSeverity)Enum.Parse(typeof(CrimeSeverity),
                                                                       attribute[4]),
                                                                       attribute[6],
                                                                       DateTime.Parse(attribute[7]));

                        if (cg_list.Where(cg => cg.GroupName == attribute[9]) == null)
                        {
                            var cg = new CriminalGroup(attribute[9], null);
                            CriminalRecord cr = new CriminalRecord(attribute[1],
                                                                   attribute[2],
                                                                   DateTime.Parse(attribute[3]),
                                                                   accusationdetails,
                                                                   cg); // CriminalGroup atrb. is missing.

                            cr_list.Add(cr);
                            cg_list.Add(cg);
                        }
                        else
                        {
                            // Using LINQ Queries to find a record
                            CriminalGroup specificgroup = cg_list.FirstOrDefault(cg => cg.GroupName == attribute[9]);

                            CriminalRecord cr = new CriminalRecord(attribute[1],
                                                                    attribute[2],
                                                                    DateTime.Parse(attribute[3]),
                                                                    accusationdetails,
                                                                    specificgroup); // CriminalGroup atrb. is missing.
                            cr_list.Add(cr);
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
    

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
                Console.WriteLine($"Severity: {criminal.AccusationDetails}");
            }

        }


    }
}