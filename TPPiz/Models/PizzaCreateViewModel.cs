
using BO;
using BO.Validation;
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

        [MyValidator]
        [ValidateurListeIngredients]
        public List<int> IdsIngredients { get; set; } = new List<int>();
        [Required]
        public int? IdPate { get; set; }
    }
}