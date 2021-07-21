using System.Collections.Generic;

namespace Server.ServerCore.SubjectArea
{
    public class SubjectAreaItemData
    {
        public readonly string Id;
        public readonly List<SubjectTag> SubjectTags;
        public readonly string Description;
        public readonly string Author;
        public readonly string Teacher;
        public readonly string Name;
    }
}