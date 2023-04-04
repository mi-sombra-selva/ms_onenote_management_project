using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class RootObjectReference3FND : IFileNodeBase
    {
        internal ExtendedGUID oidRoot { get; set; }
        internal uint RootRole { get; set; }
    }
}
