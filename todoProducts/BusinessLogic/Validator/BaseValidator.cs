using System.Collections.Generic;

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