﻿using OneNoteFile.Model.Structure.Other.ObjectSpaceObject;
using OneNoteFile.Parser.BinaryParser.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectPropSetParser
    {
        internal static ObjectSpaceObjectPropSet DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectSpaceObjectPropSet = new ObjectSpaceObjectPropSet();
            var index = startIndex;
            objectSpaceObjectPropSet.OIDs = ObjectSpaceObjectStreamOfOIDsParser.DoDeserializeFromByteArray(byteArray, index);
            index += objectSpaceObjectPropSet.OIDs.Size;
            if (objectSpaceObjectPropSet.OIDs.Header.OsidStreamNotPresent == 0)
            {
                objectSpaceObjectPropSet.OSIDs = ObjectSpaceObjectStreamOfOSIDsParser.DoDeserializeFromByteArray(byteArray, index);
                index += objectSpaceObjectPropSet.OSIDs.Size;

                if (objectSpaceObjectPropSet.OSIDs.Header.ExtendedStreamsPresent == 1)
                {
                    objectSpaceObjectPropSet.ContextIDs = ObjectSpaceObjectStreamOfContextIDsParser.DoDeserializeFromByteArray(byteArray, index);
                    index += objectSpaceObjectPropSet.ContextIDs.Size;
                }
            }

            objectSpaceObjectPropSet.Body = new PropertySetParser().DoDeserializeFromByteArray(byteArray, index);
            index += objectSpaceObjectPropSet.Body.Size;

            var paddingLength = 8 - (index - startIndex) % 8;
            if (paddingLength < 8)
            {
                objectSpaceObjectPropSet.Padding = new byte[paddingLength];
            }
            return objectSpaceObjectPropSet;
        }
    }
}
