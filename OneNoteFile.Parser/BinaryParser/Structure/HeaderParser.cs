using OneNoteFile.Model.Structure;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class HeaderParser
    {
        internal static Header DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var header = new Header();

            var index = startIndex;
            index += 16; // guidFileType
            index += 16; // guidFile
            index += 16; // guidLegacyFileVersion
            index += 16; // guidFileFormat
            index += 4; // ffvLastCodeThatWroteToThisFile
            index += 4; // ffvOldestCodeThatHasWrittenToThisFile
            index += 4; // ffvNewestCodeThatHasWrittenToThisFile
            index += 4; // ffvOldestCodeThatMayReadThisFile
            index += 8; // fcrLegacyFreeChunkList
            index += 8; // fcrLegacyTransactionLog
            index += 4; // cTransactionsInLog
            index += 4; // cbLegacyExpectedFileLength
            index += 8; // rgbPlaceholder
            index += 8; // fcrLegacyFileNodeListRoot
            index += 4; // cbLegacyFreeSpaceInFreeChunkList
            index += 1; // fNeedsDefrag
            index += 1; // fRepairedFile
            index += 1; // fNeedsGarbageCollect
            index += 1; // fHasNoEmbeddedFileObjects
            index += 16; // guidAncestor
            index += 4; // crcName
            index += 12; // fcrHashedChunkList
            header.fcrTransactionLog = new FileChunkReference64x32Parser().DoDeserializeFromByteArray(reader, index);
            index += FileChunkReference64x32.totalSize; // fcrTransactionLog
            header.fcrFileNodeListRoot = new FileChunkReference64x32Parser().DoDeserializeFromByteArray(reader, index);

            return header;
        }
    }
}
