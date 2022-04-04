using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniProject.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<User> User { get; set; }

    }
}
