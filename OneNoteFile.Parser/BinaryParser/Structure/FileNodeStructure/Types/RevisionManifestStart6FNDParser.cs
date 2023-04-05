using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestStart6FNDParser : FileNodeBaseParser
    {
        internal override RevisionManifestStart6FND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var revisionManifestStart6FND = new RevisionManifestStart6FND();
            var index = startIndex;
            revisionManifestStart6FND.rid = ExtendedGUIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += ExtendedGUID.totalSize;
            revisionManifestStart6FND.ridDependent = ExtendedGUIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += ExtendedGUID.totalSize;
            revisionManifestStart6FND.RevisionRole = BitConverter.ToInt32(byteArray, index);
            index += 4;
            revisionManifestStart6FND.odcsDefault = BitConverter.ToUInt16(byteArray, index);
            return revisionManifestStart6FND;
        }
    }
}
