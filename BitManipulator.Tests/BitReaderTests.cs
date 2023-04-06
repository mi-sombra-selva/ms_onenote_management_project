namespace BitManipulator.Tests
{
    [TestClass]
    public class BitReaderTests
    {
        [TestMethod]
        public void TestConvertFromBytes()
        {
            var buffer = new byte[] { 0xFF, 0x01, 0x00, 0x80 };
            ulong expected = 0x800001FF;
            var result = BitReader.ConvertFromBytes(buffer, 0, buffer.Length);

            Assert.AreEqual(expected, result);
        }
    }
}