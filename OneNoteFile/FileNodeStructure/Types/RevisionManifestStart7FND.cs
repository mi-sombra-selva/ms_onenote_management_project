using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class RevisionManifestStart7FND : FileNodeBase
    {
        internal RevisionManifestStart6FND Base { get; set; }
        internal ExtendedGUID gctxid { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Base = new RevisionManifestStart6FND();
            var len = Base.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            gctxid = new ExtendedGUID();
            len = gctxid.DoDeserializeFromByteArray(byteArray, index);
            index += len;

            return index - startIndex;
        }
    }
}
