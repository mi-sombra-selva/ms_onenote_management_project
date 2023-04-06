using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionRoleDeclarationFNDParser : FileNodeBaseParser
    {
        internal override RevisionRoleDeclarationFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var revisionRoleDeclarationFND = new RevisionRoleDeclarationFND();
            var index = startIndex;
            revisionRoleDeclarationFND.rid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            index += ExtendedGUID.totalSize;
            revisionRoleDeclarationFND.RevisionRole = reader.ReadBytes(index, RevisionRoleDeclarationFND.RevisionRoleSize);
            return revisionRoleDeclarationFND;
        }
    }
}
