using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace Client2
{
    [Route("Employee")]
    public class EmployeeController : ApiController
    {
        [ResourceAuthorize("GetEmployee", "Employee")]
        public IHttpActionResult Get()
        {
            return Ok("get employee ok");
        }
    }
}