namespace Server.ServerCore.Properties
{
    public static class PropertiesExtension
    {
        public static int ToInt(this IProperty property)
        {
            return ((IntProperty) property).Value;
        }

        public static string ToString(this IProperty property)
        {
            return ((StringProperty) property).Value;
        }
        
        public static bool ToBool(this IProperty property)
        {
            return ((BoolProperty) property).Value;
        }
        
        public static float ToFloat(this IProperty property)
        {
            return ((FloatProperty) property).Value;
        }
        
        public static byte ToByte(this IProperty property)
        {
            return ((ByteProperty) property).Value;
        }
        
        public static char ToChar(this IProperty property)
        {
            return ((CharProperty) property).Value;
        }
    }
}