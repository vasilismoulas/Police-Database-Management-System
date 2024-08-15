using System;
using System.Collections.Generic;


namespace PoliceDatabaseManagementSystem
{
    internal sealed class CriminalGroup : ICriminalGroup
    {
        private string _groupname;
        private List<CriminalRecord> _members;

        public string GroupName
        {
            get { return _groupname; }
        }

        public IEnumerable<ICriminalRecord> Members => (IEnumerable<ICriminalRecord>)_members;


        public CriminalGroup(string groupname, List<CriminalRecord> Members)
        {
            _groupname = groupname;
            _members = Members;
        }

        public void AddCriminalRecord(CriminalRecord criminal)
        {
                _members.Add(criminal);
        }

        public void RemoveCriminalRecord(CriminalRecord criminal)
        {
                _members.Remove(criminal);
        }

        // Method to check if the group contains a specific criminal
        public bool Contains(CriminalRecord criminal)
        {
            return _members.Contains(criminal);
        }

    }
}