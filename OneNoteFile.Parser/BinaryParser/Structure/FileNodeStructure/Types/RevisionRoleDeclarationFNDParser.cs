using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionRoleDeclarationFNDParser : FileNodeBaseParser
    {
        internal override RevisionRoleDeclarationFND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var revisionRoleDeclarationFND = new RevisionRoleDeclarationFND();
            var index = startIndex;
            revisionRoleDeclarationFND.rid = ExtendedGUIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += ExtendedGUID.totalSize;
            revisionRoleDeclarationFND.RevisionRole = new byte[RevisionRoleDeclarationFND.RevisionRoleSize];
            Array.Copy(byteArray, index, revisionRoleDeclarationFND.RevisionRole, 0, RevisionRoleDeclarationFND.RevisionRoleSize);
            return revisionRoleDeclarationFND;
        }
    }
}
