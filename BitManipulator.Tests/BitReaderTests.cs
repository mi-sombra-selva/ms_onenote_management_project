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

        [TestMethod]
        public void TestGetBytes_ReturnsExpectedBytes_WhenReadingLengthIsEqualToSize()
        {
            var array = new byte[] { 0b10000000 };
            var index = 0;
            var reader = new BitReader(array, index);

            var result = reader.GetBytes(8, 1);

            CollectionAssert.AreEqual(new byte[] { 0b10000000 }, result);
        }

        [TestMethod]
        public void TestGetBytes_ReturnsExpectedBytes_WhenReadingLengthIsLessThanSize()
        {
            var array = new byte[] { 0b10000001 };
            var index = 0;
            var reader = new BitReader(array, index);

            var result = reader.GetBytes(1, 1);

            CollectionAssert.AreEqual(new byte[] { 0b00000001 }, result);
        }

        [TestMethod]
        public void TestGetBytes_ThrowsException_WhenReadingLengthIsGreaterThanSize()
        {
            var array = new byte[] { 0b10000001 };
            var index = 0;
            var reader = new BitReader(array, index);

            Assert.ThrowsException<InvalidOperationException>(() => reader.GetBytes(9, 1));
        }

        [TestMethod]
        public void TestReadInt32()
        {
            var byteArray = new byte[] { 0x30, 0x39 };

            var bitReader = new BitReader(byteArray, 0);

            var result = bitReader.ReadInt32(16);
            Assert.AreEqual(14640, result);
        }

        [TestMethod]
        public void TestReadUInt32()
        {
            var byteArray = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD };
            var bitReader = new BitReader(byteArray, 0);

            var result = bitReader.ReadUInt32(32);

            Assert.AreEqual((uint)0xDDCCBBAA, result);
        }
    }
}