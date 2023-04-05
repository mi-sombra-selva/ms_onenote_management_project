namespace OneNoteFile.Model.Structure.Other.Property
{
    internal class PropertyID
    {
        internal const int totalSize = 4;

        internal uint Id { get; set; }
        internal uint Type { get; set; }
        internal int BoolValue { get; set; }
        internal int Value { get; set; }
    }
}
