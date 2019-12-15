using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ApiCargav2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration
                  .EnableSwagger(c =>
                  {
                      c.SingleApiVersion("v1", "SomosTechies API")
                  .Description("A sample API for testing")
                  .TermsOfService("Some terms")
              .Contact(cc => cc
                .Name("Felipe Calderon")
                .Url("NINGUNA")
                .Email("Felipe.Calderon02@gmail.com"))
              .License(lc => lc
                .Name("Some License")
                .Url("NINGUNA"));
                  })
              .EnableSwaggerUi();
        }
    }

}


