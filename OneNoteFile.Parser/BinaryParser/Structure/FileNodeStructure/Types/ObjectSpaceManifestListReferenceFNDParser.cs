﻿using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestListReferenceFNDParser : FileNodeBaseParser
    {
        private uint stpFormat;
        private uint cbFormat;
        internal ObjectSpaceManifestListReferenceFNDParser(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override ObjectSpaceManifestListReferenceFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectSpaceManifestListReferenceFND = new ObjectSpaceManifestListReferenceFND();
            var index = startIndex;
            objectSpaceManifestListReferenceFND.refField = new FileNodeChunkReferenceParser(stpFormat, cbFormat).DoDeserializeFromByteArray(reader, index);
            index += objectSpaceManifestListReferenceFND.refField.Size;
            objectSpaceManifestListReferenceFND.gosid = ExtendedGUIDParser.DoDeserializeFromByteArray(reader, index);
            return objectSpaceManifestListReferenceFND;
        }
    }
}
