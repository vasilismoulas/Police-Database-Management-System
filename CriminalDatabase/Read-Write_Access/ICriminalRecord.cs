using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police_Database_Management_System.CriminalDatabase
{
    public interface ICriminalRecord
    {
        public ReadOnlyCollection<CriminalRecord>  getCriminalRecords();
    }
}
