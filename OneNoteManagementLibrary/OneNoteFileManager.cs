using OneNoteFile.FileNodeStructure.Types;
using OneNoteFile.Structure;

namespace OneNoteManagementLibrary
{
    /// <summary>
    /// Implementation of the IOneNoteFileManager interface that uses the standard System.IO library to perform file operations.
    /// </summary>
    public class OneNoteFileManager : IOneNoteFileManager
    {
        /// <summary>
        /// Create the OneNote with the specified name.
        /// </summary>
        /// <param name="fileName">Name of the file to create.</param>
        /// <returns>True if the file was successfully created, false otherwise.</returns>
        public bool CreateFile(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the OneNote file with the specified name.
        /// </summary>
        /// <param name="fileName">Name of the file to delete.</param>
        /// <returns>True if the file was successfully deleted, false otherwise.</returns>
        public bool DeleteFile(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the contents of the OneNote with the specified name to the console.
        /// </summary>
        /// <param name="fileName">Name of the file to print.</param>
        public void PrintFileContentsToConsole(string fileName)
        {
            var buffer = File.ReadAllBytes(fileName);
            var oneNoteFile = new OneNoteRevisionStoreFile();
            oneNoteFile.DoDeserializeFromByteArray(buffer);

            foreach (var item in oneNoteFile.RootFileNodeList
                                            .ObjectSpaceManifestList.FirstOrDefault()
                                            .RevisionManifestList.FirstOrDefault()
                                            .ObjectGroupList)
            {
                foreach (var fileNode in item.FileNodeSequence)
                {
                    var fileNodeRightFormat = fileNode.fnd as ObjectDeclaration2RefCountFND;
                    if (fileNodeRightFormat != null)
                    {
                        var bla = 123;
                    }
                }
            }
        }
    }
}
