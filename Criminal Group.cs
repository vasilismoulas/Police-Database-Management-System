using System;
using System.Collections.Generic;


namespace PoliceDatabaseManagementSystem
{
    internal sealed class CriminalGroup : ICriminalGroup
    {
        private string _groupname;
        private List<ICriminalRecord> _members;

        public string GroupName
        {
            get { return _groupname; }
        }

        public IEnumerable<ICriminalRecord> Members => _members;


        public CriminalGroup(string groupname, List<ICriminalRecord> Members)
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

        public bool Contains(CriminalRecord criminal)
        {
            return _members.Contains(criminal);
        }

    }

    internal class CriminalGroupEqualityComparer : IEqualityComparer<CriminalGroup>
    {
        public bool Equals(CriminalGroup x, CriminalGroup y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;

            // You can compare based on the GroupName or any other property that defines equality for your use case
            return string.Equals(x.GroupName, y.GroupName, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(CriminalGroup obj)
        {
            if (obj == null) return 0;

            // GetHashCode should match the property you're using for equality (in this case, GroupName)
            return obj.GroupName?.GetHashCode(StringComparison.OrdinalIgnoreCase) ?? 0;
        }
    }
}