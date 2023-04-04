using OneNoteFile.Model.Structure.FileNodeStructure;

namespace OneNoteFile.Model.Structure
{
    internal class ObjectGroupList
    {
        internal List<FileNode> FileNodeSequence { get; set; }

        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }

        internal ObjectGroupList()
        {
            FileNodeSequence = new List<FileNode>();
            FileNodeListFragments = new List<FileNodeListFragment>();
        }
    }
}
