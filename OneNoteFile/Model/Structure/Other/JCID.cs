namespace OneNoteFile.Model.Structure.Other
{
    internal class JCID
    {
        internal const int totalSize = 4;

        internal int Index { get; set; }
        internal int IsBinary { get; set; }
        internal int IsPropertySet { get; set; }
        internal int IsGraphNode { get; set; }
        internal int IsFileData { get; set; }
        internal int IsReadOnly { get; set; }
        internal int Reserved { get; set; }
    }
}
