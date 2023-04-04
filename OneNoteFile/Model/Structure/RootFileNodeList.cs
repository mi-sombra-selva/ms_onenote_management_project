using OneNoteFile.Model.Structure.FileNodeStructure;

namespace OneNoteFile.Model.Structure
{
    internal class RootFileNodeList
    {
        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }
        internal FileNode ObjectSpaceManifestRoot { get; set; }
        internal List<FileNode> FileNodeSequence { get; set; }
        internal List<ObjectSpaceManifestList> ObjectSpaceManifestList { get; set; }

        internal RootFileNodeList()
        {
            FileNodeListFragments = new List<FileNodeListFragment>();
            ObjectSpaceManifestList = new List<ObjectSpaceManifestList>();
            FileNodeSequence = new List<FileNode>();
        }
    }
}
