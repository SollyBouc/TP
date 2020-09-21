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
            if (value.ToString().Length >= 1)
            {
                result = true;
            }
            return result;
        }
    }
}