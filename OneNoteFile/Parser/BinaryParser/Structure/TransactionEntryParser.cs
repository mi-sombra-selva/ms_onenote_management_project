using OneNoteFile.Model.Structure;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class TransactionEntryParser
    {
        internal static TransactionEntry DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var transactionEntry = new TransactionEntry();
            var index = startIndex;
            transactionEntry.srcID = BitConverter.ToUInt32(byteArray, index);
            index += TransactionEntry.srcIDSize;
            transactionEntry.TransactionEntrySwitch = BitConverter.ToUInt32(byteArray, index);
            return transactionEntry;
        }
    }
}
