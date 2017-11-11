using System.Web.Http;
using Serilog;

namespace WebApi.Framework.Controllers
{
    public class DataController : ApiController
    {
        private readonly ILogger _logger;

        public DataController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            _logger.Information("Stuff is working!");
            return Json($"{nameof(DataController)} is working!");
        }
    }
}
