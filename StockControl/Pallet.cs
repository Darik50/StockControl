using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    public class Pallet : StorageItem
    {
        public List<Box> Boxes { get; set; }
        public Pallet()
        {
            Boxes = new List<Box>();
        }
    }
}
