using OneNoteFile.Model.Structure.FileNodeStructure.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class GlobalIdTableEntryFNDXParser : FileNodeBaseParser
    {
        internal override GlobalIdTableEntryFNDX DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var globalIdTableEntryFNDX = new GlobalIdTableEntryFNDX();
            globalIdTableEntryFNDX.index = reader.ReadUInt32FromPosition(startIndex);
            return globalIdTableEntryFNDX;
        }
    }
}
