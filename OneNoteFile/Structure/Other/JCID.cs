using BitManipulator;

namespace OneNoteFile.Structure.Other
{
    internal class JCID
    {
        internal int Index { get; set; }
        internal int IsBinary { get; set; }
        internal int IsPropertySet { get; set; }
        internal int IsGraphNode { get; set; }
        internal int IsFileData { get; set; }
        internal int IsReadOnly { get; set; }
        internal int Reserved { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            using (var bitReader = new BitReader(byteArray, startIndex))
            {
                Index = bitReader.ReadInt32(16);
                IsBinary = bitReader.ReadInt32(1);
                IsPropertySet = bitReader.ReadInt32(1);
                IsGraphNode = bitReader.ReadInt32(1);
                IsFileData = bitReader.ReadInt32(1);
                IsReadOnly = bitReader.ReadInt32(1);
                Reserved = bitReader.ReadInt32(11);

                return 4;
            }
        }
    }
}
