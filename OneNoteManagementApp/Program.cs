using OneNoteManagementLibrary;

namespace OneNoteManagementApp
{
    public class Program
    {
        public static void Main()
        {
            var manager = new OneNoteFileManager();
            manager.PrintFileContentsToConsole(@".\..\..\..\..\TestData\example\I_m_section.one");
        }
    }
}