namespace OneNoteFile.Model.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamHeader
    {
        internal const int totalSize = 4;

        internal uint Count { get; set; }
        internal int Reserved { get; set; }
        internal int ExtendedStreamsPresent { get; set; }
        internal int OsidStreamNotPresent { get; set; }
    }
}
