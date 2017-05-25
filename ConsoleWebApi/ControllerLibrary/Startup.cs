using ControllerLibrary.Common;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ControllerLibrary
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            // Web API 配置和服务
            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //处理DateTime类型序列化后含有T的问题
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Insert(0, new JsonDateTimeConverter());
            //允许跨域
            var cors = new EnableCorsAttribute("http://localhost:3333,http://localhost:2581,http://localhost:3722", "*", "*");
            config.EnableCors(cors);
            appBuilder.UseWebApi(config);
        }
    }
}
