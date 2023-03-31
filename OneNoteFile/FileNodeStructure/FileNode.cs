using BitManipulator;
using OneNoteFile.FileNodeStructure.Types;

namespace OneNoteFile.FileNodeStructure
{
    internal class FileNode
    {
        internal FileNodeIDValues FileNodeID { get; set; }

        internal uint Size { get; set; }

        internal uint StpFormat { get; set; }

        internal uint CbFormat { get; set; }

        internal uint BaseType { get; set; }

        internal uint Reserved { get; set; }

        internal FileNodeBase fnd { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            using (var bitReader = new BitReader(byteArray, index))
            {
                FileNodeID = (FileNodeIDValues)bitReader.ReadUInt32(10);
                Size = bitReader.ReadUInt32(13);
                StpFormat = bitReader.ReadUInt32(2);
                CbFormat = bitReader.ReadUInt32(2);
                BaseType = bitReader.ReadUInt32(4);
                Reserved = bitReader.ReadUInt32(1);
            }
            index += 4;
            switch (FileNodeID)
            {
                case FileNodeIDValues.ObjectSpaceManifestRootFND:
                    fnd = new ObjectSpaceManifestRootFND();
                    break;
                case FileNodeIDValues.ObjectSpaceManifestListReferenceFND:
                    fnd = new ObjectSpaceManifestListReferenceFND(StpFormat, CbFormat);
                    break;
                case FileNodeIDValues.ObjectSpaceManifestListStartFND:
                    fnd = new ObjectSpaceManifestListStartFND();
                    break;
                case FileNodeIDValues.RevisionManifestListReferenceFND:
                    fnd = new RevisionManifestListReferenceFND(StpFormat, CbFormat);
                    break;
                case FileNodeIDValues.RevisionManifestListStartFND:
                    fnd = new RevisionManifestListStartFND();
                    break;
                case FileNodeIDValues.RevisionManifestStart6FND:
                    fnd = new RevisionManifestStart6FND();
                    break;
                case FileNodeIDValues.RevisionManifestStart7FND:
                    fnd = new RevisionManifestStart7FND();
                    break;
                case FileNodeIDValues.GlobalIdTableEntryFNDX:
                    fnd = new GlobalIdTableEntryFNDX();
                    break;
                case FileNodeIDValues.RootObjectReference3FND:
                    fnd = new RootObjectReference3FND();
                    break;
                case FileNodeIDValues.RevisionRoleDeclarationFND:
                    fnd = new RevisionRoleDeclarationFND();
                    break;
                case FileNodeIDValues.RevisionRoleAndContextDeclarationFND:
                    fnd = new RevisionRoleAndContextDeclarationFND();
                    break;
                case FileNodeIDValues.ObjectInfoDependencyOverridesFND:
                    fnd = new ObjectInfoDependencyOverridesFND(StpFormat, CbFormat);
                    break;
                case FileNodeIDValues.DataSignatureGroupDefinitionFND:
                    fnd = new DataSignatureGroupDefinitionFND();
                    break;
                case FileNodeIDValues.ObjectDeclaration2RefCountFND:
                    fnd = new ObjectDeclaration2RefCountFND(StpFormat, CbFormat);
                    break;
                case FileNodeIDValues.ObjectGroupListReferenceFND:
                    fnd = new ObjectGroupListReferenceFND(StpFormat, CbFormat);
                    break;
                case FileNodeIDValues.ObjectGroupStartFND:
                    fnd = new ObjectGroupStartFND();
                    break;
                case FileNodeIDValues.ReadOnlyObjectDeclaration2RefCountFND:
                    fnd = new ReadOnlyObjectDeclaration2RefCountFND(StpFormat, CbFormat);
                    break;
                case 0:
                case FileNodeIDValues.RevisionManifestEndFND:
                case FileNodeIDValues.GlobalIdTableStart2FND:
                case FileNodeIDValues.GlobalIdTableEndFNDX:
                case FileNodeIDValues.ObjectGroupEndFND:
                case FileNodeIDValues.ChunkTerminatorFND:
                    fnd = null;
                    break;
                default:
                    throw new NotImplementedException($"Deserialization is not supported for this FileNodeID: {FileNodeID}");
            }
            if (fnd != null)
            {
                var len = fnd.DoDeserializeFromByteArray(byteArray, index);
                index += len;
            }

            return index - startIndex;
        }
    }
}
