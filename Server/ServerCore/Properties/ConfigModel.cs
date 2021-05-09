using System.Collections.Generic;
using Server.ServerCore.Utilities;

namespace Server.ServerCore.Properties
{
    public class ConfigModel
    {
        private readonly IDictionary<string, object> _settings;
        private List<ITableModel> _tables = new List<ITableModel>();
        private string _id;
        private string _uid;
        private string _login;
        private string _password;
        private string _email;

        public ConfigModel(IDictionary<string, object> settings)
        {
            _settings = settings.GetNode("database");
            _id = settings.
        }
    }
}