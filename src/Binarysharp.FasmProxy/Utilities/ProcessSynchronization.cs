using System.Diagnostics;
using System.Threading;
using Binarysharp.MemoryManagement.Assembly.Assembler;
using Binarysharp.MemoryManagement.Threading;

namespace Binarysharp.FasmProxy.Utilities
{
    public static class ProcessSynchronization
    {
        /// <summary>
        /// Gets the event signaling that the process can be shut down.
        /// </summary>
        public static InterProcessEventWaitHandle ExitEvent { get; private set; }

        /// <summary>
        /// Gets the event signaling that the proxy is ready to be consumed.
        /// </summary>
        public static InterProcessEventWaitHandle ReadyEvent { get; private set; }


        /// <summary>
        /// Initializes static members of the <see cref="ProcessSynchronization"/> class.
        /// </summary>
        static ProcessSynchronization()
        {
            InitializeSharedEvents();
        }

        public static void InitializeSharedEvents()
        {
            var parentProcessId = Process.GetCurrentProcess().GetParentProcessId().ToString();

            ExitEvent = new InterProcessEventWaitHandle(NamedPipeFasmProxy.ExitEventNamePrefix + parentProcessId, EventResetMode.AutoReset);
            ReadyEvent = new InterProcessEventWaitHandle(NamedPipeFasmProxy.ReadyEventNamePrefix + parentProcessId, EventResetMode.AutoReset);
        }
    }
}
