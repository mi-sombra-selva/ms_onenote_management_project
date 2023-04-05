namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class PropertySet : IProperty
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

        internal ushort CProperties { get; set; }
        internal PropertyID[] RgPrids { get; set; }
        internal List<IProperty> RgData { get; set; }

        public void CalculateSize()
        {
            size = CPropertiesSize + RgPridSize * RgPrids.Length + RgData.Sum(x => x.Size);
        }
    }
}
