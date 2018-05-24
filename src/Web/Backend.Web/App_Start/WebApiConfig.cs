using Autofac;
using Autofac.Integration.WebApi;
using Backend.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Extensions;

namespace Backend.Web
{
    internal class WebApiConfig
    {
        internal static void Register(HttpConfiguration config)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            //var config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.Filters.Add(new BackendExceptionFilter());

            config.MapHttpAttributeRoutes();
            config.AddODataQueryFilter();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "AdminUi API");
                c.IncludeXmlComments(GetXmlCommentsPath());
            }).EnableSwaggerUi();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\Backend.Web.xml",
                        System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}