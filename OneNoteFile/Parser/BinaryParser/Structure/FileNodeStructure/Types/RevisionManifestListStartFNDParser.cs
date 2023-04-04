using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestListStartFNDParser : FileNodeBaseParser
    {
        internal override RevisionManifestListStartFND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var revisionManifestListStartFND = new RevisionManifestListStartFND();
            var index = startIndex;
            revisionManifestListStartFND.gosid = ExtendedGUIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += ExtendedGUID.totalSize;
            revisionManifestListStartFND.nInstance = new byte[4];
            Array.Copy(byteArray, index, revisionManifestListStartFND.nInstance, 0, 4);
            return revisionManifestListStartFND;
        }
    }
}
