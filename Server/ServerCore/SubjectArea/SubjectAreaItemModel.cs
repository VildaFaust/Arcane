using System.Collections.Generic;
using System.Linq;

namespace Server.ServerCore.SubjectArea
{
    public class SubjectAreaItemModel
    {
        public List<SubjectTag> Tags { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public string Teacher { get; private set; }
        public string Name { get; private set; }
        
        public SubjectAreaItemModel(SubjectAreaItemData data)
        {
            Tags = data.SubjectTags;
            Description = data.Description;
            Author = data.Author;
            Teacher = data.Teacher;
            Name = data.Name;
        }

        public bool ContainsTags(IEnumerable<SubjectTag> tags)
        {
            return tags.All(tag => Tags.Contains(tag));
        }

        public void Update(SubjectAreaItemData data)
        {
            Tags = data.SubjectTags;
            Description = data.Description;
            Author = data.Author;
            Teacher = data.Teacher;
            Name = data.Name;
        }
    }
}