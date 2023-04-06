using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestRootFNDParser : FileNodeBaseParser
    {
        internal override ObjectSpaceManifestRootFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectSpaceManifestRootFND = new ObjectSpaceManifestRootFND();
            objectSpaceManifestRootFND.gosidRoot = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, startIndex);
            return objectSpaceManifestRootFND;
        }
    }
}
