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
            HostedServicesController.StartAll();
            ProcessSynchronization.ReadyEvent.Set();
            ProcessSynchronization.ExitEvent.WaitOne();
            HostedServicesController.StopAll();
        }
    }
}
