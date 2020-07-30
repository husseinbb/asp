using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models
{
    public class Cust_Raw
    {
        public Customer customer { get; set; }
        public RawMaterial rawMaterial { get; set; }
        public IEnumerable<RawMaterial> rawList { get; set; }
    }
}
