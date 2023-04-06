using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal abstract class FileChunkReferenceParser
    {
        internal abstract FileChunkReference DoDeserializeFromByteArray(BinaryReader reader, int startIndex);
    }
}
