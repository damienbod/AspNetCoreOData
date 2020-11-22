using System;
using System.Collections.Generic;

#nullable disable

namespace AspNetCoreOData.Service.Database
{
    public partial class ScrapReason
    {
        public ScrapReason()
        {
            WorkOrders = new HashSet<WorkOrder>();
        }

        public short ScrapReasonId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
