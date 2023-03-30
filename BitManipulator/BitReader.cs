using System.Collections;

namespace BitManipulator
{
    internal sealed class BitReader : IEnumerator<bool>
    {
        private byte[] byteArray;
        private long startPosition;
        private long offset;
        private long length;

        internal BitReader(byte[] array, int index)
        {
            byteArray = array;
            offset = (long)index * 8 - 1;
            startPosition = offset;
            length = (long)array.Length * 8;
        }

        public bool Current => Bit.IsBitSet(byteArray, offset);

        object IEnumerator.Current => Current;

        public void Dispose() => byteArray = null;

        public bool MoveNext() => ++offset < length;

        public void Reset() => offset = startPosition;

        internal uint ReadUInt32(int readingLength)
        {
            var uint32Bytes = GetBytes(readingLength, 4);
            return unchecked((uint)ConvertFromBytes(uint32Bytes, 0, 4));
        }

        internal int ReadInt32(int readingLength)
        {
            var uint32Bytes = GetBytes(readingLength, 4);
            return unchecked((int)ConvertFromBytes(uint32Bytes, 0, 4));
        }

        private byte[] GetBytes(int needReadlength, int size)
        {
            var retBytes = new byte[size];
            var i = 0;
            while (i < needReadlength)
            {
                if (!MoveNext())
                {
                    throw new InvalidOperationException("Unexpected to meet the byte array end.");
                }

                if (Current)
                {
                    Bit.SetBit(retBytes, i);
                }
                else
                {
                    Bit.ClearBit(retBytes, i);
                }

                i++;
            }

            return retBytes;
        }
        private static ulong ConvertFromBytes(byte[] buffer, int startIndex, int bytesToConvert)
        {
            ulong ret = 0;
            var bitCount = 0;
            for (var i = 0; i < bytesToConvert; i++)
            {
                ret |= (ulong)buffer[startIndex + i] << bitCount;

                bitCount += 8;
            }

            return ret;
        }
    }
}
