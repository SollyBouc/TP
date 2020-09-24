using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPPiz.Database;

namespace TPPiz.Validation
{
    public class ValidateurNomPizza : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;

            string pizzaTest = value as string;
            
            


            if (value != null && FakeDb.Instance.Pizzas.Any(x => x.Nom == pizzaTest))
            {
                result = false;
            }
            

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Il existe déjà une pizza portant ce nom";
        }

    }

}
