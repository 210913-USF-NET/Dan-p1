using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mods
{
    public class LineItem
    {
        
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BeersId { get; set; }

        public int BeerId { get; set; }

        public Beer Beer { get; set; }
    }
}