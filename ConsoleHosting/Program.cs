using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLib;

namespace ConsoleHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建宿主的基地址
            Uri baseAddress = new Uri("http://localhost:8833/Service1/");
            //创建宿主
            using (ServiceHost host=new ServiceHost(typeof(Service1),baseAddress))
            {
                 //向宿主添加终结点
                host.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), baseAddress);
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>()==null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = baseAddress;
                    //将行为添加到behaviors中
                    host.Description.Behaviors.Add(behavior);
                    //打开宿主

                    host.Opened += (sender, eventArgs) =>
                    {
                        Console.WriteLine("Service1控制台程序寄宿已经启动，HTTP监听已启动....，按任意键终止服务！");
                    };
                    host.Open();

                    Console.ReadLine();

                }
            }
        }
    }
}
