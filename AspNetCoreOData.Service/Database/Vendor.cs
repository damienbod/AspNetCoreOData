using System;
using System.Collections.Generic;

namespace AspNetCoreOData.Service.Database
{
    public partial class Vendor
    {
        public Vendor()
        {
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
        }

        public int BusinessEntityId { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public byte CreditRating { get; set; }
        public bool? PreferredVendorStatus { get; set; }
        public bool? ActiveFlag { get; set; }
        public string PurchasingWebServiceUrl { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }
        public virtual ICollection<ProductVendor> ProductVendor { get; set; }
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
    }
}
