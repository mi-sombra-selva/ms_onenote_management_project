# OneNoteManagement

The OneNoteManagementLibrary library provides a way to read and manipulate OneNote documents. It includes methods for opening, modifying, and saving OneNote files, as well as retrieving text objects from within the document.

## Getting Started
To use the `OneNoteManagementLibrary` library in your project, simply add a reference to the library and import the `OneNoteFileManager` namespace. Then create an instance of the `OneNoteFileManager` class using the path to the OneNote file you wish to work with.

```csharp
using OneNoteFileManager;

// create an instance of the OneNoteFileManager class
var manager = new OneNoteFileManager("path/to/my/OneNoteFile.one");
```

## Usage
The library provides an interface `IOneNoteFileManager` with the following methods:

* `Open(string filePath)` - opens the specified OneNote file.
* `GetTextObjects()` - retrieves all text objects in the opened OneNote file.
* `InsertText(string text)` - inserts text into a OneNote file.
* `Save()` - saves all changes made to the OneNote file.
* `Close()` - closes the opened OneNote file.

## Example usage
```csharp
IOneNoteFileManager manager = new OneNoteFileManager()
manager.Open("path/to/file.one");
var textObjects = manager.GetTextObjects();
// Process text objects
```
## Limitations
Currently, the library only supports retrieving text objects from OneNote documents.

## License
This library is licensed under the MIT License.

## Author
Senua Remizova
