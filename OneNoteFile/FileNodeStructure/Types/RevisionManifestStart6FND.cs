using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class RevisionManifestStart6FND : FileNodeBase
    {
        internal ExtendedGUID rid { get; set; }
        internal ExtendedGUID ridDependent { get; set; }
        internal int RevisionRole { get; set; }
        internal ushort odcsDefault { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            rid = new ExtendedGUID();
            var len = rid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            ridDependent = new ExtendedGUID();
            len = ridDependent.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            RevisionRole = BitConverter.ToInt32(byteArray, index);
            index += 4;
            odcsDefault = BitConverter.ToUInt16(byteArray, index);
            index += 2;

            return index - startIndex;
        }
    }
}
