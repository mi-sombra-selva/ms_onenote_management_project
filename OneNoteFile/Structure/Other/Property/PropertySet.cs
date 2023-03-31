namespace OneNoteFile.Structure.Other.Property
{
    internal class PropertySet : IProperty
    {
        internal ushort CProperties { get; set; }
        internal PropertyID[] RgPrids { get; set; }
        internal List<IProperty> RgData { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            CProperties = BitConverter.ToUInt16(byteArray, index);
            index += 2;
            RgPrids = new PropertyID[CProperties];
            for (var i = 0; i < CProperties; i++)
            {
                var propertyID = new PropertyID();
                propertyID.DoDeserializeFromByteArray(byteArray, index);
                RgPrids[i] = propertyID;
                index += 4;
            }
            RgData = new List<IProperty>();
            foreach (var propertyID in RgPrids)
            {
                IProperty property = null;
                switch ((PropertyType)propertyID.Type)
                {
                    case PropertyType.NoData:
                    case PropertyType.Bool:
                    case PropertyType.ObjectID:
                    case PropertyType.ContextID:
                    case PropertyType.ObjectSpaceID:
                        property = new NoData();
                        break;
                    case PropertyType.ArrayOfObjectIDs:
                    case PropertyType.ArrayOfObjectSpaceIDs:
                    case PropertyType.ArrayOfContextIDs:
                        property = new ArrayNumber();
                        break;
                    case PropertyType.OneByteOfData:
                        property = new OneByteOfData();
                        break;
                    case PropertyType.TwoBytesOfData:
                        property = new TwoBytesOfData();
                        break;
                    case PropertyType.FourBytesOfData:
                        property = new FourBytesOfData();
                        break;
                    case PropertyType.EightBytesOfData:
                        property = new EightBytesOfData();
                        break;
                    case PropertyType.FourBytesOfLengthFollowedByData:
                        property = new PrtFourBytesOfLengthFollowedByData();
                        break;
                    case PropertyType.ArrayOfPropertyValues:
                        property = new PrtArrayOfPropertyValues();
                        break;
                    case PropertyType.PropertySet:
                        property = new PropertySet();
                        break;
                    default:
                        break;
                }
                if (property != null)
                {
                    var len = property.DoDeserializeFromByteArray(byteArray, index);
                    RgData.Add(property);
                    index += len;
                }
            }

            return index - startIndex;
        }
    }
}
