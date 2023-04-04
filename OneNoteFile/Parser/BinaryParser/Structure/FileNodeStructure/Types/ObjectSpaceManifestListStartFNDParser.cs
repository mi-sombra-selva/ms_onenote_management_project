using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestListStartFNDParser : FileNodeBaseParser
    {
        internal override ObjectSpaceManifestListStartFND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectSpaceManifestListStartFND = new ObjectSpaceManifestListStartFND();
            objectSpaceManifestListStartFND.gosid = ExtendedGUIDParser.DoDeserializeFromByteArray(byteArray, startIndex);
            return objectSpaceManifestListStartFND;
        }
    }
}
