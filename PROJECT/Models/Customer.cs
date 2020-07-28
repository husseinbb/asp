using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PROJECT.Models
{
    public class Customer 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String fname { get; set; }
        [Required]
        public String lname { get; set; }
        [Required]
        public String address { get; set; }
        [Required]
        public int CNIC { get; set; }
        [Required]
        public String contact { get; set; }
        [Column(TypeName="varchar(100)")]
        [DisplayName("Image Name")]
        public String imageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }


       
    }
}
