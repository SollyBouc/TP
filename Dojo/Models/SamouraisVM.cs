using BO;
using Dojo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dojo.Models
{
    public class SamouraisVM
    {
        public virtual Samourai Samourai { get; set; }

        public int Id { get; set; }

        public int Force { get; set; }

        public string Nom { get; set; }

        
        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();

        [MyValidator(ErrorMessage = "Cette arme est déjà utilisée")]
        public int? IdArme { get; set; }

        public List<SelectListItem> Arts { get; set; } = new List<SelectListItem>();

        public List<int?> IdsArts { get; set; }

        


    }
}