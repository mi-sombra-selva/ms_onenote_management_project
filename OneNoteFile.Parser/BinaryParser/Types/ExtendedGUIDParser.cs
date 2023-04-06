using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal class ExtendedGUIDParser
    {
        public static ExtendedGUID DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var extendedGUID = new ExtendedGUID();
            var index = startIndex;
            var guidBuffer = reader.ReadBytes(index, 16);
            index += 16;
            extendedGUID.Guid = new Guid(guidBuffer);
            extendedGUID.N = reader.ReadUInt32FromPosition(index);
            return extendedGUID;
        }
    }
}
