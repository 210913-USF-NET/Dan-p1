using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mods
{
    public class Inventory
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int BeersId { get; set; }

        public Beer Beer { get; set; }
    }
}