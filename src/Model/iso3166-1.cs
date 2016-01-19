using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    /// <summary>
    /// The international location information used by an ARIN response.
    /// </summary>
    public class iso3166_1
    {
        [DataMember(Name = "name")]
        public ValueWrapper<string> Name { get; set; }
    }
}
