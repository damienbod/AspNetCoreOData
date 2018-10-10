using Microsoft.Spatial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace AspNetCoreOData.Service.Database
{
    [Table("Person.PhoneNumberType")]
    public partial class PhoneNumberType
    {
        public static class PhoneNumberTypeExpressions
        {
            public static readonly Expression<Func<PhoneNumberType, DateTime>> ModifiedDate = c => c.LastModifiedOnInternal;
        }

        public PhoneNumberType()
        {
            PersonPhone = new HashSet<PersonPhone>();
        }

        public int PhoneNumberTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTimeOffset ModifiedDate
        {
            get { return new DateTimeOffset(LastModifiedOnInternal); }
            set { LastModifiedOnInternal = value.DateTime; }
        }

        private DateTime LastModifiedOnInternal { get; set; }

        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
