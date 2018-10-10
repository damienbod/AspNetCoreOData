using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreOData.Service.Database
{
    public partial class EmailAddress
    {
        [Key]
        public int BusinessEntityId { get; set; }
        [Key]
        public int EmailAddressId { get; set; }
        public string EmailAddress1 { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Person BusinessEntity { get; set; }
    }
}
