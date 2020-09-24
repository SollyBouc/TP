using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPPiz.Validation;

namespace BO
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.MinLength(5, ErrorMessage = "Le champ Nom doit être une chaîne de caractère d'une longueur minimale de 5 caractères")]
        [System.ComponentModel.DataAnnotations.MaxLength(20, ErrorMessage = "Le champ Nom doit être une chaîne de caractère d'une longueur maximale de 20 caractères")]
        
        [ValidateurNomPizza]
        public string Nom { get; set; }
        
        public Pate Pate { get; set; }
        
        public List<Ingredient> Ingredients { get; set; }

    }
}
