namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class ArrayNumber : IProperty
    {
        public int Size => 4;

        internal uint Number { get; set; }

        public void CalculateSize()
        {
        }
    }
}
