namespace OneNoteFile.Model.Types
{
    internal class FileChunkReference64x32 : FileChunkReference
    {
        internal const int StpSize = 8;
        internal const int CbSize = 4;
        internal const int totalSize = StpSize + CbSize;

        internal ulong Stp { get; set; }

        internal uint Cb { get; set; }

        internal override bool IsfcrNil()
        {
            return Stp == ulong.MaxValue && Cb == uint.MinValue;
        }

        internal override bool IsfcrZero()
        {
            return Stp == ulong.MinValue && Cb == uint.MinValue;
        }
    }
}
