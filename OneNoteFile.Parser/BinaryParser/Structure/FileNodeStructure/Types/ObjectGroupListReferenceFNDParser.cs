using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectGroupListReferenceFNDParser : FileNodeBaseParser
    {
        private uint stpFormat;
        private uint cbFormat;

        internal ObjectGroupListReferenceFNDParser(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override ObjectGroupListReferenceFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectGroupListReferenceFND = new ObjectGroupListReferenceFND();
            var index = startIndex;
            objectGroupListReferenceFND.Ref = new FileNodeChunkReferenceParser(stpFormat, cbFormat).DoDeserializeFromByteArray(reader, index);
            index += objectGroupListReferenceFND.Ref.Size;
            objectGroupListReferenceFND.ObjectGroupID = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            return objectGroupListReferenceFND;
        }
    }
}
