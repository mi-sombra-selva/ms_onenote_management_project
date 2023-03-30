using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestListReferenceFND : FileNodeBase
    {
        private uint stpFormat;
        private uint cbFormat;

        internal FileNodeChunkReference refField { get; set; }
        internal ExtendedGUID gosid { get; set; }

        internal ObjectSpaceManifestListReferenceFND(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            refField = new FileNodeChunkReference(stpFormat, cbFormat);
            var len = refField.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            gosid = new ExtendedGUID();
            len = gosid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            return index - startIndex;
        }
    }
}
