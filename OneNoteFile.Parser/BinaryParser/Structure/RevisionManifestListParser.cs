using OneNoteFile.Model.Structure;
using OneNoteFile.Model.Structure.FileNodeStructure;
using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class RevisionManifestListParser
    {
        internal static RevisionManifestList DoDeserializeFromByteArray(BinaryReader reader, FileNodeChunkReference reference)
        {
            var revisionManifestList = new RevisionManifestList();
            var fragmentParser = new FileNodeListFragmentParser(reference.CbValue);
            var fragment = fragmentParser.DoDeserializeFromByteArray(reader, (int)reference.StpValue);
            revisionManifestList.FileNodeListFragments.Add(fragment);
            revisionManifestList.FileNodeSequence.AddRange(fragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            var nextFragmentRef = fragment.nextFragment;
            while (nextFragmentRef.IsfcrNil() == false && nextFragmentRef.IsfcrZero() == false)
            {
                var nextFragmentParser = new FileNodeListFragmentParser(nextFragmentRef.Cb);
                var nextFragment = nextFragmentParser.DoDeserializeFromByteArray(reader, (int)nextFragmentRef.Stp);
                nextFragmentRef = nextFragment.nextFragment;
                revisionManifestList.FileNodeListFragments.Add(nextFragment);
                revisionManifestList.FileNodeSequence.AddRange(nextFragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            }

            foreach (var fileNode in revisionManifestList.FileNodeSequence)
            {
                if (fileNode.FileNodeID == FileNodeIDValues.ObjectGroupListReferenceFND)
                {
                    var objectGroupListRef = fileNode.fnd as ObjectGroupListReferenceFND;
                    var objectGroupList = ObjectGroupListParser.DoDeserializeFromByteArray(reader, objectGroupListRef.Ref);
                    revisionManifestList.ObjectGroupList.Add(objectGroupList);
                }
            }

            return revisionManifestList;
        }
    }
}
