using OneNoteFile.Model.Structure;
using OneNoteFile.Model.Structure.FileNodeStructure;
using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class ObjectSpaceManifestListParser
    {
        public static ObjectSpaceManifestList DoDeserializeFromByteArray(BinaryReader reader, FileNodeChunkReference reference)
        {
            var objectSpaceManifestList = new ObjectSpaceManifestList();
            var fragmentParser = new FileNodeListFragmentParser(reference.CbValue);
            var fragment = fragmentParser.DoDeserializeFromByteArray(reader, (int)reference.StpValue);
            objectSpaceManifestList.FileNodeListFragments.Add(fragment);
            objectSpaceManifestList.FileNodeSequence.AddRange(fragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            var nextFragmentRef = fragment.nextFragment;
            while (nextFragmentRef.IsfcrNil() == false && nextFragmentRef.IsfcrZero() == false)
            {
                var nextFragmentParser = new FileNodeListFragmentParser(nextFragmentRef.Cb);
                var nextFragment = nextFragmentParser.DoDeserializeFromByteArray(reader, (int)nextFragmentRef.Stp);
                nextFragmentRef = nextFragment.nextFragment;
                objectSpaceManifestList.FileNodeListFragments.Add(nextFragment);
                objectSpaceManifestList.FileNodeSequence.AddRange(nextFragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            }

            var revisionManifestListRefArray = objectSpaceManifestList.FileNodeSequence.Where(obj => obj.FileNodeID == FileNodeIDValues.RevisionManifestListReferenceFND);
            foreach (var revisionManifestListNode in revisionManifestListRefArray)
            {
                var revisionManifestListReferenceFND = revisionManifestListNode.fnd as RevisionManifestListReferenceFND;
                var revisionManifestList = RevisionManifestListParser.DoDeserializeFromByteArray(reader, revisionManifestListReferenceFND.refField);
                objectSpaceManifestList.RevisionManifestList.Add(revisionManifestList);
            }

            return objectSpaceManifestList;
        }
    }
}
