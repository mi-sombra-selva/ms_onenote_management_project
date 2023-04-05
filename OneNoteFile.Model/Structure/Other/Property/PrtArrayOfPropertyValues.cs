namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class PrtArrayOfPropertyValues : IProperty
    {
        private int size;

        internal const int CPropertiesSize = 2;
        internal const int RgPridSize = PropertyID.totalSize;

        public int Size
        {
            get
            {
                CalculateSize();
                return size;
            }
        }

        internal uint CProperties { get; set; }
        internal PropertyID Prid { get; set; }
        internal PropertySet[] Data { get; set; }

        public void CalculateSize()
        {
            size = CPropertiesSize + RgPridSize + Data.Sum(d => d.Size);
        }
    }
}
