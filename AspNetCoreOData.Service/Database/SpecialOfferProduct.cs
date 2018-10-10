using System;
using System.Collections.Generic;

namespace AspNetCoreOData.Service.Database
{
    public partial class SpecialOfferProduct
    {
        public SpecialOfferProduct()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        public int SpecialOfferId { get; set; }
        public int ProductId { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual SpecialOffer SpecialOffer { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
}
