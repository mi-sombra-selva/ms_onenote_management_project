using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure
{
    internal class FileNodeListFragment
    {
        internal FileNodeListHeader Header { get; set; }
        internal List<FileNode> rgFileNodes { get; set; }
        internal byte[] padding { get; set; }
        internal FileChunkReference64x32 nextFragment { get; set; }
        internal ulong footer { get; set; }
    }
}
