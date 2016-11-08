using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binarysharp.FasmProxy.IntegrationTests
{
    [TestClass]
    public class WcfCommunicationTests
    {
        [TestMethod]
        public void SimpleCall_ShouldReturnAssemblyBytes()
        {
            // Arrange
            var asm = "use32\npush eax";
            byte[] result;

            // Act
            using (var proxy = new FasmProxyController())
            {
                result = proxy.GetHostedAssembler().Assemble(asm, IntPtr.Zero);
            }

            // Assert
            CollectionAssert.AreEqual(new byte[] { 0x50 }, result);
        }
    }
}
