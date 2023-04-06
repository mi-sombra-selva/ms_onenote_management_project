namespace BitManipulator
{
    internal static class Bit
    {
        internal static bool IsBitSet(BinaryReader reader, long bit)
        {
            reader.BaseStream.Position = bit / 8;
            return (reader.ReadByte() & 1 << (int)(bit % 8)) != 0;
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
