using System;
using System.Collections.Generic;

namespace AspNetCoreOData.Service.Database
{
    public partial class Customer
    {
        public Customer()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public int CustomerId { get; set; }
        public int? PersonId { get; set; }
        public int? StoreId { get; set; }
        public int? TerritoryId { get; set; }
        public string AccountNumber { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual Store Store { get; set; }
        public virtual SalesTerritory Territory { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
