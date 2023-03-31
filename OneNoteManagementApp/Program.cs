using OneNoteManagementLibrary;

namespace OneNoteManagementApp
{
    public class Program
    {
        public static void Main()
        {
            IOneNoteFileManager manager = new OneNoteFileManager(@".\..\..\..\..\TestData\example\New Section.one");
            manager.Open();
            var allTextContent = manager.GetTextContent();

            foreach (var textContent in allTextContent) 
            {
                Console.WriteLine(textContent);
            }
        }
    }
}