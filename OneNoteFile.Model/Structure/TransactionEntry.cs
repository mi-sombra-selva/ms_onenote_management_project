namespace OneNoteFile.Model.Structure
{
    internal class TransactionEntry
    {
        internal const int srcIDSize = 4;
        internal const int TransactionEntrySwitchSize = 4;
        internal const int totalSize = srcIDSize + TransactionEntrySwitchSize;

        internal uint srcID { get; set; }
        internal uint TransactionEntrySwitch { get; set; }
    }
}
