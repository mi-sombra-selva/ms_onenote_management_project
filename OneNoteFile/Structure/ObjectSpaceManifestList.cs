using OneNoteFile.FileNodeStructure;
using OneNoteFile.FileNodeStructure.Types;
using OneNoteFile.Types;

namespace OneNoteFile.Structure
{
    internal class ObjectSpaceManifestList
    {
        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }

        internal List<RevisionManifestList> RevisionManifestList { get; set; }

        internal List<FileNode> FileNodeSequence { get; set; }

        internal ObjectSpaceManifestList()
        {
            FileNodeListFragments = new List<FileNodeListFragment>();
            RevisionManifestList = new List<RevisionManifestList>();
            FileNodeSequence = new List<FileNode>();
        }

        public void DoDeserializeFromByteArray(byte[] byteArray, FileNodeChunkReference reference)
        {
            var fragment = new FileNodeListFragment(reference.CbValue);
            fragment.DoDeserializeFromByteArray(byteArray, (int)reference.StpValue);
            FileNodeListFragments.Add(fragment);
            FileNodeSequence.AddRange(fragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND).ToArray());
            var nextFragmentRef = fragment.nextFragment;
            while (nextFragmentRef.IsfcrNil() == false && nextFragmentRef.IsfcrZero() == false)
            {
                var nextFragment = new FileNodeListFragment(nextFragmentRef.Cb);
                nextFragment.DoDeserializeFromByteArray(byteArray, (int)nextFragmentRef.Stp);
                nextFragmentRef = nextFragment.nextFragment;
                FileNodeListFragments.Add(nextFragment);
                FileNodeSequence.AddRange(nextFragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND).ToArray());
            }

            var revisionManifestListRefArray = FileNodeSequence.Where(obj => obj.FileNodeID == FileNodeIDValues.RevisionManifestListReferenceFND).ToArray();
            foreach (var revisionManifestListNode in revisionManifestListRefArray)
            {
                var revisionManifestListReferenceFND = revisionManifestListNode.fnd as RevisionManifestListReferenceFND;
                var revisionManifestList = new RevisionManifestList();
                revisionManifestList.DoDeserializeFromByteArray(byteArray, revisionManifestListReferenceFND.refField);
                RevisionManifestList.Add(revisionManifestList);
            }
        }
    }
}
