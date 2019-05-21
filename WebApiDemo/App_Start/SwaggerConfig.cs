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
            //������Ŀ��ַ������ҵ����ɵ�xml��ַ
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebApiDemo");
                        //ͨ���˷������ڷ������ƺ�����ʾ��Ӧ��ע����Ϣ������Ŀ���Ե����������xml�ļ���Ȼ������߷ŵ���������У�ע����Ϣ��summary������
                        c.IncludeXmlComments(commentsFile);
                    })
                .EnableSwaggerUi(c =>
                    {
                        //����swagger���裬1������swagger.js�ļ�2���ڴ��ļ�������������һ�д��룬WebApiDemo.Scripts.swagger.js�ֱ�����Ŀ����.�ļ�������.js�ļ�����3���Ҽ�swagger.js,���������޸����ɲ������ĳ�Ƕ�����Դ
                        c.InjectJavaScript(Assembly.GetExecutingAssembly(), "WebApiDemo.Scripts.swagger.js");
                    });
        }
    }
}
