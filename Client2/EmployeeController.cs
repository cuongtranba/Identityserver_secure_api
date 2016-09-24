using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace Client2
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        [Route("Get.Employee")]
        public IHttpActionResult GetEmployee()
        {
            return Ok("get employee ok");
        }

        [Route("Create.Employee")]
        [HttpPost]
        public IHttpActionResult CreateEmployee()
        {
            return Ok("create employee ok");
        }
    }
}