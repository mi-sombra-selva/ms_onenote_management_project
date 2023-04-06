using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestListStartFNDParser : FileNodeBaseParser
    {
        internal override ObjectSpaceManifestListStartFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectSpaceManifestListStartFND = new ObjectSpaceManifestListStartFND();
            objectSpaceManifestListStartFND.gosid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, startIndex);
            return objectSpaceManifestListStartFND;
        }
    }
}
