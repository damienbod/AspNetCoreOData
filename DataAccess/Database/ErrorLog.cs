﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Database
{
    public partial class ErrorLog
    {
        public int ErrorLogId { get; set; }
        public DateTime ErrorTime { get; set; }
        public string UserName { get; set; }
        public int ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        public string ErrorProcedure { get; set; }
        public int? ErrorLine { get; set; }
        public string ErrorMessage { get; set; }
    }
}
