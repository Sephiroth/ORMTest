using System;
using System.Collections.Generic;

namespace EFCoreTest.Models
{
    public partial class TRolePower
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PowerId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
