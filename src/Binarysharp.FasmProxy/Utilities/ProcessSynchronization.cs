using System.Diagnostics;
using System.Threading;
using Binarysharp.MemoryManagement.Threading;

namespace Binarysharp.FasmProxy.Utilities
{
    public static class ProcessSynchronization
    {
        /// <summary>
        /// Gets the event signaling that the proxy is ready to be consumed.
        /// </summary>
        public static InterProcessEventWaitHandle ReadyEvent { get; private set; }

        /// <summary>
        /// Gets the event signaling that the process can be shut down.
        /// </summary>
        public static InterProcessEventWaitHandle ExitEvent { get; private set; }

        /// <summary>
        /// Initializes static members of the <see cref="ProcessSynchronization"/> class.
        /// </summary>
        static ProcessSynchronization()
        {
            var parentProcessId = Process.GetCurrentProcess().GetParentProcessId().ToString();

            ReadyEvent = new InterProcessEventWaitHandle("FasmProxy/Ready/" + parentProcessId, EventResetMode.AutoReset);
            ExitEvent = new InterProcessEventWaitHandle("FasmProxy/Exit/" + parentProcessId, EventResetMode.AutoReset);
        }
    }
}
