using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class RevisionRoleAndContextDeclarationFND : IFileNodeBase
    {
        internal RevisionRoleDeclarationFND Base { get; set; }
        internal ExtendedGUID gctxid { get; set; }
    }
}
