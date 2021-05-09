using System.Collections.Generic;
using Server.ServerCore.Properties;

namespace Server.ServerCore.Databases.Config
{
    public class TableFactory
    {
        public IProperty Create(object key)
        {
            switch (key)
            {
                case "int":
                    return new IntProperty();
                case "string":
                    return new StringProperty();
                case "float":
                    return new FloatProperty();
                case "bool":
                    return new BoolProperty();
                case "char":
                    return new CharProperty();
                case "byte":
                    return new ByteProperty();
                default:
                    return null;
            }
        }
    }
}