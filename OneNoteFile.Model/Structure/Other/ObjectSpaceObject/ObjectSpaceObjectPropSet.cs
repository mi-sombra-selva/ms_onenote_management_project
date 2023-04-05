using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Model.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectPropSet
    {
        internal int Size
        {
            get
            {
                return OIDs.Size + OSIDs.Size + ContextIDs.Size + Body.Size + Padding.Length;
            }
        }

        internal ObjectSpaceObjectStreamOfOIDs OIDs { get; set; }
        internal ObjectSpaceObjectStreamOfOSIDs OSIDs { get; set; }
        internal ObjectSpaceObjectStreamOfContextIDs ContextIDs { get; set; }
        internal PropertySet Body { get; set; }
        internal byte[] Padding { get; set; }
    }
}
