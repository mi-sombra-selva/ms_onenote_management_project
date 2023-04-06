using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RootObjectReference3FNDParser : FileNodeBaseParser
    {
        internal override RootObjectReference3FND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var rootObjectReference3FND = new RootObjectReference3FND();
            var index = startIndex;
            rootObjectReference3FND.oidRoot = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            index += ExtendedGUID.totalSize;
            rootObjectReference3FND.RootRole = reader.ReadUInt32FromPosition(index);
            return rootObjectReference3FND;
        }
    }
}
