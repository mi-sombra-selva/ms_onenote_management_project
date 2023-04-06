using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal class FileChunkReference64x32Parser : FileChunkReferenceParser
    {
        internal override FileChunkReference64x32 DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var fileChunkReference64x32 = new FileChunkReference64x32();
            var index = startIndex;
            fileChunkReference64x32.Stp = reader.ReadUInt64FromPosition(index);
            index += FileChunkReference64x32.StpSize;
            fileChunkReference64x32.Cb = reader.ReadUInt32FromPosition(index);
            return fileChunkReference64x32;
        }
    }
}
