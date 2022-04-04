using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniProject.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("RoleID")]
        public int RoleID { get; set; }
        public Role Role { get; set; }
        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public List<Product> Product { get; set; }


    }
}
