using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class RevisionManifestListStartFND : FileNodeBase
    {
        internal ExtendedGUID gosid { get; set; }
        internal byte[] nInstance { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            gosid = new ExtendedGUID();
            var len = gosid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            nInstance = new byte[4];
            Array.Copy(byteArray, index, nInstance, 0, 4);
            index += 4;

            return index - startIndex;
        }
    }
}
