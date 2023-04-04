using OneNoteFile.Model.Structure.FileNodeStructure;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure
{
    internal class FileNodeListFragmentParser
    {
        private ulong size;

        internal FileNodeListFragmentParser(ulong size)
        {
            this.size = size;
        }

        public FileNodeListFragment DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var fileNodeListFragment = new FileNodeListFragment();

            var index = startIndex;
            fileNodeListFragment.Header = FileNodeListHeaderParser.DoDeserializeFromByteArray(byteArray, index);
            index += FileNodeListHeader.totalSize;

            fileNodeListFragment.rgFileNodes = new List<FileNode>();
            var fileNodeSize = 0;
            var fileNodeCount = uint.MaxValue;
            if (OneNoteRevisionStoreFileParser.FileNodeCountMapping.ContainsKey(fileNodeListFragment.Header.FileNodeListID))
            {
                fileNodeCount = OneNoteRevisionStoreFileParser.FileNodeCountMapping[fileNodeListFragment.Header.FileNodeListID];
            }

            do
            {
                var fileNode = FileNodeParser.DoDeserializeFromByteArray(byteArray, index);
                index += fileNode.FileNodeLen;
                fileNodeSize += fileNode.FileNodeLen;
                if (fileNode.FileNodeID != 0)
                {
                    fileNodeListFragment.rgFileNodes.Add(fileNode);
                    if (fileNode.FileNodeID != FileNodeIDValues.ChunkTerminatorFND)
                    {
                        fileNodeCount--;
                    }
                }
            }
            while ((int)size - 36 - fileNodeSize > 4 && fileNodeCount > 0);

            if (OneNoteRevisionStoreFileParser.FileNodeCountMapping.ContainsKey(fileNodeListFragment.Header.FileNodeListID))
            {
                OneNoteRevisionStoreFileParser.FileNodeCountMapping[fileNodeListFragment.Header.FileNodeListID] = fileNodeCount;
            }

            var paddinglength = (int)size - 36 - fileNodeSize;
            fileNodeListFragment.padding = new byte[paddinglength];
            Array.Copy(byteArray, index, fileNodeListFragment.padding, 0, paddinglength);
            index += paddinglength;
            fileNodeListFragment.nextFragment = new FileChunkReference64x32Parser().DoDeserializeFromByteArray(byteArray, index);
            index += FileChunkReference64x32.totalSize;
            fileNodeListFragment.footer = BitConverter.ToUInt64(byteArray, index);

            return fileNodeListFragment;
        }
    }
}
