namespace OneNoteFile.Model.Structure.Other.Property
{
    internal interface IProperty
    {
        int Size { get; }
        void CalculateSize();
    }
}
