namespace Binarysharp.FasmProxy.HostingService
{
    /// <summary>
    /// An abstract way to represent a hosting of a given service.
    /// </summary>
    /// <typeparam name="THostedService">The type of hosted service.</typeparam>
    public interface IHostingService<THostedService>
    {
        /// <summary>
        /// Starts the hosted service with the specified channel name.
        /// </summary>
        /// <param name="channelName">Name of the channel.</param>
        void Start(string channelName);

        /// <summary>
        /// Stops the hosted service. The service has to be started before.
        /// </summary>
        void Stop();
    }
}
