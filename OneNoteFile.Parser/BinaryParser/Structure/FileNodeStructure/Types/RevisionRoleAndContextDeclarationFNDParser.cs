﻿using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionRoleAndContextDeclarationFNDParser : FileNodeBaseParser
    {
        internal override RevisionRoleAndContextDeclarationFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var revisionRoleAndContextDeclarationFND = new RevisionRoleAndContextDeclarationFND();
            var index = startIndex;
            revisionRoleAndContextDeclarationFND.Base = new RevisionRoleDeclarationFNDParser().DoDeserializeFromByteArray(reader, index);
            index += RevisionRoleDeclarationFND.totalSize;
            revisionRoleAndContextDeclarationFND.gctxid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            return revisionRoleAndContextDeclarationFND;
        }
    }
}
