using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class RevisionRoleDeclarationFND : IFileNodeBase
    {
        internal const int ridSize = ExtendedGUID.totalSize;
        internal const int RevisionRoleSize = 4;
        internal const int totalSize = ridSize + RevisionRoleSize;

        internal ExtendedGUID rid { get; set; }
        internal byte[] RevisionRole { get; set; }
    }
}
