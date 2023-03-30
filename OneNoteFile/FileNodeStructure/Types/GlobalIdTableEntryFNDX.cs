namespace OneNoteFile.FileNodeStructure.Types
{
    internal class GlobalIdTableEntryFNDX : FileNodeBase
    {
        internal uint index { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var idx = startIndex;
            index = BitConverter.ToUInt32(byteArray, idx);
            idx += 4;
            idx += 16; // guid

            return idx - startIndex;
        }
    }
}
