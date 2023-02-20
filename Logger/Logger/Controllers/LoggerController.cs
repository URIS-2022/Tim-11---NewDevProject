using Logger.Controllers.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Logger.Controllers
{
    [Route("api/logger")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private static Serilog.Core.Logger _logger;

        public LoggerController() 
        {
            _logger = LoggerFactory.GetLoggerAsync();
        }

        [HttpPost]
        public void Log([FromBody] LogRequestDto request)
        {
            if (request.IsError) 
            {
                _logger.Error(request.Message);
            }
            else
            {
                _logger.Information(request.Message);
            }
        }
    }
}
