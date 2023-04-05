using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestStart6FND : IFileNodeBase
    {
        internal const int ridSize = ExtendedGUID.totalSize;
        internal const int ridDependentSize = ExtendedGUID.totalSize;
        internal const int RevisionRoleSize = 4;
        internal const int odcsDefaultSize = 2;
        internal const int totalSize = ridSize + ridDependentSize + RevisionRoleSize + odcsDefaultSize;

        internal ExtendedGUID rid { get; set; }
        internal ExtendedGUID ridDependent { get; set; }
        internal int RevisionRole { get; set; }
        internal ushort odcsDefault { get; set; }
    }
}
