using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreOData.Service.Database
{
    public partial class BusinessEntityAddress
    {
        [Key]
        public int BusinessEntityId { get; set; }
        [Key]
        public int AddressId { get; set; }
        [Key]
        public int AddressTypeId { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
