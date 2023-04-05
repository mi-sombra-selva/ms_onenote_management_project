using OneNoteFile.Model.Structure.FileNodeStructure.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure
{
    internal class FileNode
    {
        internal const int FileNodePropertySize = 4;
        internal int FileNodeLen
        {
            get
            {
                return Size == 0 ? FileNodePropertySize : (int)Size;
            }
        }

        internal FileNodeIDValues FileNodeID { get; set; }

        internal uint Size { get; set; }

        internal uint StpFormat { get; set; }

        internal uint CbFormat { get; set; }

        internal uint BaseType { get; set; }

        internal uint Reserved { get; set; }

        internal IFileNodeBase fnd { get; set; }
    }
}
