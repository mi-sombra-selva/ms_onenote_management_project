using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectGroupStartFNDParser : FileNodeBaseParser
    {
        internal override ObjectGroupStartFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectGroupStartFND = new ObjectGroupStartFND();
            objectGroupStartFND.oid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, startIndex);
            return objectGroupStartFND;
        }
    }
}
