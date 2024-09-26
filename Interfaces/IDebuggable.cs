using System.Collections.Generic;
namespace FizzleMonogame.DebugUI.Interfaces;
public interface IDebuggable { List<DebugProperty> GetDebugProperties() => DebuggableHelper.GetDebugProperties(this); }
