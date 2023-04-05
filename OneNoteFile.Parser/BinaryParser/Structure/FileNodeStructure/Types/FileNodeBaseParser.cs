using OneNoteFile.Model.Structure.FileNodeStructure.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal abstract class FileNodeBaseParser
    {
        internal abstract IFileNodeBase DoDeserializeFromByteArray(byte[] byteArray, int startIndex);
    }
}
