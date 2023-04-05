using OneNoteFile.Model.Structure.FileNodeStructure;

namespace OneNoteFile.Model.Structure
{
    internal class RevisionManifestList
    {
        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }
        internal List<ObjectGroupList> ObjectGroupList { get; set; }
        internal List<FileNode> FileNodeSequence { get; set; }

        internal RevisionManifestList()
        {
            FileNodeListFragments = new List<FileNodeListFragment>();
            ObjectGroupList = new List<ObjectGroupList>();
            FileNodeSequence = new List<FileNode>();
        }
    }
}
