using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal class ExtendedGUIDParser
    {
        public static ExtendedGUID DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var extendedGUID = new ExtendedGUID();
            var index = startIndex;
            var guidBuffer = new byte[16];
            Array.Copy(byteArray, index, guidBuffer, 0, 16);
            index += 16;
            extendedGUID.Guid = new Guid(guidBuffer);
            extendedGUID.N = BitConverter.ToUInt32(byteArray, index);
            return extendedGUID;
        }
    }
}
