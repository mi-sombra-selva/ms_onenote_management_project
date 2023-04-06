using OneNoteFile.Model.Structure;
using OneNoteFile.Model.Structure.FileNodeStructure.Types;
using OneNoteFile.Model.Structure.Other;
using OneNoteFile.Model.Structure.Other.Property;
using OneNoteFile.Parser;
using System.Text;

namespace OneNoteManagementLibrary
{
    /// <summary>
    /// Implementation for interacting with a OneNote document file.
    /// </summary>
    public class OneNoteFileManager : IOneNoteFileManager
    {
        private readonly static byte[] foundDateTimeData = new byte[5] { 0,0,0,0,3 };

        private readonly string _filePath;
        private readonly IOneNoteFileParserLogic _logic;
        private OneNoteRevisionStoreFile _file { get; set; } = new OneNoteRevisionStoreFile();

        /// <summary>
        /// Initializes a new instance of the <see cref="OneNoteFileManager"/> class with the specified file path.
        /// </summary>
        /// <param name="filePath">The file path of the OneNote document.</param>
        public OneNoteFileManager(string filePath)
        {
            _filePath = filePath;
            _logic = new BinaryOneNoteFileParserLogic();
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

            var parser = new OneNoteFileParser(_logic);

            using var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(stream);
            _file = parser.Parse(reader);
        }

        /// <summary>
        /// Gets the text content of all text containers in the current OneNote document.
        /// </summary>
        /// <returns>An enumerable collection of strings representing the text content of all text containers.</returns>
        public IEnumerable<string> GetTextContent()
        {
            var result = new List<string>();

            var objectDeclaration2RefCountFNDList = _file.RootFileNodeList.ObjectSpaceManifestList.SelectMany(osm => osm.RevisionManifestList)
                                                                                .SelectMany(rm => rm.ObjectGroupList)
                                                                                .SelectMany(og => og.FileNodeSequence)
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
                            var textData = ((PrtFourBytesOfLengthFollowedByData)rgData).Data;
                            if (textData.SequenceEqual(foundDateTimeData))
                            {
                                break; // If such a byte array is found in PropertySet, then there will be information about the date and time of the elements ahead.
                            }
                            result.Add(Encoding.UTF8.GetString(textData));
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
