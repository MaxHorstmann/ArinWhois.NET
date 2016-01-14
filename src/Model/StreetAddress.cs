using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArinWhois.Model
{
    public class StreetAddress
    {
        //[DataMember(Name = "line")]
        public List<ValueWrapper<string>> Line = new List<ValueWrapper<string>>();
    }
}
