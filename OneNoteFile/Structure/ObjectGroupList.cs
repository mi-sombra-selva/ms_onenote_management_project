using OneNoteFile.FileNodeStructure;
using OneNoteFile.Types;

namespace OneNoteFile.Structure
{
    internal class ObjectGroupList
    {
        internal List<FileNode> FileNodeSequence { get; set; }

        internal List<FileNodeListFragment> FileNodeListFragments { get; set; }

        internal ObjectGroupList()
        {
            FileNodeSequence = new List<FileNode>();
            FileNodeListFragments = new List<FileNodeListFragment>();
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
        }
    }
}
