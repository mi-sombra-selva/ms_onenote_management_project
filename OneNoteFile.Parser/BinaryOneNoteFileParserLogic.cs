using OneNoteFile.Model.Structure;
using OneNoteFile.Parser.BinaryParser.Structure;

namespace OneNoteFile.Parser
{
    internal class BinaryOneNoteFileParserLogic : IOneNoteFileParserLogic
    {
        public OneNoteRevisionStoreFile Parse(byte[] byteArray)
        {
            return OneNoteRevisionStoreFileParser.DoDeserializeFromByteArray(byteArray);
        }
    }
}
