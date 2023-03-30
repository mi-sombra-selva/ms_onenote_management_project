using OneNoteFile.Types;

namespace OneNoteFile.Structure
{
    internal class TransactionLogFragment
    {
        private uint size = 0;
        internal TransactionEntry[] sizeTable { get; set; }
        internal FileChunkReference64x32 nextFragment { get; set; }

        internal TransactionLogFragment(uint size)
        {
            this.size = size;
        }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            var count = ((size - 12) / 8);
            sizeTable = new TransactionEntry[count];
            var len = 0;
            for (var i = 0; i < count; i++)
            {
                sizeTable[i] = new TransactionEntry();
                len = sizeTable[i].DoDeserializeFromByteArray(byteArray, index);
                index += len;
            }

            nextFragment = new FileChunkReference64x32();
            len = nextFragment.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            return index - startIndex;
        }
    }
}
