using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class DataSignatureGroupDefinitionFNDParser : FileNodeBaseParser
    {
        internal override DataSignatureGroupDefinitionFND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var dataSignatureGroupDefinitionFND = new DataSignatureGroupDefinitionFND();
            dataSignatureGroupDefinitionFND.DataSignatureGroup = ExtendedGUIDParser.DoDeserializeFromByteArray(byteArray, startIndex);
            return dataSignatureGroupDefinitionFND;
        }
    }
}
