namespace BitManipulator.Tests
{
    [TestClass]
    public class BitTests
    {
        [TestMethod]
        public void TestSetBit()
        {
            var array = new byte[] { 0x01, 0x02, 0x04, 0x08 };
            var bit = 6;

            Bit.SetBit(array, bit);

            Assert.AreEqual(array[0], 0x41);
            Assert.AreEqual(array[1], 0x02);
            Assert.AreEqual(array[2], 0x04);
            Assert.AreEqual(array[3], 0x08);
        }

        [TestMethod]
        public void TestClearBit()
        {
            var array = new byte[] { 255 };
            long bit = 7;

            Bit.ClearBit(array, bit);

            Assert.AreEqual(127, array[0]);
        }
    }
}
