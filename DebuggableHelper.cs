using System.Reflection;
using FizzleMonogame.DebugUI.Attributes;

namespace FizzleMonogame.DebugUI;

public static class DebuggableHelper
{
    public static List<DebugProperty> GetDebugProperties(object obj, bool includeInherited = true)
    {
        List<DebugProperty> properties = [];
        Type type = obj.GetType();

        while (type != null)
        {
            MemberInfo[] members = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MemberInfo member in members)
            {
                var attribute = member.GetCustomAttribute<DebugVariableAttribute>();
                if (attribute != null)
                {
                    AddDebugProperty(properties, obj, member);
                }
            }

            if (!includeInherited)
                break;

            type = type.BaseType;
        }
        return properties;
    }
    private static void AddDebugProperty(List<DebugProperty> properties, object obj, MemberInfo member)
    {
        string name = member.Name;
        Type memberType = null;
        Func<object> getValue = null;
        Action<object> setValue = null;

        if (member is FieldInfo field)
        {
            memberType = field.FieldType;
            getValue = () => field.GetValue(obj);
            setValue = value => field.SetValue(obj, value);
        }
        else if (member is PropertyInfo property)
        {

            if (property.CanRead)
            {
                memberType = property.PropertyType;
                getValue = () => property.GetValue(obj);
                if (property.CanWrite)
                    setValue = value => property.SetValue(obj, value);
            }
        }
        if (memberType != null && getValue != null)
            properties.Add(new DebugProperty(name, memberType, member.DeclaringType, getValue, setValue));


    }
}
