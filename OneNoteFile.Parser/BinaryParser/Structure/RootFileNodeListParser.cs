using OneNoteFile.Model.Structure;
using OneNoteFile.Model.Structure.FileNodeStructure;
using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class RootFileNodeListParser
    {
        internal static RootFileNodeList DoDeserializeFromByteArray(BinaryReader reader, FileChunkReference64x32 reference)
        {
            var rootFileNodeList = new RootFileNodeList();

            var fragmentParser = new FileNodeListFragmentParser(reference.Cb);
            var fragment = fragmentParser.DoDeserializeFromByteArray(reader, (int)reference.Stp);
            rootFileNodeList.FileNodeListFragments.Add(fragment);
            rootFileNodeList.FileNodeSequence.AddRange(fragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            var nextFragmentRef = fragment.nextFragment;
            while (nextFragmentRef.IsfcrNil() == false && nextFragmentRef.IsfcrZero() == false)
            {
                var nextFragmentParser = new FileNodeListFragmentParser(nextFragmentRef.Cb);
                var nextFragment = nextFragmentParser.DoDeserializeFromByteArray(reader, (int)nextFragmentRef.Stp);
                nextFragmentRef = nextFragment.nextFragment;
                rootFileNodeList.FileNodeListFragments.Add(nextFragment);
                rootFileNodeList.FileNodeSequence.AddRange(nextFragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            }

            var objectSpaceManifestListReferences = rootFileNodeList.FileNodeSequence.Where(obj => obj.FileNodeID == FileNodeIDValues.ObjectSpaceManifestListReferenceFND);
            foreach (var node in objectSpaceManifestListReferences)
            {
                var objectSpaceManifestListReference = node.fnd as ObjectSpaceManifestListReferenceFND;
                var objectSpaceManifestList = ObjectSpaceManifestListParser.DoDeserializeFromByteArray(reader, objectSpaceManifestListReference.refField);
                rootFileNodeList.ObjectSpaceManifestList.Add(objectSpaceManifestList);
            }

            return rootFileNodeList;
        }
    }
}
