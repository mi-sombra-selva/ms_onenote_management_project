using OneNoteFile.Model.Structure;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class TransactionEntryParser
    {
        internal static TransactionEntry DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var transactionEntry = new TransactionEntry();
            var index = startIndex;
            transactionEntry.srcID = reader.ReadUInt32FromPosition(index);
            index += TransactionEntry.srcIDSize;
            transactionEntry.TransactionEntrySwitch = reader.ReadUInt32FromPosition(index);
            return transactionEntry;
        }
    }
}
