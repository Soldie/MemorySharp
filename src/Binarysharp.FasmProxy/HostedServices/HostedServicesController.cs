using Binarysharp.FasmProxy.HostingService;

namespace Binarysharp.FasmProxy.HostedServices
{
    /// <summary>
    /// The reference for all the <see cref="IHostingService"/> in the proxy.
    /// </summary>
    public static class HostedServicesController
    {
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
        /// <param name="channelName">Name of the channel.</param>
        public static void StartAll(string channelName)
        {
            foreach (var hostingService in HostingServices)
            {
                hostingService.Start(channelName);
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
