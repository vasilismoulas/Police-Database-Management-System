using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceDatabaseManagementSystem
{
    internal interface ICriminalGroup
    {
        string GroupName { get; }
        IEnumerable<ICriminalRecord> Members { get; }
    }
}