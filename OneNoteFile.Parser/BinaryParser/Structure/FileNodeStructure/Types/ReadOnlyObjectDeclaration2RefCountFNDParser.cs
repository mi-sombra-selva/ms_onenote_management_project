using OneNoteFile.Model.Structure.FileNodeStructure.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ReadOnlyObjectDeclaration2RefCountFNDParser : FileNodeBaseParser
    {
        private uint stpFormat;
        private uint cbFormat;

        internal ReadOnlyObjectDeclaration2RefCountFNDParser(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override ReadOnlyObjectDeclaration2RefCountFND DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var readOnlyObjectDeclaration2RefCountFND = new ReadOnlyObjectDeclaration2RefCountFND();
            var index = startIndex;
            readOnlyObjectDeclaration2RefCountFND.Base = new ObjectDeclaration2RefCountFNDParser(stpFormat, cbFormat).DoDeserializeFromByteArray(reader, index);
            index += readOnlyObjectDeclaration2RefCountFND.Base.Size;
            readOnlyObjectDeclaration2RefCountFND.md5Hash = reader.ReadBytes(index, 16);
            return readOnlyObjectDeclaration2RefCountFND;
        }
    }
}
