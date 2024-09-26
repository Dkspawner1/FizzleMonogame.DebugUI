namespace FizzleMonogame.DebugUI;
using Microsoft.Xna.Framework;
using MonoGame.ImGui;
using ImGuiNET;
using FizzleMonogame.DebugUI.Interfaces;

public class DebugUI<T> where T : IDebuggable
{
    private readonly Game game;
    private ImGUIRenderer renderer;

}
