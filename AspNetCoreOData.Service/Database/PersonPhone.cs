﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AspNetCoreOData.Service.Database
{
    public partial class PersonPhone
    {
        [Key]
        public int BusinessEntityId { get; set; }
        public string PhoneNumber { get; set; }
        [Key]
        public int PhoneNumberTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Person BusinessEntity { get; set; }
        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}
