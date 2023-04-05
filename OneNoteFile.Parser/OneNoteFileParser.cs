using OneNoteFile.Model.Structure;

namespace OneNoteFile.Parser
{
    internal class OneNoteFileParser
    {
        internal IOneNoteFileParserLogic OneNoteFileParserLogic { get; set; }

        internal OneNoteFileParser(IOneNoteFileParserLogic logic)
        {
            OneNoteFileParserLogic = logic;
        }

        internal OneNoteRevisionStoreFile Parse(byte[] byteArray)
        {
            return OneNoteFileParserLogic.Parse(byteArray);
        }
    }
}
