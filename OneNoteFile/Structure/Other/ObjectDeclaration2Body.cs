using BitManipulator;
using OneNoteFile.Types;

namespace OneNoteFile.Structure.Other
{
    internal class ObjectDeclaration2Body
    {
        internal CompactID oid { get; set; }

        internal JCID jcid { get; set; }

        internal uint fHasOidReferences { get; set; }

        internal uint fHasOsidReferences { get; set; }

        internal uint fReserved2 { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            oid = new CompactID();
            var len = oid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            jcid = new JCID();
            len = jcid.DoDeserializeFromByteArray(byteArray, index);
            index += len;

            using (var bitReader = new BitReader(byteArray, index))
            {
                fHasOidReferences = bitReader.ReadUInt32(1);
                fHasOsidReferences = bitReader.ReadUInt32(1);
                fReserved2 = bitReader.ReadUInt32(6);
            }
            index += 1;

            return index - startIndex;
        }
    }
}
