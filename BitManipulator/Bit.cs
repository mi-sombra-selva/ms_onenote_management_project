namespace BitManipulator
{
    internal static class Bit
    {
        internal static bool IsBitSet(byte[] array, long bit)
        {
            return (array[bit / 8] & 1 << (int)(bit % 8)) != 0;
        }

        internal static void SetBit(byte[] array, long bit)
        {
            array[bit / 8] |= unchecked((byte)(1 << (int)(bit % 8)));
        }

        internal static void ClearBit(byte[] array, long bit)
        {
            array[bit / 8] &= unchecked((byte)~(1 << (int)(bit % 8)));
        }
    }
}
