using OneNoteFile.Structure.Other;
using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ObjectDeclaration2RefCountFND : FileNodeBase
    {
        private uint stpFormat;
        private uint cbFormat;

        internal FileNodeChunkReference BlobRef { get; set; }
        internal ObjectDeclaration2Body body { get; set; }
        internal byte cRef { get; set; }

        internal ObjectDeclaration2RefCountFND(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            BlobRef = new FileNodeChunkReference(stpFormat, cbFormat);
            var len = BlobRef.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            body = new ObjectDeclaration2Body();
            len = body.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            cRef = byteArray[index];
            index += 1;

            return index - startIndex;
        }
    }
}
