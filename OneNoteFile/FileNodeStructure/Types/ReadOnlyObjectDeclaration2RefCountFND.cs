namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ReadOnlyObjectDeclaration2RefCountFND : FileNodeBase
    {
        private uint stpFormat;
        private uint cbFormat;

        internal ObjectDeclaration2RefCountFND Base { get; set; }
        internal byte[] md5Hash { get; set; }

        internal ReadOnlyObjectDeclaration2RefCountFND(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Base = new ObjectDeclaration2RefCountFND(stpFormat, cbFormat);
            var len = Base.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            md5Hash = new byte[16];
            Array.Copy(byteArray, index, md5Hash, 0, 16);
            index += 16;

            return index - startIndex;
        }
    }
}
