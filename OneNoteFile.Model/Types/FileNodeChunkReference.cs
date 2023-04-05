namespace OneNoteFile.Model.Types
{
    internal class FileNodeChunkReference : FileChunkReference
    {
        private uint stpFormat;
        private uint cbFormat;

        internal byte[] Stp { get; set; }

        internal byte[] Cb { get; set; }

        internal ulong CbValue { get; set; }

        internal ulong StpValue { get; set; }

        internal FileNodeChunkReference(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal int StpLen
        {
            get
            {
                return stpFormat switch
                {
                    0 => 8,
                    1 => 4,
                    3 => 4,
                    2 => 2,
                    _ => 0,
                };
            }
        }

        internal int CbLen
        {
            get
            {
                return cbFormat switch
                {
                    0 => 4,
                    1 => 8,
                    2 => 1,
                    3 => 2,
                    _ => 0,
                };
            }
        }

        internal int Size
        {
            get
            {
                return StpLen + CbLen;
            }
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
