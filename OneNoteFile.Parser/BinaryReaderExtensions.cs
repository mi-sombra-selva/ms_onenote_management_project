namespace OneNoteFile.Parser
{
    public static class BinaryReaderExtensions
    {
        public static int ReadInt32FromPosition(this BinaryReader reader, long position)
        {
            var currentPosition = reader.BaseStream.Position;
            reader.BaseStream.Seek(position, SeekOrigin.Begin);
            var result = reader.ReadInt32();
            reader.BaseStream.Seek(currentPosition, SeekOrigin.Begin);
            return result;
        }

        public static ushort ReadUInt16FromPosition(this BinaryReader reader, long position)
        {
            var currentPosition = reader.BaseStream.Position;
            reader.BaseStream.Seek(position, SeekOrigin.Begin);
            var result = reader.ReadUInt16();
            reader.BaseStream.Seek(currentPosition, SeekOrigin.Begin);
            return result;
        }

        public static uint ReadUInt32FromPosition(this BinaryReader reader, long position)
        {
            var currentPosition = reader.BaseStream.Position;
            reader.BaseStream.Seek(position, SeekOrigin.Begin);
            var result = reader.ReadUInt32();
            reader.BaseStream.Seek(currentPosition, SeekOrigin.Begin);
            return result;
        }

        public static ulong ReadUInt64FromPosition(this BinaryReader reader, long position)
        {
            var currentPosition = reader.BaseStream.Position;
            reader.BaseStream.Seek(position, SeekOrigin.Begin);
            var result = reader.ReadUInt64();
            reader.BaseStream.Seek(currentPosition, SeekOrigin.Begin);
            return result;
        }

        public static byte ReadByteFromPosition(this BinaryReader reader, long position)
        {
            var currentPosition = reader.BaseStream.Position;
            reader.BaseStream.Seek(position, SeekOrigin.Begin);
            var result = reader.ReadByte();
            reader.BaseStream.Seek(currentPosition, SeekOrigin.Begin);
            return result;
        }

        public static byte[] ReadBytes(this BinaryReader reader, long position, int count)
        {
            var originalPosition = reader.BaseStream.Position;

            try
            {
                reader.BaseStream.Seek(position, SeekOrigin.Begin);
                return reader.ReadBytes(count);
            }
            finally
            {
                reader.BaseStream.Seek(originalPosition, SeekOrigin.Begin);
            }
        }
    }
}
