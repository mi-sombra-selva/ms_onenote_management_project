using OneNoteFile.Model.Structure.Other.ObjectInfoDependency;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectInfoDependency
{
    internal class ObjectInfoDependencyOverrideDataParser
    {
        internal static ObjectInfoDependencyOverrideData DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectInfoDependencyOverrideData = new ObjectInfoDependencyOverrideData();
            var index = startIndex;
            objectInfoDependencyOverrideData.c8BitOverrides = reader.ReadUInt32FromPosition(index);
            index += 4;
            objectInfoDependencyOverrideData.c32BitOverrides = reader.ReadUInt32FromPosition(index);
            index += 4;
            objectInfoDependencyOverrideData.crc = reader.ReadUInt32FromPosition(index);
            index += 4;

            objectInfoDependencyOverrideData.Overrides1 = new ObjectInfoDependencyOverride8[objectInfoDependencyOverrideData.c8BitOverrides];
            var len = 0;
            for (var i = 0; i < objectInfoDependencyOverrideData.c8BitOverrides; i++)
            {
                objectInfoDependencyOverrideData.Overrides1[i] = ObjectInfoDependencyOverride8Parser.DoDeserializeFromByteArray(reader, index);
                index += len;
            }

            objectInfoDependencyOverrideData.Overrides2 = new ObjectInfoDependencyOverride32[objectInfoDependencyOverrideData.c32BitOverrides];
            for (var j = 0; j < objectInfoDependencyOverrideData.c32BitOverrides; j++)
            {
                objectInfoDependencyOverrideData.Overrides2[j] = ObjectInfoDependencyOverride32Parser.DoDeserializeFromByteArray(reader, index);
                index += len;
            }

            return objectInfoDependencyOverrideData;
        }
    }
}
