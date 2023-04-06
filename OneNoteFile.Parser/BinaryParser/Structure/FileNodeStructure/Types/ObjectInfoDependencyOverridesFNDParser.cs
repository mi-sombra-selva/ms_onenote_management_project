using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectInfoDependency;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectInfoDependencyOverridesFNDParser : FileNodeBaseParser
    {
        private uint stpFormat;
        private uint cbFormat;

        internal ObjectInfoDependencyOverridesFNDParser(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override ObjectInfoDependencyOverridesFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectInfoDependencyOverridesFND = new ObjectInfoDependencyOverridesFND();
            var index = startIndex;
            objectInfoDependencyOverridesFND.Ref = new FileNodeChunkReferenceParser(stpFormat, cbFormat).DoDeserializeFromByteArray(reader, index);
            index += objectInfoDependencyOverridesFND.Ref.Size;
            objectInfoDependencyOverridesFND.data = ObjectInfoDependencyOverrideDataParser.DoDeserializeFromByteArray(reader, index);
            return objectInfoDependencyOverridesFND;
        }
    }
}
