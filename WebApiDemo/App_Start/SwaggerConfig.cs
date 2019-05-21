using System.Web.Http;
using WebActivatorEx;
using WebApiDemo;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiDemo
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            //查找项目地址，最后找到生成的xml地址
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebApiDemo");
                        //通过此方法可在方法名称后面显示相应的注释信息，在项目属性的生成中输出xml文件，然后在这边放到这个方法中，注释信息用summary包起来
                        c.IncludeXmlComments(commentsFile);
                    })
                .EnableSwaggerUi(c =>
                    {
                        //汉化swagger步骤，1、增加swagger.js文件2、在此文件中增加下面这一行代码，WebApiDemo.Scripts.swagger.js分别是项目名称.文件夹名称.js文件名称3、右键swagger.js,在属性中修改生成操作，改成嵌入的资源
                        c.InjectJavaScript(Assembly.GetExecutingAssembly(), "WebApiDemo.Scripts.swagger.js");
                    });
        }
    }
}
