namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class EightBytesOfData : IProperty
    {
        public int Size => 8;

        internal byte[] Data { get; set; }

        public void CalculateSize()
        {
        }
    }
}
