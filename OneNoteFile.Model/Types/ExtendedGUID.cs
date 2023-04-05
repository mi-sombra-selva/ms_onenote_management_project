namespace OneNoteFile.Model.Types
{
    internal class ExtendedGUID
    {
        internal const int GuidSize = 16;
        internal const int NSize = 4;
        internal const int totalSize = GuidSize + NSize;

        internal Guid Guid { get; set; }

        internal uint N { get; set; }

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
