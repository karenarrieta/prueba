using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba.Models
{
    public class Projects
    {
        [key]
        public int Id { get; set; }

        
        public string UserId { get; set; }
        //public SelectList Type { get; set; }
        [Display(Name = "Tipo de proyecto")]
        public string TypeId { get; set; }


        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de termino")]
        public DateTime FinishDate { get; set; }

        public bool Deleted { get; set; }


    }
}