using System.Collections;

namespace BitManipulator
{
    internal sealed class BitReader : IEnumerator<bool>
    {
        private readonly BinaryReader _reader;
        private long _offset;
        private readonly long _length;
        private readonly long _startPosition;

        internal BitReader(BinaryReader reader, long index)
        {
            _reader = reader;
            _offset = (index * 8) - 1;
            _startPosition = _offset;
            _length = reader.BaseStream.Length * 8;
        }

        public bool Current => Bit.IsBitSet(_reader, _offset);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext() => ++_offset < _length;

        public void Reset() => _offset = _startPosition;

        internal int ReadInt32(int readingLength)
        {
            var uint32Bytes = GetBytes(readingLength, 4);
            return unchecked((int)ConvertFromBytes(uint32Bytes, 0, 4));
        }

        internal uint ReadUInt32(int readingLength)
        {
            var uint32Bytes = GetBytes(readingLength, 4);
            return unchecked((uint)ConvertFromBytes(uint32Bytes, 0, 4));
        }

        internal ulong ReadUInt64(int readingLength)
        {
            var uint64Bytes = GetBytes(readingLength, 8);
            return unchecked(ConvertFromBytes(uint64Bytes, 0, 8));
        }

        internal byte[] GetBytes(int needReadlength, int size)
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

        internal static ulong ConvertFromBytes(byte[] buffer, int startIndex, int bytesToConvert)
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
