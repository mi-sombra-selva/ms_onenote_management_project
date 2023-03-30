using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class RootObjectReference3FND : FileNodeBase
    {
        internal ExtendedGUID oidRoot { get; set; }
        internal uint RootRole { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            oidRoot = new ExtendedGUID();
            var len = oidRoot.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            RootRole = BitConverter.ToUInt32(byteArray, index);
            index += 4;

            return index - startIndex;
        }
    }
}
