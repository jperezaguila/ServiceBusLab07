using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;

namespace ServiceBusLab07
{
    class Program
    {
        static void Main(string[] args)
        {
            var host=new ServiceHost(typeof(ServicioSaludo));
            host.AddServiceEndpoint(typeof (IServicioSaludo),
                new NetTcpBinding(), "net.tcp://localhost:6985/saludo");

            host.AddServiceEndpoint(typeof(IServicioSaludo), 
                new NetTcpRelayBinding(), 
                ServiceBusEnvironment.CreateServiceUri
                ("sb", "namespacelab07", "saludo")).Behaviors.Add(new TransportClientEndpointBehavior()
            {
                    TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner", "Lkulzq9ddCEIT53k0cvGuE33+mFB2K5ppyyRivkww2E=")
            });
            host.Open();
            Console.WriteLine("Terminar...");
            Console.ReadLine();
            host.Close();
        }
    }
}
