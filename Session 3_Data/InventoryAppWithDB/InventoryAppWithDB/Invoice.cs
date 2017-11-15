using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppWithDB
{
    public class Invoice
    {
        public string Customer_id { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public DateTime Purchase_date { get; set; }
    }
}
