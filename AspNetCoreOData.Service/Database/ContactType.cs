using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AspNetCoreOData.Service.Database
{
    public partial class ContactType
    {
        public ContactType()
        {
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        [Key]
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}
