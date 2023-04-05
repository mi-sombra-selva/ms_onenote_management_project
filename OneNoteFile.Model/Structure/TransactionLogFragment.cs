using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure
{
    internal class TransactionLogFragment
    {
        internal TransactionEntry[] sizeTable { get; set; }
        internal FileChunkReference64x32 nextFragment { get; set; }
    }
}
