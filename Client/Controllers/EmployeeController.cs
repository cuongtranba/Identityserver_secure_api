using System.Web.Http;

namespace Client.Controllers
{
    //[Authorize(Roles = "employee")]
    //[Authorize]
    public class EmployeeController : ApiController
    {
        public IHttpActionResult Create()
        {
            return Ok("create ok");
        }

        public IHttpActionResult Edit()
        {
            return Ok("create ok");
        }

        public IHttpActionResult Delete()
        {
            return Ok("create ok");
        }
        public IHttpActionResult Get()
        {
            return Ok("create ok");
        }
    }
}
