namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class OneByteOfData : IProperty
    {
        public int Size => 1;

        internal byte Data { get; set; }

        public void CalculateSize()
        {
        }
    }
}
