using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestListStartFNDParser : FileNodeBaseParser
    {
        internal override RevisionManifestListStartFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var revisionManifestListStartFND = new RevisionManifestListStartFND();
            var index = startIndex;
            revisionManifestListStartFND.gosid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            index += ExtendedGUID.totalSize;
            revisionManifestListStartFND.nInstance = reader.ReadBytes(index, 4);
            return revisionManifestListStartFND;
        }
    }
}
