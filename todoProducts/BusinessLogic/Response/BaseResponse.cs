using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.BusinessLogic.Response
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Errors = new Dictionary<string, string>();
        }

        public bool Success { get; set; }
        public Dictionary<string,string> Errors { get; set; }
    }
}
