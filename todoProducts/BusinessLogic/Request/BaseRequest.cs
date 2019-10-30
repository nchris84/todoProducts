using System;
using todoProducts.BusinessLogic.Validator;

namespace todoProducts.BusinessLogic.Request
{
    public class BaseRequest : BaseValidator
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