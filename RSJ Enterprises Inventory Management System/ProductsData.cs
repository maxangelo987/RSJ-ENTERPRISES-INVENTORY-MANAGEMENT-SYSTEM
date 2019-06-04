using System;

namespace Inventory_Management_System
{
    [Serializable]
    class ProductsData
    {
        /// <summary>
        /// Personal Information
        /// </summary>
        public ulong id { set; get; }
        public string barcode { set; get; }
        public string item { set; get; }
        public string description { set; get; }
        public string unit { set; get; }
        public long quantity { set; get; }
        public double unitprice { set; get; }
        public double retailprice { set; get; }
      
        
    }
}
