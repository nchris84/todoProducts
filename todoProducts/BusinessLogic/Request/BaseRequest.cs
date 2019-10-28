using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Validator;

namespace todoProducts.BusinessLogic.Request
{
    public class BaseRequest: BaseValidator
    {
        public Guid RequestId { get; set; }

        public BaseRequest()
        {
            RequestId = Guid.NewGuid();
        }

        public virtual void Validate()
        { }

    }
}
