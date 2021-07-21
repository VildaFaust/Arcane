using System.Collections.Generic;

namespace Server.ServerCore.SubjectArea
{
    public class SubjectAreaModel
    {
        private readonly Dictionary<string, SubjectAreaItemModel> _itemModels = new Dictionary<string, SubjectAreaItemModel>();

        public SubjectAreaItemModel Get(string id)
        {
            return _itemModels[id];
        }

        public void Create(SubjectAreaItemData data)
        {
            _itemModels.Add(data.Id,new SubjectAreaItemModel(data));
        }

        public void Remove(string id)
        {
            _itemModels.Remove(id);
        }

        public IEnumerable<SubjectAreaItemModel> GetByTags(List<SubjectTag> tags)
        {
            foreach (var itemModel in _itemModels.Values)
            {
                if (itemModel.ContainsTags(tags))
                {
                    yield return itemModel;
                }
            }
        }

        public void Update(SubjectAreaItemData data)
        {
            _itemModels[data.Id].Update(data);
        }
    }
}