using System.Collections.Generic;
using LiteDB;
using Server.ServerCore.Properties;

namespace Server.ServerCore.Databases.Config
{
    public class Table
    {
        private readonly Dictionary<string, IProperty> _properties = new Dictionary<string, IProperty>();
        
        public Table(TableFactory factory, IDictionary<string, object> node)
        {
            foreach (var field in node)
            {
                _properties.Add(field.Key, factory.Create(field.Value));        
            }
        }
    }
}