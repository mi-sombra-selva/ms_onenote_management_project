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

        internal override FileNodeChunkReference DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var fileNodeChunkReference = new FileNodeChunkReference(stpFormat, cbFormat);
            var index = startIndex;
            var stpLen = fileNodeChunkReference.StpLen;
            fileNodeChunkReference.Stp = reader.ReadBytes(index, stpLen);
            switch (stpFormat)
            {
                case 0:
                    fileNodeChunkReference.StpValue = BitConverter.ToUInt64(fileNodeChunkReference.Stp, 0);
                    break;
                case 1:
                    fileNodeChunkReference.StpValue = BitConverter.ToUInt32(fileNodeChunkReference.Stp, 0);
                    break;
                case 3:
                    fileNodeChunkReference.StpValue = BitConverter.ToUInt32(fileNodeChunkReference.Stp, 0) * 8;
                    break;
                case 2:
                    fileNodeChunkReference.StpValue = (ulong)(BitConverter.ToUInt16(fileNodeChunkReference.Stp, 0) * 8);
                    break;
            }
            index += stpLen;
            var cbLen = fileNodeChunkReference.CbLen;
            fileNodeChunkReference.Cb = reader.ReadBytes(index, cbLen);
            switch (cbFormat)
            {
                case 0:
                    fileNodeChunkReference.CbValue = BitConverter.ToUInt32(fileNodeChunkReference.Cb, 0);
                    break;
                case 1:
                    fileNodeChunkReference.CbValue = BitConverter.ToUInt64(fileNodeChunkReference.Cb, 0);
                    break;
                case 2:
                    fileNodeChunkReference.CbValue = (ulong)(fileNodeChunkReference.Cb[0] * 8);
                    break;
                case 3:
                    fileNodeChunkReference.CbValue = (ulong)(BitConverter.ToUInt16(fileNodeChunkReference.Cb, 0) * 8);
                    break;
            }

            return fileNodeChunkReference;
        }
    }
}
