using System;
using System.Collections.Generic;

namespace EFCoreTest.Models
{
    public partial class TUserinfo
    {
        public int Id { get; set; }
        public string Idcard { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
