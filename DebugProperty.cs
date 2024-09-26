namespace FizzleMonogame.DebugUI;

public class DebugProperty(string name, Type type, Type declaringType, Func<object> getter, Action<object> setter)
{
    public string Name { get; set; } = name;
    public Type Type { get; set; } = type;
    public Type DeclaringType { get; set; } = declaringType;
    public Func<object> Getter { get; set; } = getter;
    public Action<object> Setter { get; set; } = setter;
}
