using System;
using System.Collections.Generic;

namespace PDMS
{
    public class CriminalGroup
    {
        public string GroupName { get; set; }
        public List<CriminalRecord> Members { get; set; }
    }
}