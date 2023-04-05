using OneNoteFile.Model.Structure.FileNodeStructure;

namespace OneNoteFile.Model.Structure
{
    internal class ObjectSpaceManifestList
    {
        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }
        internal List<RevisionManifestList> RevisionManifestList { get; set; }
        internal List<FileNode> FileNodeSequence { get; set; }

        internal ObjectSpaceManifestList()
        {
            FileNodeListFragments = new List<FileNodeListFragment>();
            RevisionManifestList = new List<RevisionManifestList>();
            FileNodeSequence = new List<FileNode>();
        }
    }
}
