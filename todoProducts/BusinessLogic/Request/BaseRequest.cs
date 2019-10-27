using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.BusinessLogic.Request
{
    public class BaseRequest
    {
        public Guid RequestId { get; set; }

        public BaseRequest()
        {
            RequestId = Guid.NewGuid();
        }
    }
}
