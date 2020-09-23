using Dojo.Data;
using Dojo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dojo.Validation
{
    public class MyValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var result = false;

            int? arme = value as int?;

            if (value == null)
            {
                result = true;
            }
            else
            {
                using (var db = new DojoContext())
                {
                    var equiped = db.Samourais.Where(x => x.Arme.Id == arme).ToList().Count();

                    if (equiped == 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    
                }
                
            }

            return result;
        }

    }
}