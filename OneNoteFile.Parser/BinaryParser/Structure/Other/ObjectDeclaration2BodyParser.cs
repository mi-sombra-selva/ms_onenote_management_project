using BitManipulator;
using OneNoteFile.Model.Structure.Other;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other
{
    internal class ObjectDeclaration2BodyParser
    {
        internal static ObjectDeclaration2Body DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectDeclaration2Body = new ObjectDeclaration2Body();

            var index = startIndex;
            objectDeclaration2Body.oid = CompactIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += CompactID.totalSize;
            objectDeclaration2Body.jcid = JCIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += JCID.totalSize;

            using (var bitReader = new BitReader(byteArray, index))
            {
                objectDeclaration2Body.fHasOidReferences = bitReader.ReadUInt32(1);
                objectDeclaration2Body.fHasOsidReferences = bitReader.ReadUInt32(1);
                objectDeclaration2Body.fReserved2 = bitReader.ReadUInt32(6);
            }

            return objectDeclaration2Body;
        }
    }
}
