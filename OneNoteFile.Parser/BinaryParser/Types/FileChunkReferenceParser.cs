using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal abstract class FileChunkReferenceParser
    {
        internal abstract FileChunkReference DoDeserializeFromByteArray(byte[] byteArray, int startIndex);
    }
}
