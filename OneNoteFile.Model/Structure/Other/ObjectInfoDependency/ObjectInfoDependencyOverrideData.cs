namespace OneNoteFile.Model.Structure.Other.ObjectInfoDependency
{
    internal class ObjectInfoDependencyOverrideData
    {
        internal uint c8BitOverrides { get; set; }
        internal uint c32BitOverrides { get; set; }
        internal uint crc { get; set; }
        internal ObjectInfoDependencyOverride8[] Overrides1 { get; set; }
        internal ObjectInfoDependencyOverride32[] Overrides2 { get; set; }
    }
}
