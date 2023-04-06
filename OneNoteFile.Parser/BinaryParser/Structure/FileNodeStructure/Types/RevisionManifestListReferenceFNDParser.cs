using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestListReferenceFNDParser : FileNodeBaseParser
    {
        private uint stpFormat;
        private uint cbFormat;

        internal RevisionManifestListReferenceFNDParser(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override RevisionManifestListReferenceFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var revisionManifestListReferenceFND = new RevisionManifestListReferenceFND();
            revisionManifestListReferenceFND.refField = new FileNodeChunkReferenceParser(stpFormat, cbFormat).DoDeserializeFromByteArray(reader, startIndex);
            return revisionManifestListReferenceFND;
        }
    }
}
