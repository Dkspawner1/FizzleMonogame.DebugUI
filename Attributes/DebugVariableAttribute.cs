using System;
namespace FizzleMonogame.DebugUI.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true)]
public class DebugVariableAttribute(bool isEditable = false) : Attribute
{
    public bool IsEditable { get; set; } = isEditable;
}
