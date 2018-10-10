using System;
using System.Collections.Generic;

namespace AspNetCoreOData.Service.Database
{
    public partial class Location
    {
        public Location()
        {
            ProductInventory = new HashSet<ProductInventory>();
            WorkOrderRouting = new HashSet<WorkOrderRouting>();
        }

        public short LocationId { get; set; }
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductInventory> ProductInventory { get; set; }
        public virtual ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}
