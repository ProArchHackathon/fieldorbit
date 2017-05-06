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
        [Route("api/LoginOperations/Validate")]
        public HttpResponseMessage Validate()
        {
            return Request.CreateResponse(HttpStatusCode.OK, loginOperations.Validate());
        }
    }
}
