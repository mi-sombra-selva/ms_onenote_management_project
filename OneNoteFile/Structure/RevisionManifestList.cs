using OneNoteFile.FileNodeStructure.Types;
using OneNoteFile.FileNodeStructure;
using OneNoteFile.Types;

namespace OneNoteFile.Structure
{
    internal class RevisionManifestList
    {
        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }
        internal List<ObjectGroupList> ObjectGroupList { get; set; }
        internal List<FileNode> FileNodeSequence { get; set; }

        internal RevisionManifestList()
        {
            FileNodeListFragments = new List<FileNodeListFragment>();
            ObjectGroupList = new List<ObjectGroupList>();
            FileNodeSequence = new List<FileNode>();
        }

        internal void DoDeserializeFromByteArray(byte[] byteArray, FileNodeChunkReference reference)
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

            foreach (var fileNode in FileNodeSequence)
            {
                if (fileNode.FileNodeID == FileNodeIDValues.ObjectGroupListReferenceFND)
                {
                    var objectGroupListRef = fileNode.fnd as ObjectGroupListReferenceFND;
                    var objectGroupList = new ObjectGroupList();
                    objectGroupList.DoDeserializeFromByteArray(byteArray, objectGroupListRef.Ref);
                    ObjectGroupList.Add(objectGroupList);
                }
            }
        }
    }
}
