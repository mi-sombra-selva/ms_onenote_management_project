using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class RevisionRoleDeclarationFND : FileNodeBase
    {
        internal ExtendedGUID rid { get; set; }
        internal byte[] RevisionRole { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            rid = new ExtendedGUID();
            var len = rid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            RevisionRole = new byte[4];
            Array.Copy(byteArray, index, RevisionRole, 0, 4);
            index += 4;

            return index - startIndex;
        }
    }
}
