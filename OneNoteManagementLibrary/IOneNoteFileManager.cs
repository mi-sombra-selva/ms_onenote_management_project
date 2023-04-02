namespace OneNoteManagementLibrary
{
    /// <summary>
    /// Interface for interacting with a OneNote document file.
    /// </summary>
    public interface IOneNoteFileManager
    {
        /// <summary>
        /// Opens a OneNote document.
        /// </summary>
        void Open();

        /// <summary>
        /// Saves the current OneNote document.
        /// </summary>
        void Save();

        /// <summary>
        /// Closes the current OneNote document.
        /// </summary>
        void Close();

        /// <summary>
        /// Inserts text into a OneNote page.
        /// </summary>
        /// <param name="text">The text to insert into the page.</param>
        void InsertText(string text);

        /// <summary>
        /// Gets the text content of all text containers in the current OneNote document.
        /// </summary>
        /// <returns>An enumerable collection of strings representing the text content of all text containers.</returns>
        IEnumerable<string> GetTextContent();
    }
}
