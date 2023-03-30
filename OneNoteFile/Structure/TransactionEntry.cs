namespace OneNoteFile.Structure
{
    internal class TransactionEntry
    {
        internal uint srcID { get; set; }
        internal uint TransactionEntrySwitch { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            srcID = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            TransactionEntrySwitch = BitConverter.ToUInt32(byteArray, index);
            index += 4;

            return index - startIndex;
        }
    }
}
