using OneNoteFile.Types;

namespace OneNoteFile.Structure.Other.ObjectInfoDependency
{
    internal class ObjectInfoDependencyOverride8
    {
        internal CompactID oid { get; set; }
        internal byte cRef { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            oid = new CompactID();
            var len = oid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            cRef = byteArray[index];
            index += 1;

            return index - startIndex;
        }
    }
}
