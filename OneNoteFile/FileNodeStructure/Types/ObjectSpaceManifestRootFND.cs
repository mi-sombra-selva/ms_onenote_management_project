using OneNoteFile.Types;

namespace OneNoteFile.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestRootFND : FileNodeBase
    {
        internal ExtendedGUID gosidRoot { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            gosidRoot = new ExtendedGUID();
            var len = gosidRoot.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            return index - startIndex;
        }
    }
}
