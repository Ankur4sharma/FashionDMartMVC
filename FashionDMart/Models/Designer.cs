using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FashionDMart.Models
{
    public class Designer
    {
        // desginer form
        public int id { get; set; }

        [Display(Name = " Name")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }





    }
}
