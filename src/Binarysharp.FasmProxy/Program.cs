using System;
using System.Diagnostics;
using Binarysharp.FasmProxy.HostedServices;
using Binarysharp.FasmProxy.Utilities;

namespace Binarysharp.FasmProxy
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            InitializeHostedServices();

            Console.Read();

            HostedServicesController.StopAll();
        }

        /// <summary>
        /// Initializes the hosted services with the parent process id as a channel name.
        /// </summary>
        private static void InitializeHostedServices()
        {
            var parentProcessId = Process.GetCurrentProcess().GetParentProcessId().ToString();
            HostedServicesController.StartAll(parentProcessId);
        }
    }
}
