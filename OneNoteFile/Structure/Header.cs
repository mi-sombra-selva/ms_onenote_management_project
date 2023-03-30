using OneNoteFile.Types;

namespace OneNoteFile.Structure
{
    internal class Header
    {
        internal FileChunkReference64x32 fcrTransactionLog { get; set; }
        internal FileChunkReference64x32 fcrFileNodeListRoot { get; set; }

        internal void DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
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
            fcrTransactionLog = new FileChunkReference64x32();
            fcrTransactionLog.DoDeserializeFromByteArray(byteArray, index);
            index += 12; // fcrTransactionLog
            fcrFileNodeListRoot = new FileChunkReference64x32();
            fcrFileNodeListRoot.DoDeserializeFromByteArray(byteArray, index);
        }
    }
}
