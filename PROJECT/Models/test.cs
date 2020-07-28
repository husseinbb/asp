using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models
{
    public class test
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




        
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }


    }
}
