using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Real
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; } // example - beauty product, hair product etc..
        public int ProductAmount { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int SupplierID { get; set; }
    }
}
