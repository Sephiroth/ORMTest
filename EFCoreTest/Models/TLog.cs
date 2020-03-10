using System;
using System.Collections.Generic;

namespace EFCoreTest.Models
{
    public partial class TLog
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Log { get; set; }
        public string OperatorIdcard { get; set; }
        public string OperatorRole { get; set; }
        public string OperatorName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
