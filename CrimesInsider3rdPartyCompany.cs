using Police_Database_Management_System;
using System;
using System.Collections.Generic;
using System.Linq;
using Police_Database_Management_System.CriminalDatabase;

public class CrimesInsider3rdPartyCompany
{
    private readonly ICriminalRecord _criminalRecords;
    private readonly ICriminalGroup _criminalGroups;

    public CrimesInsider3rdPartyCompany(ICriminalRecord criminalRecords, ICriminalGroup criminalGroups)
    {
        _criminalRecords = criminalRecords;
        _criminalGroups = criminalGroups;
    }

    public CriminalRecord GetMostDangerousCriminal()
    {
        var records = _criminalRecords.getCriminalRecords();
        return records.OrderByDescending(cr => cr.AccusationDetails.Severity).FirstOrDefault();
    }

    public double GetAverageAgeOfCriminals()
    {
        var records = _criminalRecords.getCriminalRecords();
        if (!records.Any()) return 0.0;

        // Calculate total age
        double totalAge = records.Sum(cr => (DateTime.UtcNow - cr.BirthDate).TotalDays / 365.25); // Use 365.25 for leap years

        // Calculate average age
        return totalAge / records.Count;
    }

    public List<CriminalRecord> SortCriminalsBySeverity()
    {
        var records = _criminalRecords.getCriminalRecords();
        return records.OrderByDescending(cr => cr.AccusationDetails.Severity).ToList();
    }
}
