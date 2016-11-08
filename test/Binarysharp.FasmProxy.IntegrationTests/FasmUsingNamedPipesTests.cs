using System;
using System.Diagnostics;
using Binarysharp.FasmProxy.HostedServices;
using Binarysharp.FasmProxy.HostingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binarysharp.FasmProxy.IntegrationTests
{
    [TestClass]
    public class FasmUsingNamedPipesTests
    {
        private readonly string _uri = $"{NamedPipeService<object>.UriPrefix}/{typeof(FasmHostedAssembler).Name}/{Process.GetCurrentProcess().Id}";

        [TestMethod]
        public void Assemble_SubmitAssemblyOpcode_ShouldReturnAssemblyByteCode()
        {
            // Arrange
            var asm = "use32\npush eax";
            byte[] result;

            // Act
            using (var proxy = new FasmProxyController(_uri))
            {
                result = proxy.GetHostedAssembler().Assemble(asm, IntPtr.Zero);
            }

            // Assert
            CollectionAssert.AreEqual(new byte[] { 0x50 }, result);
        }
    }
}
