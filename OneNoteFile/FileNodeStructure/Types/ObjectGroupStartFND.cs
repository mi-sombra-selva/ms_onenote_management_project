using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ObjectGroupStartFND : FileNodeBase
    {
        internal ExtendedGUID oid { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            oid = new ExtendedGUID();
            return oid.DoDeserializeFromByteArray(byteArray, startIndex);
        }
    }
}
