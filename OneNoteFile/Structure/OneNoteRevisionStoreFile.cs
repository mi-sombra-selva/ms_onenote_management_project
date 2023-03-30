namespace OneNoteFile.Structure
{
    internal class OneNoteRevisionStoreFile
    {
        internal static Dictionary<uint, uint> FileNodeCountMapping = new Dictionary<uint, uint>();

        internal Header Header { get; set; }

        internal RootFileNodeList RootFileNodeList { get; set; }

        public OneNoteRevisionStoreFile()
        {
            FileNodeCountMapping.Clear();

            FileNodeCountMapping = new Dictionary<uint, uint>();
        }

        internal void DoDeserializeFromByteArray(byte[] byteArray)
        {
            var index = 0;
            Header = new Header();
            Header.DoDeserializeFromByteArray(byteArray, index);

            var transLogRef = Header.fcrTransactionLog;
            do
            {
                var transLogFragment = new TransactionLogFragment(transLogRef.Cb);
                transLogFragment.DoDeserializeFromByteArray(byteArray, (int)transLogRef.Stp);
                transLogRef = transLogFragment.nextFragment;
                foreach (var entry in transLogFragment.sizeTable.Where(t => t.srcID != 0x00000001).ToArray())
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

            if (Header.fcrFileNodeListRoot.IsfcrNil() == false && Header.fcrFileNodeListRoot.IsfcrZero() == false)
            {
                RootFileNodeList = new RootFileNodeList();
                RootFileNodeList.DoDeserializeFromByteArray(byteArray, Header.fcrFileNodeListRoot);
            }
        }
    }
}
