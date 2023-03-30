namespace OneNoteFile.Types
{
    internal class ExtendedGUID
    {
        internal Guid Guid { get; set; }

        internal uint N { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            var guidBuffer = new byte[16];
            Array.Copy(byteArray, index, guidBuffer, 0, 16);
            index += 16;
            Guid = new Guid(guidBuffer);
            N = BitConverter.ToUInt32(byteArray, index);
            index += 4;

            return index - startIndex;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ExtendedGUID))
            {
                return false;
            }
            else if (((ExtendedGUID)obj).Guid != Guid || ((ExtendedGUID)obj).N != N)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Guid.GetHashCode();
                hashCode ^= N.GetHashCode();

                return hashCode;
            }
        }
    }
}
