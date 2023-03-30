namespace OneNoteFile.FileNodeStructure.Types
{
    internal abstract class FileNodeBase
    {
        internal abstract int DoDeserializeFromByteArray(byte[] byteArray, int startIndex);
    }
}
