using System;
using System.Collections.Generic;

namespace EFCoreTest.Models
{
    public partial class TPower
    {
        public int Id { get; set; }
        public string PowerName { get; set; }
        public string PowerInterface { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
