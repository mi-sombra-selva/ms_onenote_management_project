using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class RevisionManifestListReferenceFND : FileNodeBase
    {
        private uint stpFormat;
        private uint cbFormat;

        internal FileNodeChunkReference refField { get; set; }

        internal RevisionManifestListReferenceFND(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            refField = new FileNodeChunkReference(stpFormat, cbFormat);

            return refField.DoDeserializeFromByteArray(byteArray, startIndex);
        }
    }
}
