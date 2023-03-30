namespace OneNoteManagementLibrary
{
    /// <summary>
    /// Interface for managing the OneNote.
    /// </summary>
    public interface IOneNoteFileManager
    {
        /// <summary>
        /// Create the OneNote with the specified name.
        /// </summary>
        /// <param name="fileName">Name of the file to create.</param>
        /// <returns>True if the file was successfully created, false otherwise.</returns>
        public bool CreateFile(string fileName);

        /// <summary>
        /// Delete the OneNote with the specified name.
        /// </summary>
        /// <param name="fileName">Name of the file to delete.</param>
        /// <returns>True if the file was successfully deleted, false otherwise.</returns>
        public bool DeleteFile(string fileName);

        /// <summary>
        /// Print the contents of the OneNote with the specified name to the console.
        /// </summary>
        /// <param name="fileName">Name of the file to print.</param>
        public void PrintFileContentsToConsole(string fileName);
    }
}
