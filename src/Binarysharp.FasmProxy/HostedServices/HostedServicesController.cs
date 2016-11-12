using System.Diagnostics;
using Binarysharp.FasmProxy.HostingService;
using Binarysharp.FasmProxy.Utilities;

namespace Binarysharp.FasmProxy.HostedServices
{
    /// <summary>
    /// The reference for all the <see cref="IHostingService"/> in the proxy.
    /// </summary>
    public static class HostedServicesController
    {
        /// <summary>
        /// The name of the channel used in the hosted services.
        /// </summary>
        private static readonly string ChannelName = Process.GetCurrentProcess().GetParentProcessId().ToString();

        /// <summary>
        /// A collection that contains all the services hosted by the proxy.
        /// </summary>
        private static readonly IHostingService[] HostingServices =
        {
            new NamedPipeService<FasmHostedAssembler>()
        };

        /// <summary>
        /// Starts all the hosted services.
        /// </summary>
        public static void StartAll()
        {
            foreach (var hostingService in HostingServices)
            {
                hostingService.Start(ChannelName);
            }
        }

        /// <summary>
        /// Stops all the hosted services.
        /// </summary>
        public static void StopAll()
        {
            foreach (var hostingService in HostingServices)
            {
                hostingService.Stop();
            }
        }
    }
}
