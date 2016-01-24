using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArinWhois.Model
{
    /// <summary>
    /// The street address used by an ARIN response.
    /// </summary>
    public class StreetAddress
    {
        //[DataMember(Name = "line")]
        public List<ValueWrapper<string>> Line = new List<ValueWrapper<string>>();
    }
}
