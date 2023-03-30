using BitManipulator;

namespace OneNoteFile.Structure.Other
{
    internal class JCID
    {
        public int Index { get; set; }

        public int IsBinary { get; set; }

        public int IsPropertySet { get; set; }

        public int IsGraphNode { get; set; }

        public int IsFileData { get; set; }

        public int IsReadOnly { get; set; }

        public int Reserved { get; set; }

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
