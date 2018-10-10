using Microsoft.Spatial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace AspNetCoreOData.Service.Database
{
    [Table("Person.ContactType")]
    public partial class ContactType
    {
        public static class ContactTypeExpressions
        {
            public static readonly Expression<Func<ContactType, DateTime>> ModifiedDate = c => c.LastModifiedOnInternal;
        }

        // Other properties

        public DateTimeOffset ModifiedDate
        {
            get { return new DateTimeOffset(LastModifiedOnInternal); }
            set { LastModifiedOnInternal = value.DateTime; }
        }

        private DateTime LastModifiedOnInternal { get; set; }

        public ContactType()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
        }

        public int ContactTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
    }
}
