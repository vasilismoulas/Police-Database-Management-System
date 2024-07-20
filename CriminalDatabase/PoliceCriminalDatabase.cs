using System;
using System.Collections.ObjectModel;

namespace Police_Database_Management_System.CriminalDatabase
{
    public class PoliceCriminalDatabase : ICriminalGroup, ICriminalRecord
    {
        public List<CriminalRecord> CriminalRecords { get; private set; }
        public List<CriminalGroup> CriminalGroups { get; private set; }


        public PoliceCriminalDatabase()
        {

        }
        public PoliceCriminalDatabase(List<CriminalRecord> CriminalRecords, List<CriminalGroup> CriminalGroups)
        {
            this.CriminalRecords = CriminalRecords;
            this.CriminalGroups = CriminalGroups;
        }


        // Methods to modify records and groups
        public void AddCriminalRecord(CriminalRecord member)
        {
            if (member == null) throw new ArgumentNullException();
            CriminalRecords.Add(member);
        }

        public void RemoveCriminalRecord(CriminalRecord member)
        {
            member = CriminalRecords.Contains(member) ? member : throw new ArgumentNullException();
            CriminalRecords.Remove(member);
        }

        //public void ChangeMember(CriminalGroup group, CriminalRecord member)
        //{
        //    CriminalGroup selected_group = CriminalGroups.Contains(group) ? group : null;
        //}

        public ReadOnlyCollection<CriminalRecord> getCriminalRecords()
        {
            return new ReadOnlyCollection<CriminalRecord>(CriminalRecords);
        }

        public ReadOnlyCollection<CriminalGroup> getCriminalGroups()
        {
            return new ReadOnlyCollection<CriminalGroup>(CriminalGroups);
        }

    }
}