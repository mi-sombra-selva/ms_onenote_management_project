﻿using OneNoteFile.Model.Structure.Other.ObjectInfoDependency;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectInfoDependency
{
    internal class ObjectInfoDependencyOverride32Parser
    {
        internal static ObjectInfoDependencyOverride32 DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectInfoDependencyOverride32 = new ObjectInfoDependencyOverride32();
            var index = startIndex;
            objectInfoDependencyOverride32.oid = CompactIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += CompactID.totalSize;
            objectInfoDependencyOverride32.cRef = BitConverter.ToUInt32(byteArray, index);
            return objectInfoDependencyOverride32;
        }
    }
}
