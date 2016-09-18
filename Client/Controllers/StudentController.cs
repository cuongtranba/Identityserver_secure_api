using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Client.Controllers
{
    public class StudentController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("get student ok");
        }
        public IHttpActionResult Delete()
        {
            return Ok("Delete student ok");
        }
        public IHttpActionResult Create()
        {
            return Ok("Create student ok");
        }
        public IHttpActionResult Update()
        {
            return Ok("Update student ok");
        }
    }
}
