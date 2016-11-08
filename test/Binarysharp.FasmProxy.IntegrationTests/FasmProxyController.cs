using System;
using System.Diagnostics;
using System.ServiceModel;
using Binarysharp.MemoryManagement.Assembly.Assembler;

namespace Binarysharp.FasmProxy.IntegrationTests
{
    /// <summary>
    /// An helper class for integration testing.
    /// </summary>
    public class FasmProxyController : IDisposable
    {
        /// <summary>
        /// Reference the process of FasmProxy.
        /// </summary>
        private readonly Process _process;

        /// <summary>
        /// The URI of the WCF endpoint.
        /// </summary>
        private readonly string _uri;

        /// <summary>
        /// Initializes a new instance of the <see cref="FasmProxyController"/> class and starts a new process of type FasmProxy.
        /// </summary>
        public FasmProxyController(string uri)
        {
            _process = Process.Start("Binarysharp.FasmProxy.exe");
            _uri = uri;
        }

        /// <summary>
        /// Gets the hosted assembler service.
        /// </summary>
        public IHostedAssembler GetHostedAssembler()
        {
            Debugger.Break();

            var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            var ep = new EndpointAddress(_uri);

            return ChannelFactory<IHostedAssembler>.CreateChannel(binding, ep);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// Terminates the process of type FasmProxy.
        /// </summary>
        public void Dispose()
        {
            _process.Kill();
        }
    }
}
