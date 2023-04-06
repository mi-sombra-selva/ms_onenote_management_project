using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class PropertySetParser : PropertyParser
    {
        internal override PropertySet DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var propertySet = new PropertySet();
            var index = startIndex;
            propertySet.CProperties = reader.ReadUInt16FromPosition(index);
            index += 2;
            propertySet.RgPrids = new PropertyID[propertySet.CProperties];
            for (var i = 0; i < propertySet.CProperties; i++)
            {
                var propertyID = PropertyIDParser.DoDeserializeFromByteArray(reader, index);
                propertySet.RgPrids[i] = propertyID;
                index += PropertyID.totalSize;
            }
            propertySet.RgData = new List<IProperty>();
            foreach (var propertyID in propertySet.RgPrids)
            {
                PropertyParser propertyParser = null;
                switch ((PropertyType)propertyID.Type)
                {
                    case PropertyType.NoData:
                    case PropertyType.Bool:
                    case PropertyType.ObjectID:
                    case PropertyType.ContextID:
                    case PropertyType.ObjectSpaceID:
                        propertyParser = new NoDataParser();
                        break;
                    case PropertyType.ArrayOfObjectIDs:
                    case PropertyType.ArrayOfObjectSpaceIDs:
                    case PropertyType.ArrayOfContextIDs:
                        propertyParser = new ArrayNumberParser();
                        break;
                    case PropertyType.OneByteOfData:
                        propertyParser = new OneByteOfDataParser();
                        break;
                    case PropertyType.TwoBytesOfData:
                        propertyParser = new TwoBytesOfDataParser();
                        break;
                    case PropertyType.FourBytesOfData:
                        propertyParser = new FourBytesOfDataParser();
                        break;
                    case PropertyType.EightBytesOfData:
                        propertyParser = new EightBytesOfDataParser();
                        break;
                    case PropertyType.FourBytesOfLengthFollowedByData:
                        propertyParser = new PrtFourBytesOfLengthFollowedByDataParser();
                        break;
                    case PropertyType.ArrayOfPropertyValues:
                        propertyParser = new PrtArrayOfPropertyValuesParser();
                        break;
                    case PropertyType.PropertySet:
                        propertyParser = new PropertySetParser();
                        break;
                    default:
                        break;
                }
                if (propertyParser != null)
                {
                    var property = propertyParser.DoDeserializeFromByteArray(reader, index);
                    propertySet.RgData.Add(property);
                    index += property.Size;
                }
            }

            return propertySet;
        }
    }
}
