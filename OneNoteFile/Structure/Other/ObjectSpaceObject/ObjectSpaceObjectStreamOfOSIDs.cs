using OneNoteFile.Types;

namespace OneNoteFile.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamOfOSIDs
    {
        internal ObjectSpaceObjectStreamHeader Header { get; set; }
        internal CompactID[] Body { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Header = new ObjectSpaceObjectStreamHeader();
            var headerCount = Header.DoDeserializeFromByteArray(byteArray, index);
            index += headerCount;

            Body = new CompactID[Header.Count];
            for (var i = 0; i < Header.Count; i++)
            {
                var compactID = new CompactID();
                var count = compactID.DoDeserializeFromByteArray(byteArray, index);
                Body[i] = compactID;
                index += count;
            }

            return index - startIndex;
        }
    }
}
