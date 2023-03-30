namespace OneNoteFile.Types
{
    internal abstract class FileChunkReference
    {
        internal abstract int DoDeserializeFromByteArray(byte[] byteArray, int startIndex);

        internal abstract bool IsfcrNil();

        internal abstract bool IsfcrZero();
    }
}
