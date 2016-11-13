using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Binarysharp.FasmProxy.HostingService
{
    /// <summary>
    /// Hosts a given service using named pipes.
    /// </summary>
    /// <typeparam name="THostedService">The type of hosted service.</typeparam>
    public class NamedPipeService<THostedService> : IHostingService
    {
        public const string UriPrefix = "net.pipe://localhost/";
        protected ServiceHost ServiceHost;
        protected bool IsRunning;

        /// <summary>
        /// Starts the hosted service with the specified channel name.
        /// </summary>
        /// <param name="channelName">Name of the channel.</param>
        public void Start(string channelName)
        {
            if (IsRunning)
            {
                Stop();
            }

            InitializeNamedPipeListener(channelName);
        }

        /// <summary>
        /// Stops the hosted service. The service has to be started before.
        /// </summary>
        public void Stop()
        {
            if (IsRunning)
            {
                ServiceHost.Close(TimeSpan.FromSeconds(10));
            }
        }

        /// <summary>
        /// Initializes the named pipe listener.
        /// </summary>
        /// <param name="channelName">Name of the channel.</param>
        private void InitializeNamedPipeListener(string channelName)
        {
            var uri = $"{UriPrefix}{typeof(THostedService).Name}/{channelName}";
            ServiceHost = new ServiceHost(typeof(THostedService));
            var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None)
            {
                // The two values must have the same size, as the transferMode is Buffered by default
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };

            ServiceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            ServiceHost.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
            ServiceHost.AddServiceEndpoint(typeof(THostedService).GetInterfaces().First(), binding, uri);
            ServiceHost.Open();
        }
    }
}
