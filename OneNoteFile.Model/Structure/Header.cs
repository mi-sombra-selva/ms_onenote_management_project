using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure
{
    internal class Header
    {
        internal FileChunkReference64x32 fcrTransactionLog { get; set; }
        internal FileChunkReference64x32 fcrFileNodeListRoot { get; set; }
    }
}
