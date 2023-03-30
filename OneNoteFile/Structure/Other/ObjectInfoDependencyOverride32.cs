using OneNoteFile.Types;

namespace OneNoteFile.Structure.Other
{
    internal class ObjectInfoDependencyOverride32
    {
        internal CompactID oid { get; set; }
        internal uint cRef { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            oid = new CompactID();
            var len = oid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            cRef = BitConverter.ToUInt32(byteArray, index);
            index += 4;

            return index - startIndex;
        }
    }
}
