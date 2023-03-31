using OneNoteFile.Structure.Other.ObjectInfoDependency;
using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ObjectInfoDependencyOverridesFND : FileNodeBase
    {
        private uint stpFormat;
        private uint cbFormat;

        internal FileNodeChunkReference Ref { get; set; }
        internal ObjectInfoDependencyOverrideData data { get; set; }

        internal ObjectInfoDependencyOverridesFND(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Ref = new FileNodeChunkReference(this.stpFormat, this.cbFormat);
            var len = Ref.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            data = new ObjectInfoDependencyOverrideData();
            len = data.DoDeserializeFromByteArray(byteArray, index);
            index += len;

            return index - startIndex;
        }
    }
}
