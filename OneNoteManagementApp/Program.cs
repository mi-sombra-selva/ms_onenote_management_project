using OneNoteManagementLibrary;

namespace OneNoteManagementApp
{
    public class Program
    {
        public static void Main()
        {
            var manager = new OneNoteFileManager();
            manager.PrintFileContentsToConsole(@"C:\Users\userselva\Documents\OneNote Notebooks\Aspose_example\New Section 1.one");
        }
    }
}