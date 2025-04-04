## Solution Description

The chosen solution for working with OneNote files is a C# library that provides methods for opening, modifying, and saving OneNote documents, as well as extracting textual objects from a document.

The solution consists of several projects:
- **`BitManipulator`** – a library that implements a bit reader, which can be used to read bits from a byte stream.
- **`OneNoteFile.Model`** – a library that describes the structure of a `.one` file.
- **`OneNoteFile.Parser`** – a library designed to analyze the `.one` file structure and extract data from it.
- **`OneNoteManagementLibrary`** – a library that provides core methods for working with `.one` files.
- **`OneNoteManagementApp`** – a console utility that demonstrates retrieving and displaying text strings stored in a `.one` file.

### Action Plan for Reading and Parsing a `.one` File:

1. Read the file header (`.one`).
2. Extract the root element list address (`RootFileNodeList`) from the file header.
3. Read the element list and determine their types.
4. From elements of type `ObjectSpaceManifestListReferenceFND`, construct an `ObjectSpaceManifestList`.
5. Read the element list and determine their types.
6. From elements of type `RevisionManifestListReferenceFND`, construct a `RevisionManifestList`.
7. Read the element list and determine their types.
8. From elements of type `ObjectGroupListReferenceFND`, construct an `ObjectGroupList`.
9. Process the contents of each element.
10. To determine the type of each element, check the value of `jcid.index` (`ObjectDeclaration2RefCountFND -> ObjectDeclaration2Body -> JCID -> Index`).
11. Select elements where `JCIDType` is `PageObjectMetaData`.
12. Retrieve data from `ObjectDeclaration2Body -> PropertySet -> Body -> RgData`.
13. Select values from the data list where the type is `PrtFourBytesOfLengthFollowedByData`.
14. If the data list contains the byte array `{ 0,0,0,0,3 }`, it means that this list contains non-text data but rather date/time information.

## Implementation Advantages
- Follows the **Single Responsibility Principle (SRP)**.
- Uses the **Dependency Injection (DI) pattern** to manage dependencies.
- The file parsing implementation details are hidden, simplifying library usage (only necessary methods are exposed).
- **XML comments** are provided for public methods.
- No need for third-party libraries.
- The logic for the **bit reader, file parser, and management library** is not combined into a single monolithic library.

## Implementation Disadvantages
- Many parts of the `.one` file structure are not yet implemented, meaning that expanding file processing logic will require further studying of the documentation and extending the parser.
- Ideally, the **manager class should implement IDisposable** since it works with an external resource (a file). However, since this version only supports reading, this aspect has been omitted.
