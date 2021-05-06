using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellLibrary.Containers
{
    public class DateContainer
    {
        public DateTime BiosReleaseDate { get; set; }
        public DateTime OsLocalDateTime { get; set; }
        public DateTime OsLastBootUpTime { get; set; }
        public Osuptime OsUptime { get; set; }
    }


}
