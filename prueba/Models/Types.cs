using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Types
    {
        [key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}