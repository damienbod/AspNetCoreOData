using System;
using System.Collections.Generic;

namespace AspNetCoreOData.Service.Database
{
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            BillOfMaterials = new HashSet<BillOfMaterials>();
            ProductSizeUnitMeasureCodeNavigation = new HashSet<Product>();
            ProductVendor = new HashSet<ProductVendor>();
            ProductWeightUnitMeasureCodeNavigation = new HashSet<Product>();
        }

        public string UnitMeasureCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BillOfMaterials> BillOfMaterials { get; set; }
        public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigation { get; set; }
        public virtual ICollection<ProductVendor> ProductVendor { get; set; }
        public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigation { get; set; }
    }
}
