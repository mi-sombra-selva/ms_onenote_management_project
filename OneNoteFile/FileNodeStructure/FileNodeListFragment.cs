using OneNoteFile.Structure;
using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure
{
    internal class FileNodeListFragment
    {
        private ulong size;

        internal FileNodeListHeader Header { get; set; }
        internal List<FileNode> rgFileNodes { get; set; }
        internal byte[] padding { get; set; }
        internal FileChunkReference64x32 nextFragment { get; set; }
        internal ulong footer { get; set; }

        internal FileNodeListFragment(ulong size)
        {
            this.size = size;
        }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Header = new FileNodeListHeader();
            var len = Header.DoDeserializeFromByteArray(byteArray, index);
            index += len;

            rgFileNodes = new List<FileNode>();
            var fileNodeSize = 0;
            var fileNodeCount = uint.MaxValue;
            if (OneNoteRevisionStoreFile.FileNodeCountMapping.ContainsKey(Header.FileNodeListID))
            {
                fileNodeCount = OneNoteRevisionStoreFile.FileNodeCountMapping[Header.FileNodeListID];
            }

            do
            {
                var fileNode = new FileNode();
                len = fileNode.DoDeserializeFromByteArray(byteArray, index);
                index += len;
                fileNodeSize += len;
                if (fileNode.FileNodeID != 0)
                {
                    rgFileNodes.Add(fileNode);
                    if (fileNode.FileNodeID != FileNodeIDValues.ChunkTerminatorFND)
                    {
                        fileNodeCount--;
                    }
                }
            }
            while ((int)size - 36 - fileNodeSize > 4 && fileNodeCount > 0);

            if (OneNoteRevisionStoreFile.FileNodeCountMapping.ContainsKey(Header.FileNodeListID))
            {
                OneNoteRevisionStoreFile.FileNodeCountMapping[Header.FileNodeListID] = fileNodeCount;
            }

            var paddinglength = (int)size - 36 - fileNodeSize;
            padding = new byte[paddinglength];
            Array.Copy(byteArray, index, padding, 0, paddinglength);
            index += paddinglength;
            nextFragment = new FileChunkReference64x32();
            len = nextFragment.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            footer = BitConverter.ToUInt64(byteArray, index);
            index += 8;

            return index - startIndex;
        }
    }
}
