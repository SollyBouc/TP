
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPPiz.Validation;

namespace TPPiz.Models
{
    public class PizzaCreateViewModel
    {

        public Pizza Pizza { get; set; }

        
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<int> IdsIngredients { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.MinLength(1, ErrorMessage = "Non")]
        public int IdPate { get; set; }
    }
}