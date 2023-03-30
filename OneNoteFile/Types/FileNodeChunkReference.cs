namespace OneNoteFile.Types
{
    internal class FileNodeChunkReference : FileChunkReference
    {
        private uint stpFormat;

        private uint cbFormat;

        internal FileNodeChunkReference(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal byte[] Stp { get; set; }

        internal byte[] Cb { get; set; }

        internal ulong CbValue { get; private set; }

        internal ulong StpValue { get; private set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            var stpLen = 0;
            switch (stpFormat)
            {
                case 0:
                    stpLen = 8;
                    Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, Stp, 0, stpLen);
                    StpValue = BitConverter.ToUInt64(Stp, 0);
                    break;
                case 1:
                    stpLen = 4;
                    Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, Stp, 0, stpLen);
                    StpValue = BitConverter.ToUInt32(Stp, 0);
                    break;
                case 3:
                    stpLen = 4;
                    Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, Stp, 0, stpLen);
                    StpValue = BitConverter.ToUInt32(Stp, 0) * 8;
                    break;
                case 2:
                    stpLen = 2;
                    Stp = new byte[stpLen];
                    Array.Copy(byteArray, index, Stp, 0, stpLen);
                    StpValue = (ulong)(BitConverter.ToUInt16(Stp, 0) * 8);
                    break;
            }
            Stp = new byte[stpLen];
            Array.Copy(byteArray, index, Stp, 0, stpLen);
            index += stpLen;
            var cbLen = 0;
            switch (cbFormat)
            {
                case 0:
                    cbLen = 4;
                    Cb = new byte[4];
                    Array.Copy(byteArray, index, Cb, 0, 4);
                    CbValue = BitConverter.ToUInt32(Cb, 0);
                    break;
                case 1:
                    cbLen = 8;
                    Cb = new byte[8];
                    Array.Copy(byteArray, index, Cb, 0, 8);
                    CbValue = BitConverter.ToUInt64(Cb, 0);
                    break;
                case 2:
                    cbLen = 1;
                    Cb = new byte[1];
                    Array.Copy(byteArray, index, Cb, 0, 1);
                    CbValue = (ulong)(Cb[0] * 8);
                    break;
                case 3:
                    cbLen = 2;
                    Cb = new byte[2];
                    Array.Copy(byteArray, index, Cb, 0, 2);
                    CbValue = (ulong)(BitConverter.ToUInt16(Cb, 0) * 8);
                    break;
            }

            index += cbLen;

            return index - startIndex;
        }

        internal override bool IsfcrNil()
        {
            foreach (var b in Stp)
            {
                if (b != byte.MaxValue)
                {
                    return false;
                }
            }
            foreach (var b in Cb)
            {
                if (b != 0)
                {
                    return false;
                }
            }

            return true;
        }

        internal override bool IsfcrZero()
        {
            foreach (var b in Stp)
            {
                if (b != byte.MinValue)
                {
                    return false;
                }
            }
            foreach (var b in Cb)
            {
                if (b != byte.MinValue)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
