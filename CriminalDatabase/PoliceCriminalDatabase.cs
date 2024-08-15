using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace PoliceDatabaseManagementSystem
{
    internal sealed class PoliceCriminalDatabase : IPoliceCriminalDatabase
    {
        private List<CriminalRecord> _criminalRecords;
        private List<CriminalGroup> _criminalGroups;

        // Public properties exposing the collections of criminal records and criminal groups as IEnumerable.
        public IEnumerable<ICriminalRecord> CriminalRecords => (IEnumerable<ICriminalRecord>) _criminalRecords;
        public IEnumerable<ICriminalGroup> CriminalGroups =>   (IEnumerable<ICriminalGroup>)  _criminalGroups;

        public PoliceCriminalDatabase()
        {
            this._criminalRecords = new List<CriminalRecord>();
            this._criminalGroups = new List<CriminalGroup>();
        }

        public void AddCriminalRecord(CriminalRecord member)
        {
            if (member == null) throw new ArgumentNullException();
            _criminalRecords.Add(member);
        }

        public void RemoveCriminalRecord(CriminalRecord member)
        {
            member = _criminalRecords.Contains(member) ? member : throw new ArgumentNullException();
            _criminalRecords.Remove(member);
        }

        // Methods to modify database's criminal groups
        public void AddCriminalGroup(CriminalGroup group)
        {
            if (group == null) throw new ArgumentNullException();
            _criminalGroups.Add(group);
        }

        public void RemoveCriminalGroup(CriminalGroup group)
        {
            if (group == null) throw new ArgumentNullException();
            _criminalGroups.Remove(group);
        }

        public void ChangeGroupMembership(CriminalRecord record, CriminalGroup newGroup)
        {
  
            foreach (var group in _criminalGroups)
            {
                if (group.Contains(record))
                {
                    group.RemoveCriminalRecord(record);
                    break; 
                }
            }

            newGroup.AddCriminalRecord(record);
        }

        // Method to set accusation details for a criminal record.
        public void SetAccusationDetails(CriminalRecord record, Accusation accusationDetails)
        {
            record.UpdateAccusationDetails(accusationDetails);
        }

        // Method to set group affiliation for a criminal record.
        public void SetGroupAffiliation(CriminalRecord record, CriminalGroup groupAffiliation)
        {
            record.UpdateGroupAffiliation(groupAffiliation);
        }

    }
}