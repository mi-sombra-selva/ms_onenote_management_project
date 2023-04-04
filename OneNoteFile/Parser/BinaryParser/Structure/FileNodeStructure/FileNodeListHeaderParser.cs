using OneNoteFile.Model.Structure.FileNodeStructure;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure
{
    internal class FileNodeListHeaderParser
    {
        internal static FileNodeListHeader DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var fileNodeListHeader = new FileNodeListHeader();
            var index = startIndex;
            fileNodeListHeader.uintMagic = BitConverter.ToUInt64(byteArray, index);
            index += FileNodeListHeader.uintMagicSize;
            fileNodeListHeader.FileNodeListID = BitConverter.ToUInt32(byteArray, index);
            index += FileNodeListHeader.FileNodeListIDSize;
            fileNodeListHeader.nFragmentSequence = BitConverter.ToUInt32(byteArray, index);
            return fileNodeListHeader;
        }
    }
}
