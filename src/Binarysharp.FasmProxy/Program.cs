using System;
using Binarysharp.FasmProxy.HostedServices;

namespace Binarysharp.FasmProxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostedServicesController.StartAll("dummy");
            Console.Read();
        }
    }
}
