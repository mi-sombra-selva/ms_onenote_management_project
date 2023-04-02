using OneNoteManagementLibrary;

namespace OneNoteManagementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: OneNoteManagementApp.exe <pathToOneFile>");
                return;
            }

            var filePath = args[0];

            if (!IsValidFilePath(filePath))
            {
                Console.WriteLine("Invalid file path");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            IOneNoteFileManager manager = new OneNoteFileManager(filePath);
            manager.Open();
            var allTextContent = manager.GetTextContent();

            foreach (var textContent in allTextContent) 
            {
                Console.WriteLine(textContent);
            }
        }

        private static bool IsValidFilePath(string path)
        {
            try
            {
                var fullPath = Path.GetFullPath(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}