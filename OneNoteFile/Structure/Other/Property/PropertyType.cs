namespace OneNoteFile.Structure.Other.Property
{
    internal enum PropertyType : uint
    {
        NoData = 0x1,
        Bool = 0x2,
        OneByteOfData = 0x3,
        TwoBytesOfData = 0x4,
        FourBytesOfData = 0x5,
        EightBytesOfData = 0x6,
        FourBytesOfLengthFollowedByData = 0x7,
        ObjectID = 0x8,
        ArrayOfObjectIDs = 0x9,
        ObjectSpaceID = 0xA,
        ArrayOfObjectSpaceIDs = 0xB,
        ContextID = 0xC,
        ArrayOfContextIDs = 0xD,
        ArrayOfPropertyValues = 0x10,
        PropertySet = 0x11
    }
}
