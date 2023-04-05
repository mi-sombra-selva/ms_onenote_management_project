namespace OneNoteFile.Model.Structure.FileNodeStructure
{
    internal class FileNodeListHeader
    {
        internal const int uintMagicSize = 8;
        internal const int FileNodeListIDSize = 4;
        internal const int nFragmentSequenceSize = 4;
        internal const int totalSize = uintMagicSize + FileNodeListIDSize + nFragmentSequenceSize;

        internal ulong uintMagic { get; set; }
        internal uint FileNodeListID { get; set; }
        internal uint nFragmentSequence { get; set; }
    }
}
