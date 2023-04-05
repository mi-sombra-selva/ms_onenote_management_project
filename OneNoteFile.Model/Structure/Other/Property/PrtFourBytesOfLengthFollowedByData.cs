namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class PrtFourBytesOfLengthFollowedByData : IProperty
    {
        private int size;

        internal const int CBSize = 4;

        public int Size
        {
            get
            {
                CalculateSize();
                return size;
            }
        }

        internal uint CB { get; set; }
        internal byte[] Data { get; set; }

        public void CalculateSize()
        {
            size = CBSize + (int)CB;
        }
    }
}
