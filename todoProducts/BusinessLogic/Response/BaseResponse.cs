using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Request;
using todoProducts.BusinessLogic.Validator;

namespace todoProducts.BusinessLogic.Response
{
    public class BaseResponse: BaseValidator
    {
        public bool Success { get; set; }
        
    }
}
