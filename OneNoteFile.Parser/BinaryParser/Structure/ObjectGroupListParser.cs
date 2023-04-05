using OneNoteFile.Model.Structure;
using OneNoteFile.Model.Structure.FileNodeStructure;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class ObjectGroupListParser
    {
        internal static ObjectGroupList DoDeserializeFromByteArray(byte[] byteArray, FileNodeChunkReference reference)
        {
            var objectGroupList = new ObjectGroupList();

            var fragmentParser = new FileNodeListFragmentParser(reference.CbValue);
            var fragment = fragmentParser.DoDeserializeFromByteArray(byteArray, (int)reference.StpValue);
            objectGroupList.FileNodeListFragments.Add(fragment);
            objectGroupList.FileNodeSequence.AddRange(fragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            var nextFragmentRef = fragment.nextFragment;
            while (nextFragmentRef.IsfcrNil() == false && nextFragmentRef.IsfcrZero() == false)
            {
                var nextFragmentParser = new FileNodeListFragmentParser(nextFragmentRef.Cb);
                var nextFragment = nextFragmentParser.DoDeserializeFromByteArray(byteArray, (int)nextFragmentRef.Stp);
                nextFragmentRef = nextFragment.nextFragment;
                objectGroupList.FileNodeListFragments.Add(nextFragment);
                objectGroupList.FileNodeSequence.AddRange(nextFragment.rgFileNodes.Where(f => f.FileNodeID != FileNodeIDValues.ChunkTerminatorFND));
            }

            return objectGroupList;
        }
    }
}
