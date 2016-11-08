namespace Binarysharp.FasmProxy.HostingService
{
    /// <summary>
    /// An abstract way to represent a hosting of a given service.
    /// </summary>
    public interface IHostingService
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
