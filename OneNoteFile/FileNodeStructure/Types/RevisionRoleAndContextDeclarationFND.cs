using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class RevisionRoleAndContextDeclarationFND : FileNodeBase
    {
        internal RevisionRoleDeclarationFND Base { get; set; }
        internal ExtendedGUID gctxid { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Base = new RevisionRoleDeclarationFND();
            var len = Base.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            gctxid = new ExtendedGUID();
            len = gctxid.DoDeserializeFromByteArray(byteArray, index);
            index += len;

            return index - startIndex;
        }
    }
}
