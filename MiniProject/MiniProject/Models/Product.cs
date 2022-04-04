using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniProject.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
