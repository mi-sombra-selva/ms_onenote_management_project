using OneNoteFile.FileNodeStructure.Types;
using OneNoteFile.Structure;
using OneNoteFile.Structure.Other;
using OneNoteFile.Structure.Other.Property;
using System.Text;

namespace OneNoteManagementLibrary
{
    /// <summary>
    /// Implementation for interacting with a OneNote document file.
    /// </summary>
    public class OneNoteFileManager : IOneNoteFileManager
    {
        private readonly string _filePath;
        private OneNoteRevisionStoreFile _file { get; set; } = new OneNoteRevisionStoreFile();

        /// <summary>
        /// Initializes a new instance of the <see cref="OneNoteFileManager"/> class with the specified file path.
        /// </summary>
        /// <param name="filePath">The file path of the OneNote document.</param>
        public OneNoteFileManager(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Opens a OneNote document.
        /// </summary>
        public void Open()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("OneNote file not found.", _filePath);
            }

            var buffer = File.ReadAllBytes(_filePath);
            _file = new OneNoteRevisionStoreFile();
            _file.DoDeserializeFromByteArray(buffer);
        }

        /// <summary>
        /// Gets the text content of all text containers in the current OneNote document.
        /// </summary>
        /// <returns>An enumerable collection of strings representing the text content of all text containers.</returns>
        public IEnumerable<string> GetTextContent()
        {
            var result = new List<string>();

            var objectSpaceManifestListReferenceFND = _file.RootFileNodeList.ObjectSpaceManifestList.SelectMany(osm => osm.RevisionManifestList).ToList();
            var revisionManifestListReferenceFND = objectSpaceManifestListReferenceFND.SelectMany(rm => rm.ObjectGroupList).ToList();
            var objectDeclaration2RefCountFNDList = revisionManifestListReferenceFND.SelectMany(og => og.FileNodeSequence)
                                                                                .Where(fileNode => fileNode.fnd is ObjectDeclaration2RefCountFND)
                                                                                .ToList();

            foreach (var od2rc in objectDeclaration2RefCountFNDList)
            {
                var fileNodeCast = (ObjectDeclaration2RefCountFND)od2rc.fnd;
                if ((JCIDType)fileNodeCast.body.jcid.Index is JCIDType.PageObjectMetaData)
                {
                    var rgDataList = fileNodeCast.PropertySet.Body.RgData;
                    foreach (var rgData in rgDataList)
                    {
                        if (rgData as PrtFourBytesOfLengthFollowedByData != null)
                        {
                            result.Add(Encoding.UTF8.GetString(((PrtFourBytesOfLengthFollowedByData)rgData).Data));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Inserts text into a OneNote page.
        /// </summary>
        /// <param name="text">The text to insert into the page.</param>
        public void InsertText(string text)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the current OneNote document.
        /// </summary>
        public void Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the current OneNote document.
        /// </summary>
        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
