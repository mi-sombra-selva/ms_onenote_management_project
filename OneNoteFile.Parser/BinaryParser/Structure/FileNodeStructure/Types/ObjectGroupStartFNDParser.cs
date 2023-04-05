using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectGroupStartFNDParser : FileNodeBaseParser
    {
        internal override ObjectGroupStartFND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectGroupStartFND = new ObjectGroupStartFND();
            objectGroupStartFND.oid = ExtendedGUIDParser.DoDeserializeFromByteArray(byteArray, startIndex);
            return objectGroupStartFND;
        }
    }
}
