using System.Collections.Generic;
using System.IO;
using Utilities.Libs.fastJSON;

namespace Utilities
{
    public static class JsonLoader
    {
        public static Dictionary<string, object> Load(string path)
        {
            var data = File.ReadAllText(path);
            
            return (Dictionary<string, object>) JSON.Parse(data);
        }
    }
}