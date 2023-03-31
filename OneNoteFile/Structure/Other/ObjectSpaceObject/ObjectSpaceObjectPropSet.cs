using OneNoteFile.Structure.Other.Property;

namespace OneNoteFile.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectPropSet
    {
        internal ObjectSpaceObjectStreamOfOIDs OIDs { get; set; }
        internal ObjectSpaceObjectStreamOfOSIDs OSIDs { get; set; }
        internal ObjectSpaceObjectStreamOfContextIDs ContextIDs { get; set; }
        internal PropertySet Body { get; set; }
        internal byte[] Padding { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            OIDs = new ObjectSpaceObjectStreamOfOIDs();
            var len = OIDs.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            if (OIDs.Header.OsidStreamNotPresent == 0)
            {
                OSIDs = new ObjectSpaceObjectStreamOfOSIDs();
                len = OSIDs.DoDeserializeFromByteArray(byteArray, index);
                index += len;

                if (OSIDs.Header.ExtendedStreamsPresent == 1)
                {
                    ContextIDs = new ObjectSpaceObjectStreamOfContextIDs();
                    len = ContextIDs.DoDeserializeFromByteArray(byteArray, index);
                    index += len;
                }
            }

            Body = new PropertySet();
            len = Body.DoDeserializeFromByteArray(byteArray, index);
            index += len;

            var paddingLength = 8 - (index - startIndex) % 8;
            if (paddingLength < 8)
            {
                Padding = new byte[paddingLength];
                index += paddingLength;
            }
            return index - startIndex;
        }
    }
}
