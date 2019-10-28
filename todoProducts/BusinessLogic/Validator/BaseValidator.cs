using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.BusinessLogic.Validator
{
    public class BaseValidator
    {
        public BaseValidator()
        {
            Errors = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Errors { get; set; }
    }
}
