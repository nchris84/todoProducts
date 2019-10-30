using todoProducts.BusinessLogic.Validator;

namespace todoProducts.BusinessLogic.Response
{
    public class BaseResponse : BaseValidator
    {
        public bool Success { get; set; }
    }
}