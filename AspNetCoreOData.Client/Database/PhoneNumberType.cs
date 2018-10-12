using System;
using System.Collections.Generic;

namespace AspNetCoreOData.Service.Database
{
    public partial class PhoneNumberType
    {
        public PhoneNumberType()
        {
            PersonPhone = new HashSet<PersonPhone>();
        }

        public int PhoneNumberTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
