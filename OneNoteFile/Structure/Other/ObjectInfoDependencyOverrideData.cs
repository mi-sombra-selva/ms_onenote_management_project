namespace OneNoteFile.Structure.Other
{
    internal class ObjectInfoDependencyOverrideData
    {
        internal uint c8BitOverrides { get; set; }
        internal uint c32BitOverrides { get; set; }
        internal uint crc { get; set; }
        internal ObjectInfoDependencyOverride8[] Overrides1 { get; set; }
        internal ObjectInfoDependencyOverride32[] Overrides2 { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            c8BitOverrides = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            c32BitOverrides = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            crc = BitConverter.ToUInt32(byteArray, index);
            index += 4;

            Overrides1 = new ObjectInfoDependencyOverride8[c8BitOverrides];
            var len = 0;
            for (var i = 0; i < c8BitOverrides; i++)
            {
                Overrides1[i] = new ObjectInfoDependencyOverride8();
                len = Overrides1[i].DoDeserializeFromByteArray(byteArray, index);
                index += len;
            }

            Overrides2 = new ObjectInfoDependencyOverride32[c32BitOverrides];
            for (var j = 0; j < c32BitOverrides; j++)
            {
                Overrides2[j] = new ObjectInfoDependencyOverride32();
                len = Overrides2[j].DoDeserializeFromByteArray(byteArray, index);
                index += len;
            }

            return index - startIndex;
        }
    }
}
