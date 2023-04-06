using BitManipulator;
using OneNoteFile.Model.Structure.FileNodeStructure;
using OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure
{
    internal class FileNodeParser
    {
        public static FileNode DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var fileNode = new FileNode();

            var index = startIndex;
            using (var bitReader = new BitReader(reader, index))
            {
                fileNode.FileNodeID = (FileNodeIDValues)bitReader.ReadUInt32(10);
                fileNode.Size = bitReader.ReadUInt32(13);
                fileNode.StpFormat = bitReader.ReadUInt32(2);
                fileNode.CbFormat = bitReader.ReadUInt32(2);
                fileNode.BaseType = bitReader.ReadUInt32(4);
                fileNode.Reserved = bitReader.ReadUInt32(1);
            }
            index += 4;
            FileNodeBaseParser fileNodeParser = null;
            switch (fileNode.FileNodeID)
            {
                case FileNodeIDValues.ObjectSpaceManifestRootFND:
                    fileNodeParser = new ObjectSpaceManifestRootFNDParser();
                    break;
                case FileNodeIDValues.ObjectSpaceManifestListReferenceFND:
                    fileNodeParser = new ObjectSpaceManifestListReferenceFNDParser(fileNode.StpFormat, fileNode.CbFormat);
                    break;
                case FileNodeIDValues.ObjectSpaceManifestListStartFND:
                    fileNodeParser = new ObjectSpaceManifestListStartFNDParser();
                    break;
                case FileNodeIDValues.RevisionManifestListReferenceFND:
                    fileNodeParser = new RevisionManifestListReferenceFNDParser(fileNode.StpFormat, fileNode.CbFormat);
                    break;
                case FileNodeIDValues.RevisionManifestListStartFND:
                    fileNodeParser = new RevisionManifestListStartFNDParser();
                    break;
                case FileNodeIDValues.RevisionManifestStart6FND:
                    fileNodeParser = new RevisionManifestStart6FNDParser();
                    break;
                case FileNodeIDValues.RevisionManifestStart7FND:
                    fileNodeParser = new RevisionManifestStart7FNDParser();
                    break;
                case FileNodeIDValues.GlobalIdTableEntryFNDX:
                    fileNodeParser = new GlobalIdTableEntryFNDXParser();
                    break;
                case FileNodeIDValues.RootObjectReference3FND:
                    fileNodeParser = new RootObjectReference3FNDParser();
                    break;
                case FileNodeIDValues.RevisionRoleDeclarationFND:
                    fileNodeParser = new RevisionRoleDeclarationFNDParser();
                    break;
                case FileNodeIDValues.RevisionRoleAndContextDeclarationFND:
                    fileNodeParser = new RevisionRoleAndContextDeclarationFNDParser();
                    break;
                case FileNodeIDValues.ObjectInfoDependencyOverridesFND:
                    fileNodeParser = new ObjectInfoDependencyOverridesFNDParser(fileNode.StpFormat, fileNode.CbFormat);
                    break;
                case FileNodeIDValues.DataSignatureGroupDefinitionFND:
                    fileNodeParser = new DataSignatureGroupDefinitionFNDParser();
                    break;
                case FileNodeIDValues.ObjectDeclaration2RefCountFND:
                    fileNodeParser = new ObjectDeclaration2RefCountFNDParser(fileNode.StpFormat, fileNode.CbFormat);
                    break;
                case FileNodeIDValues.ObjectGroupListReferenceFND:
                    fileNodeParser = new ObjectGroupListReferenceFNDParser(fileNode.StpFormat, fileNode.CbFormat);
                    break;
                case FileNodeIDValues.ObjectGroupStartFND:
                    fileNodeParser = new ObjectGroupStartFNDParser();
                    break;
                case FileNodeIDValues.ReadOnlyObjectDeclaration2RefCountFND:
                    fileNodeParser = new ReadOnlyObjectDeclaration2RefCountFNDParser(fileNode.StpFormat, fileNode.CbFormat);
                    break;
                case 0:
                case FileNodeIDValues.RevisionManifestEndFND:
                case FileNodeIDValues.GlobalIdTableStart2FND:
                case FileNodeIDValues.GlobalIdTableEndFNDX:
                case FileNodeIDValues.ObjectGroupEndFND:
                case FileNodeIDValues.ChunkTerminatorFND:
                    fileNodeParser = null;
                    break;
                default:
                    throw new NotImplementedException($"Deserialization is not supported for this FileNodeID: {fileNode.FileNodeID}");
            }
            if (fileNodeParser != null)
            {
                fileNode.fnd = fileNodeParser.DoDeserializeFromByteArray(reader, index);
            }

            return fileNode;
        }
    }
}
