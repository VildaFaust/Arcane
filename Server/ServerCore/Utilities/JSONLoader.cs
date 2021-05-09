using System.Collections.Generic;
using System.IO;
using Server.Libs.fastJSON;

namespace Server.ServerCore.Utilities
{
    public static class JsonLoader
    {
        public static Dictionary<string, object> Load(string path)
        {
            var data = File.ReadAllText(path);
            return (Dictionary<string, object>)JSON.Parse(data);
        }
    }
}