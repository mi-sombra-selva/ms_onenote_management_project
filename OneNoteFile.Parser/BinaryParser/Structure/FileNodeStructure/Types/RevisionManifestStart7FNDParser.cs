using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestStart7FNDParser : FileNodeBaseParser
    {
        internal override RevisionManifestStart7FND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var revisionManifestStart7FND = new RevisionManifestStart7FND();
            var index = startIndex;
            revisionManifestStart7FND.Base = new RevisionManifestStart6FNDParser().DoDeserializeFromByteArray(reader, index);
            index += RevisionManifestStart6FND.totalSize;
            revisionManifestStart7FND.gctxid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            return revisionManifestStart7FND;
        }
    }
}
