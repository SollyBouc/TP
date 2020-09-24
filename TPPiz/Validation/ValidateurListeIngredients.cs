using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPPiz.Database;

namespace BO.Validation
{
    class ValidateurListeIngredients : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;





            //si la value, qui est la liste des IdsIngredients, est une liste d'int
            if (value is List<int>)
            {
                //la value devient maList
                var maList = value as List<int>;

                //si une liste d'ingrédient ordonnée est égal à maList ordonnée, donc à ma value
                if (FakeDb.Instance.Pizzas.Any(x => x.Ingredients.Select(z => z.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(y => y))))
                {
                    result = false;
                }

            }

            return result;
        }



        public override string FormatErrorMessage(string name)
        {
            return "Il existe déjà une pizza correspondant à cette liste d'ingrédients";
        }

    }
}
