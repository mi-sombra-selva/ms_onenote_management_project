using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Structure.Other;
using OneNoteFile.Parser.BinaryParser.Structure.Other;
using OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectSpaceObject;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.FileNodeStructure.Types
{
    internal class ObjectDeclaration2RefCountFNDParser : FileNodeBaseParser
    {
        private uint stpFormat;
        private uint cbFormat;

        internal ObjectDeclaration2RefCountFNDParser(uint stpFormat, uint cbFormat)
        {
            this.stpFormat = stpFormat;
            this.cbFormat = cbFormat;
        }

        internal override ObjectDeclaration2RefCountFND DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectDeclaration2RefCountFND = new ObjectDeclaration2RefCountFND();

            var index = startIndex;
            objectDeclaration2RefCountFND.BlobRef = new FileNodeChunkReferenceParser(stpFormat, cbFormat).DoDeserializeFromByteArray(byteArray, index);
            index += objectDeclaration2RefCountFND.BlobRef.Size;
            objectDeclaration2RefCountFND.body = ObjectDeclaration2BodyParser.DoDeserializeFromByteArray(byteArray, index);
            index += ObjectDeclaration2Body.totalSize;
            objectDeclaration2RefCountFND.cRef = byteArray[index];

            if (OneNoteRevisionStoreFileParser.IsEncryption == false)
            {
                objectDeclaration2RefCountFND.PropertySet = ObjectSpaceObjectPropSetParser.DoDeserializeFromByteArray(byteArray, (int)objectDeclaration2RefCountFND.BlobRef.StpValue);
            }
            return objectDeclaration2RefCountFND;
        }
    }
}
