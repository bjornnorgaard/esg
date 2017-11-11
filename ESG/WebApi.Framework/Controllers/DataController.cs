using System.Web.Http;

namespace WebApi.Framework.Controllers
{
    public class DataController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json($"{nameof(DataController)} is working!");
        }
    }
}
