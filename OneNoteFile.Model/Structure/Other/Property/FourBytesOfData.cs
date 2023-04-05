namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class FourBytesOfData : IProperty
    {
        public int Size => 4;

        internal byte[] Data { get; set; }

        public void CalculateSize()
        {
        }
    }
}
