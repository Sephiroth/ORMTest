using System;
using System.Collections.Generic;

namespace EFCoreTest.Models
{
    public partial class TRoleinfo
    {
        public int Id { get; set; }
        public string RoleNameEn { get; set; }
        public string RoleNameCn { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
