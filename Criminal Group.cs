using System;
using System.Collections.Generic;
using Police_Database_Management_System.CriminalDatabase;
using Police_Database_Management_System.AuthenticationSystem;

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
            if (Authentication.IsCalledFromPoliceCriminalDatabase())
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
            if (Authentication.IsCalledFromPoliceCriminalDatabase())
            {
                _members.Remove(criminal);
            }
            else
            {
                throw new UnauthorizedAccessException("Only the PoliceCriminalDatabase can modify the group members.");
            }
        }

       
    }
}