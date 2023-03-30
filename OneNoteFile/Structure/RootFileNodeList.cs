using OneNoteFile.FileNodeStructure;
using OneNoteFile.FileNodeStructure.Types;
using OneNoteFile.Types;

namespace OneNoteFile.Structure
{
    internal class RootFileNodeList
    {
        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }

        internal FileNode ObjectSpaceManifestRoot { get; set; }

        internal List<FileNode> FileNodeSequence { get; set; }

        internal List<ObjectSpaceManifestList> ObjectSpaceManifestList { get; set; }

        internal RootFileNodeList()
        {
            FileNodeListFragments = new List<FileNodeListFragment>();
            ObjectSpaceManifestList = new List<ObjectSpaceManifestList>();
            FileNodeSequence = new List<FileNode>();
        }

        internal void DoDeserializeFromByteArray(byte[] byteArray, FileChunkReference64x32 reference)
        {
            var fragment = new FileNodeListFragment(reference.Cb);
            fragment.DoDeserializeFromByteArray(byteArray, (int)reference.Stp);
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

            var objectSpaceManifestListReferences = FileNodeSequence.Where(obj => obj.FileNodeID == FileNodeIDValues.ObjectSpaceManifestListReferenceFND).ToArray();
            foreach (var node in objectSpaceManifestListReferences)
            {
                var objectSpaceManifestListReference = node.fnd as ObjectSpaceManifestListReferenceFND;
                var objectSpaceManifestList = new ObjectSpaceManifestList();
                objectSpaceManifestList.DoDeserializeFromByteArray(byteArray, objectSpaceManifestListReference.refField);
                ObjectSpaceManifestList.Add(objectSpaceManifestList);
            }
        }
    }
}
