using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class PrtArrayOfPropertyValuesParser : PropertyParser
    {
        internal override PrtArrayOfPropertyValues DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var prtArrayOfPropertyValues = new PrtArrayOfPropertyValues();
            var index = startIndex;
            prtArrayOfPropertyValues.CProperties = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            prtArrayOfPropertyValues.Prid = PropertyIDParser.DoDeserializeFromByteArray(byteArray, index);
            index += PropertyID.totalSize;
            prtArrayOfPropertyValues.Data = new PropertySet[prtArrayOfPropertyValues.CProperties];
            for (var i = 0; i < prtArrayOfPropertyValues.CProperties; i++)
            {
                prtArrayOfPropertyValues.Data[i] = new PropertySetParser().DoDeserializeFromByteArray(byteArray, index);
                index += prtArrayOfPropertyValues.Data[i].Size;
            }

            return prtArrayOfPropertyValues;
        }
    }
}
