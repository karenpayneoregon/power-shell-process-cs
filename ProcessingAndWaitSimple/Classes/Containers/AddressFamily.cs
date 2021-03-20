using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingAndWait.Classes.Containers
{

    public class AddressFamily
    {
        public string IPaddress { get; set; }
        public string InterfaceAlias { get; set; }
        public int InterfaceIndex { get; set; }
        public override string ToString() => IPaddress;

    }

}
