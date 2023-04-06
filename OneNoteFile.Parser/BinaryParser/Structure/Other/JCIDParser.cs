using BitManipulator;
using OneNoteFile.Model.Structure.Other;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other
{
    internal class JCIDParser
    {
        internal static JCID DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var jcid = new JCID();
            using (var bitReader = new BitReader(reader, startIndex))
            {
                jcid.Index = bitReader.ReadInt32(16);
                jcid.IsBinary = bitReader.ReadInt32(1);
                jcid.IsPropertySet = bitReader.ReadInt32(1);
                jcid.IsGraphNode = bitReader.ReadInt32(1);
                jcid.IsFileData = bitReader.ReadInt32(1);
                jcid.IsReadOnly = bitReader.ReadInt32(1);
                jcid.Reserved = bitReader.ReadInt32(11);
            }
            return jcid;
        }
    }
}
