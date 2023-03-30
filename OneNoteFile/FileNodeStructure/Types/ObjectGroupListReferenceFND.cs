using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ObjectGroupListReferenceFND : FileNodeBase
    {
        private uint stpFormat;
        private uint cbFormat;

        internal FileNodeChunkReference Ref { get; set; }
        internal ExtendedGUID ObjectGroupID { get; set; }

        internal ObjectGroupListReferenceFND(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Ref = new FileNodeChunkReference(stpFormat, cbFormat);
            var len = Ref.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            ObjectGroupID = new ExtendedGUID();
            len = ObjectGroupID.DoDeserializeFromByteArray(byteArray, index);
            index += len;

            return index - startIndex;
        }
    }
}
