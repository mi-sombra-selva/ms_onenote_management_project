using OneNoteFile.Model.Structure.FileNodeStructure.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class GlobalIdTableEntryFNDXParser : FileNodeBaseParser
    {
        internal override GlobalIdTableEntryFNDX DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var globalIdTableEntryFNDX = new GlobalIdTableEntryFNDX();
            globalIdTableEntryFNDX.index = BitConverter.ToUInt32(byteArray, startIndex);
            return globalIdTableEntryFNDX;
        }
    }
}
