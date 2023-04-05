using OneNoteFile.Model.Structure;

namespace OneNoteFile.Parser
{
    internal interface IOneNoteFileParserLogic
    {
        OneNoteRevisionStoreFile Parse(byte[] byteArray);
    }
}
