using OneNoteFile.Model.Structure;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class TransactionLogFragmentParser
    {
        private readonly uint size = 0;
        internal TransactionLogFragmentParser(uint size)
        {
            this.size = size;
        }

        internal TransactionLogFragment DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var transactionLogFragment = new TransactionLogFragment();

            var index = startIndex;
            var count = ((size - 12) / 8);
            transactionLogFragment.sizeTable = new TransactionEntry[count];

            for (var i = 0; i < count; i++)
            {
                transactionLogFragment.sizeTable[i] = TransactionEntryParser.DoDeserializeFromByteArray(byteArray, index);
                index += TransactionEntry.totalSize;
            }

            transactionLogFragment.nextFragment = new FileChunkReference64x32Parser().DoDeserializeFromByteArray(byteArray, index);

            return transactionLogFragment;
        }
    }
}
