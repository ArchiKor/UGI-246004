using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InventoryNumber : IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.InventoryNumber.CompareTo(y.InventoryNumber);
        }
    }
}
