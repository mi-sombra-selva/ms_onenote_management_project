using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal class FileNodeChunkReferenceParser : FileChunkReferenceParser
    {
        private uint stpFormat;

        private uint cbFormat;

        internal FileNodeChunkReferenceParser(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override FileNodeChunkReference DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var fileNodeChunkReference = new FileNodeChunkReference(stpFormat, cbFormat);
            var index = startIndex;
            var stpLen = fileNodeChunkReference.StpLen;
            switch (stpFormat)
            {
                case 0:
                    fileNodeChunkReference.Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Stp, 0, stpLen);
                    fileNodeChunkReference.StpValue = BitConverter.ToUInt64(fileNodeChunkReference.Stp, 0);
                    break;
                case 1:
                    fileNodeChunkReference.Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Stp, 0, stpLen);
                    fileNodeChunkReference.StpValue = BitConverter.ToUInt32(fileNodeChunkReference.Stp, 0);
                    break;
                case 3:
                    fileNodeChunkReference.Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Stp, 0, stpLen);
                    fileNodeChunkReference.StpValue = BitConverter.ToUInt32(fileNodeChunkReference.Stp, 0) * 8;
                    break;
                case 2:
                    fileNodeChunkReference.Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Stp, 0, stpLen);
                    fileNodeChunkReference.StpValue = (ulong)(BitConverter.ToUInt16(fileNodeChunkReference.Stp, 0) * 8);
                    break;
            }
            fileNodeChunkReference.Stp = new byte[stpLen];
            Array.Copy(byteArray, index, fileNodeChunkReference.Stp, 0, stpLen);
            index += stpLen;
            var cbLen = fileNodeChunkReference.CbLen;
            switch (cbFormat)
            {
                case 0:
                    fileNodeChunkReference.Cb = new byte[4];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Cb, 0, 4);
                    fileNodeChunkReference.CbValue = BitConverter.ToUInt32(fileNodeChunkReference.Cb, 0);
                    break;
                case 1:
                    fileNodeChunkReference.Cb = new byte[8];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Cb, 0, 8);
                    fileNodeChunkReference.CbValue = BitConverter.ToUInt64(fileNodeChunkReference.Cb, 0);
                    break;
                case 2:
                    fileNodeChunkReference.Cb = new byte[1];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Cb, 0, 1);
                    fileNodeChunkReference.CbValue = (ulong)(fileNodeChunkReference.Cb[0] * 8);
                    break;
                case 3:
                    fileNodeChunkReference.Cb = new byte[2];
                    Array.Copy(byteArray, index, fileNodeChunkReference.Cb, 0, 2);
                    fileNodeChunkReference.CbValue = (ulong)(BitConverter.ToUInt16(fileNodeChunkReference.Cb, 0) * 8);
                    break;
            }

            return fileNodeChunkReference;
        }
    }
}
