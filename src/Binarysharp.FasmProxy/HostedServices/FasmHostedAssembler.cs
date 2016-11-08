using System;
using System.ServiceModel;
using Binarysharp.Assemblers.Fasm;
using Binarysharp.MemoryManagement.Assembly.Assembler;

namespace Binarysharp.FasmProxy.HostedServices
{
    /// <summary>
    /// A Fasm assembler implementation that communicates using WCF technologies.
    /// </summary>
    /// <remarks>
    /// As Farm assembler is not thread-safe (https://board.flatassembler.net/topic.php?t=6239), the instance mode of the WCF service
    /// is configured to use <see cref="InstanceContextMode.Single"/>. Thus, the service only handles a call at a time.
    /// More information for WCF concurrency and instancing here: https://msdn.microsoft.com/en-us/library/ms731193(v=vs.110).aspx
    /// and here: http://www.codeproject.com/Articles/89858/WCF-Concurrency-Single-Multiple-and-Reentrant-and#Instance%20mode%20=%20per%20session%20and%20Concurrency%20=%20single.
    /// </remarks>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FasmHostedAssembler : IHostedAssembler
    {
        /// <summary>
        /// Assemble the specified assembly code at a base address.
        /// </summary>
        /// <param name="asm">The assembly code.</param>
        /// <param name="baseAddress">The address where the code is rebased.</param>
        /// <returns>An array of bytes containing the assembly code.</returns>
        public byte[] Assemble(string asm, IntPtr baseAddress)
        {
            // Rebase the code
            asm = $"org 0x{baseAddress.ToInt64():X8}\n" + asm;

            // Assemble and return the code
            return FasmNet.Assemble(asm);
        }
    }
}
