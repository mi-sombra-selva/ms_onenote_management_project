using OneNoteFile.Model.Structure.FileNodeStructure;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure
{
    internal class FileNodeListHeaderParser
    {
        internal static FileNodeListHeader DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var fileNodeListHeader = new FileNodeListHeader();
            var index = startIndex;
            fileNodeListHeader.uintMagic = reader.ReadUInt64FromPosition(index);
            index += FileNodeListHeader.uintMagicSize;
            fileNodeListHeader.FileNodeListID = reader.ReadUInt32FromPosition(index);
            index += FileNodeListHeader.FileNodeListIDSize;
            fileNodeListHeader.nFragmentSequence = reader.ReadUInt32FromPosition(index);
            return fileNodeListHeader;
        }
    }
}
