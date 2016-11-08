using System;
using System.Diagnostics;
using Binarysharp.MemoryManagement;

namespace Binarysharp.FasmProxy.Utilities
{
    /// <summary>
    /// Extensions for the class <see cref="Process"/>.
    /// </summary>
    public static class ProcessExtensions
    {
        /// <summary>
        /// Gets the identifier of the parent process.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <returns>The return value is the identifier of the parent process.</returns>
        /// <exception cref="System.Exception">Couldn't get the parent process id.</exception>
        public static int GetParentProcessId(this Process process)
        {
            try
            {
                return new MemorySharp(Process.GetCurrentProcess()).ParentProcess.Id;
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve the parent process identifier.");
            }
        }
    }
}
