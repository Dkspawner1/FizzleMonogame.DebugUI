using Microsoft.Xna.Framework;
using MonoGame.ImGui.Standard;
using ImGuiNET;
using FizzleMonogame.DebugUI.Interfaces;

namespace FizzleMonogame.DebugUI;

public class DebugUI<T> where T : IDebuggable
{
    private readonly Game game;
    private ImGUIRenderer renderer;

    public DebugUI(Game game)
    {
        this.game = game;
        this.renderer = new ImGUIRenderer(game);
        this.renderer.Initialize();
        this.renderer.RebuildFontAtlas();
    }

    public void Draw(GameTime gameTime)
    {
        renderer.BeginLayout(gameTime);

        // Your ImGui drawing code here
        // For example:
        // ImGui.Begin("Debug Window");
        // ImGui.Text("Hello, debug world!");
        // ImGui.End();

        renderer.EndLayout();
    }
}
