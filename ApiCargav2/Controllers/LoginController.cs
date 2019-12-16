using ApiCargav2.Handlers;
using ApiCargav2.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ApiCargav2.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private readonly ILogger _logger;

        public LoginController()
        {
            _logger = GlobalErrorLogger.logger;
        }

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        
        {
            _logger.Information("Me voy a caer");
            throw new Exception("Me caí");
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            bool isCredentialValid = (login.GetPassword() == "123456");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.GetUsername());
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}