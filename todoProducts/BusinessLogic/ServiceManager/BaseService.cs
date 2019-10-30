using System;
using System.Threading.Tasks;
using todoProducts.BusinessLogic.Request;
using todoProducts.BusinessLogic.Response;
using todoProducts.DataAccess.Context;
using todoProducts.DataAccess.UnitOfWork;
using todoProducts.Logger;

namespace todoProducts.BusinessLogic.ServiceManager
{
    public class BaseService
    {
        protected readonly ILoggerManager _logger;
        protected readonly IMongoContext _context;

        public BaseService(ILoggerManager logger, IMongoContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected async Task RunCodeAsync(string methodeInfo, BaseRequest request, BaseResponse response, Func<UnitOfWork, Task> action)
        {
            using (var uow = new UnitOfWork(_context))
            {
                try
                {
                    _logger.LogInfo($"RequestId: {request.RequestId.ToString()} Call: {methodeInfo} at {DateTime.Now}");

                    request.Validate();
                    if (request.Errors.Count != 0)
                        response.Errors = request.Errors;

                    if (request.Errors.Count == 0 || response.Errors.Count == 0)
                    {
                        await action(uow);
                        _logger.LogInfo($"Finish: {methodeInfo} at {DateTime.Now}");
                    }

                    if (response.Errors.Count != 0)
                    {
                        foreach (var err in response.Errors)
                        {
                            _logger.LogError($"Response Error in: {methodeInfo}, Error message: Key {err.Key} Value: {err.Value}");
                        }
                    }
                    else
                    {
                        response.Success = true;
                    }
                }
                catch (Exception ex)
                {
                    response.Errors.Add("System Exception", ex.Message);
                    _logger.LogError($"Exception: {methodeInfo} at {DateTime.Now}, Exception message: {ex.Message + ex.StackTrace}");
                }
            }
        }
    }
}