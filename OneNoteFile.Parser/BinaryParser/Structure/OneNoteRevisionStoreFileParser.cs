using OneNoteFile.Model.Structure;

namespace OneNoteFile.Parser.BinaryParser.Structure
{
    internal class OneNoteRevisionStoreFileParser
    {
        internal static Dictionary<uint, uint> FileNodeCountMapping = new Dictionary<uint, uint>();
        internal static bool IsEncryption = false;

        public OneNoteRevisionStoreFileParser()
        {
            FileNodeCountMapping.Clear();

            FileNodeCountMapping = new Dictionary<uint, uint>();
            IsEncryption = false;
        }

        internal static OneNoteRevisionStoreFile DoDeserializeFromByteArray(BinaryReader reader)
        {
            var oneNoteRevisionStoreFile = new OneNoteRevisionStoreFile();

            var index = 0;
            oneNoteRevisionStoreFile.Header = HeaderParser.DoDeserializeFromByteArray(reader, index);

            var transLogRef = oneNoteRevisionStoreFile.Header.fcrTransactionLog;
            do
            {
                var transLogFragment = new TransactionLogFragmentParser(transLogRef.Cb).DoDeserializeFromByteArray(reader, (int)transLogRef.Stp);
                transLogRef = transLogFragment.nextFragment;
                foreach (var entry in transLogFragment.sizeTable.Where(t => t.srcID != 0x00000001))
                {
                    if (FileNodeCountMapping.ContainsKey(entry.srcID))
                    {
                        if (FileNodeCountMapping[entry.srcID] < entry.TransactionEntrySwitch)
                        {
                            FileNodeCountMapping[entry.srcID] = entry.TransactionEntrySwitch;
                        }
                    }
                    else
                    {
                        FileNodeCountMapping.Add(entry.srcID, entry.TransactionEntrySwitch);
                    }
                }
            }
            while (transLogRef.IsfcrNil() == false && transLogRef.IsfcrZero() == false);

            if (oneNoteRevisionStoreFile.Header.fcrFileNodeListRoot.IsfcrNil() == false && oneNoteRevisionStoreFile.Header.fcrFileNodeListRoot.IsfcrZero() == false)
            {
                oneNoteRevisionStoreFile.RootFileNodeList = RootFileNodeListParser.DoDeserializeFromByteArray(reader, oneNoteRevisionStoreFile.Header.fcrFileNodeListRoot);
            }

            return oneNoteRevisionStoreFile;
        }
    }
}
