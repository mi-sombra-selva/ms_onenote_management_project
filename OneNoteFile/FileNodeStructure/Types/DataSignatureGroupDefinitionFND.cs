using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class DataSignatureGroupDefinitionFND : FileNodeBase
    {
        internal ExtendedGUID DataSignatureGroup { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            DataSignatureGroup = new ExtendedGUID();
            return DataSignatureGroup.DoDeserializeFromByteArray(byteArray, startIndex);
        }
    }
}
