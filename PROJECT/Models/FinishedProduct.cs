using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models
{
    public class FinishedProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String name { get; set; }
        public String description { get; set; }
        [Required]
        public String type { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}
