using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceDatabaseManagementSystem
{
    internal interface ICriminalRecord
    {
        string Nickname { get; }
        DateTime BirthDate { get; }
        IAccusation AccusationDetails { get; }
        ICriminalGroup GroupAffiliation { get; }
    }
}
