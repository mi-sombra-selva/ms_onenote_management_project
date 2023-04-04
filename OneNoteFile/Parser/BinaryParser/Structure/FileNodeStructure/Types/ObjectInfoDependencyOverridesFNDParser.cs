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

        internal override ObjectInfoDependencyOverridesFND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectInfoDependencyOverridesFND = new ObjectInfoDependencyOverridesFND();
            var index = startIndex;
            objectInfoDependencyOverridesFND.Ref = new FileNodeChunkReferenceParser(stpFormat, cbFormat).DoDeserializeFromByteArray(byteArray, index);
            index += objectInfoDependencyOverridesFND.Ref.Size;
            objectInfoDependencyOverridesFND.data = ObjectInfoDependencyOverrideDataParser.DoDeserializeFromByteArray(byteArray, index);
            return objectInfoDependencyOverridesFND;
        }
    }
}
