using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestListStartFND : FileNodeBase
    {
        internal ExtendedGUID gosid { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            gosid = new ExtendedGUID();
            return gosid.DoDeserializeFromByteArray(byteArray, startIndex);
        }
    }
}
