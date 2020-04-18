using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdtest.Models
{
    public class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public uint Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Kind { get; set; }
        public string Day { get; set; }
        public string Komplex { get; set; }
    }
}
