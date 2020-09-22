using BO;
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

        public int? IdArme { get; set; }
    }
}