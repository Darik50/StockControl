using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    public class Box : StorageItem
    {        
        public DateTime? DateCreation { get; set; }
        public int IdPallet { get; set; }
    }
}
