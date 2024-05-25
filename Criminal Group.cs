using System;
using System.Collections.Generic;

namespace Police_Database_Management_System
{
    public class CriminalGroup
    {
        private readonly string _groupname;
        private List<CriminalRecord> _members;

        public string GroupName
        {
            get { return _groupname; }

        }

        public List<CriminalRecord> Members
        {
            get { return _members; }
        }


        public CriminalGroup(string groupname, List<CriminalRecord> Members)
        {
            _groupname = groupname;
            _members = Members;
        }

        internal void addCriminalRecord(CriminalRecord criminal)
        {
            if (IsCalledFromPoliceCriminalDatabase())
            {
                _members.Add(criminal);
            }
            else
            {
                throw new UnauthorizedAccessException("Only the PoliceCriminalDatabase can modify the group members.");
            }
        }

        internal void removeCriminalRecord(CriminalRecord criminal)
        {
            if (IsCalledFromPoliceCriminalDatabase())
            {
                _members.Remove(criminal);
            }
            else
            {
                throw new UnauthorizedAccessException("Only the PoliceCriminalDatabase can modify the group members.");
            }
        }

        private bool IsCalledFromPoliceCriminalDatabase()
        {
            var frame = new System.Diagnostics.StackFrame(2);//It skips "IsCalledFromPoliceCriminalDatabase" function plus with properties get function so we can retrieve the class that a CriminaRecords member has been called.
            var method = frame.GetMethod();
            return method.DeclaringType == typeof(PoliceCriminalDatabase);
        }
    }
}