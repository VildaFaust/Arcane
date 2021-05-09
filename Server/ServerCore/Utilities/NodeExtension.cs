using System;
using System.Collections.Generic;

namespace Server.ServerCore.Utilities
{
    public static class NodeExtension
    {
        public static IDictionary<string, object> GetNode(this IDictionary<string, object> node, string nodeKey)
        {
            return (IDictionary<string, object>) node[nodeKey];
        }

        public static string GetString(this IDictionary<string, object> node, string nodeKey)
        {
            return (string) node[nodeKey];
        }
        
        public static bool GetBool(this IDictionary<string, object> node, string nodeKey)
        {
            return (bool) node[nodeKey];
        }
        
        public static int GetInt(this IDictionary<string, object> node, string nodeKey)
        {
            return Convert.ToInt32(node[nodeKey]);
        }

        public static float GetFloat(this IDictionary<string, object> node, string nodeKey)
        {
            return Convert.ToSingle(node[nodeKey]);
        }
           
        public static List<object> GetArrayObject(this IDictionary<string, object> node, string nodeKey)
        {
            return (List<object>) node[nodeKey];
        }

        public static List<int> GetTypeArray(this IDictionary<string, object> node, string nodeKey)
        {
            var list = (List<object>) node[nodeKey];
            var newList = new List<int>();

            foreach (var item in list)
            {
                newList.Add(Convert.ToInt32( item));
            }
            
            return newList;
        }

        public static List<string> GetStingArray(this IDictionary<string, object> node, string nodeKey)
        {
            List<string> arr = new List<string>();

            var s = (List<object>)node[nodeKey];

            foreach (var a in s)
            {
                arr.Add((string)a);   
            }
            
            return arr;
        }

        public static T GetObject<T>(this IDictionary<string, object> node, string nodeKey)
        {
            return (T) node[nodeKey];
        }
    }
}