using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestStart6FNDParser : FileNodeBaseParser
    {
        internal override RevisionManifestStart6FND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var revisionManifestStart6FND = new RevisionManifestStart6FND();
            var index = startIndex;
            revisionManifestStart6FND.rid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            index += ExtendedGUID.totalSize;
            revisionManifestStart6FND.ridDependent = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            index += ExtendedGUID.totalSize;
            revisionManifestStart6FND.RevisionRole = reader.ReadInt32FromPosition(index);
            index += 4;
            revisionManifestStart6FND.odcsDefault = reader.ReadUInt16FromPosition(index);
            return revisionManifestStart6FND;
        }
    }
}
