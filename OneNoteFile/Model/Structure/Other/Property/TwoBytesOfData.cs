namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class TwoBytesOfData : IProperty
    {
        public int Size => 2;

        internal byte[] Data { get; set; }

        public void CalculateSize()
        {
        }
    }
}
