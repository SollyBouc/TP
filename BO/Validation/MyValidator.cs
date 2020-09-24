using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPPiz.Validation
{
    public class MyValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            List<int> listeIngredients = value as List <int>;

            if (value != null && listeIngredients.Count >= 2 && listeIngredients.Count <= 5)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Une pizza doit contenir entre 2 et 5 ingrédients";
        }

    }
}