using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal abstract class PropertyParser
    {
        internal abstract IProperty DoDeserializeFromByteArray(byte[] byteArray, int startIndex);
    }
}
