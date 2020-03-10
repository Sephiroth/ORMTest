using System;
using System.Collections.Generic;

namespace EFCoreTest.Models
{
    public partial class TUserRole
    {
        public int Id { get; set; }
        public string UserIdcard { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
