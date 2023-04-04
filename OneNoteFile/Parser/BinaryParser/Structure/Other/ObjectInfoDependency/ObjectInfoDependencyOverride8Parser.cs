﻿using OneNoteFile.Model.Structure.Other.ObjectInfoDependency;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectInfoDependency
{
    internal class ObjectInfoDependencyOverride8Parser
    {
        internal static ObjectInfoDependencyOverride8 DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectInfoDependencyOverride8 = new ObjectInfoDependencyOverride8();
            var index = startIndex;
            objectInfoDependencyOverride8.oid = CompactIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += CompactID.totalSize;
            objectInfoDependencyOverride8.cRef = byteArray[index];
            return objectInfoDependencyOverride8;
        }
    }
}
