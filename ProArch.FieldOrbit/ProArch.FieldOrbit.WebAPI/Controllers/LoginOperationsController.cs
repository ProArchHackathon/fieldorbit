using ProArch.FieldOrbit.Contracts.Security;
using ProArch.FieldOrbit.WebApi.Filters;
using ProArch.FieldOrbit.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProArch.FieldOrbit.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class LoginOperationsController : ApiController
    {
        private ILoginOperations loginOperations;

        public LoginOperationsController(ILoginOperations loginOperations)
        {
            this.loginOperations = loginOperations;
        }

        [HttpGet]
        [TraceLogActionFilterAttribute]
        public HttpResponseMessage Validate([FromUri]string username, [FromUri]string password)
        {
            return Request.CreateResponse(HttpStatusCode.OK, loginOperations.Validate(username, password));
        }

        [HttpGet]
        [TraceLogActionFilterAttribute]
        [Route("api/LoginOperations/GetUserDetails")]
        public HttpResponseMessage GetUserDetails([FromUri]string username, [FromUri]string password)
        {
            return Request.CreateResponse(HttpStatusCode.OK, loginOperations.GetUserInfo(username, password));
        }
    }
}
