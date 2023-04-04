using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.Other
{
    internal class ObjectDeclaration2Body
    {
        internal const int totalSize = CompactID.totalSize + JCID.totalSize + 1;

        internal CompactID oid { get; set; }

        internal JCID jcid { get; set; }

        internal uint fHasOidReferences { get; set; }

        internal uint fHasOsidReferences { get; set; }

        internal uint fReserved2 { get; set; }
    }
}
