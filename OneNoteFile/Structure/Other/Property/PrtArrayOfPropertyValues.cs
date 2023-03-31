namespace OneNoteFile.Structure.Other.Property
{
    internal class PrtArrayOfPropertyValues : IProperty
    {
        internal uint CProperties { get; set; }
        internal PropertyID Prid { get; set; }
        internal PropertySet[] Data { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            CProperties = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            Prid = new PropertyID();
            var len = Prid.DoDeserializeFromByteArray(byteArray, index);
            index += len;
            Data = new PropertySet[CProperties];
            for (var i = 0; i < CProperties; i++)
            {
                Data[i] = new PropertySet();
                var length = Data[i].DoDeserializeFromByteArray(byteArray, index);
                index += length;
            }

            return index - startIndex;
        }
    }
}
