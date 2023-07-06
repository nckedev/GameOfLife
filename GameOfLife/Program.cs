// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Raylib_cs;

namespace GameOfLife;

static class Program
{
    public static void Main()
    {
        var isDebugViewEnabled = false;
        var menuWidth = 200;
        var bottomBarHeight = 50;
        var game = new Game();
        game.SetRandomStart(0);
        // game.SetBlockStart();
        Raylib.InitWindow(Settings.TotalWidth, Settings.TotalHeight, "Game of Life");
        Raylib.SetTargetFPS(Settings.TargetFPS);

        var lastupdate = Raylib.GetTime();

        while (!Raylib.WindowShouldClose())
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
            {
                isDebugViewEnabled = !isDebugViewEnabled;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
            {
                game = new Game();
                game.SetRandomStart(0, 0.2);
            }

            if (Raylib.GetTime() - lastupdate >= Settings.UpdateInteval)
            {
                game.MoveToNextGeneration();
                lastupdate = Raylib.GetTime();
            }

            DebugInfo.Add("Generation", game.Generation.ToString());

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            RenderGrid(menuWidth, 0, game.Current);
            RenderMenu(0, 0);
            RenderBottomBar(0, Settings.GridHeight, Settings.TotalWidth, Settings.BottomBarHeight);
            if (isDebugViewEnabled)
                RenderDebugInfo();
            Raylib.DrawFPS(100, 100);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private static void RenderMenu(int x, int y)
    {
        Raylib.DrawText("menu", x, y, 29, Color.BLACK);
        MenuControls.DrawSlider(x, y +100, 100, 5, 0, 1, ref Settings.TestRef, "title");
    }

    private static void RenderBottomBar(int x, int y, int w, int h)
    {
        Raylib.DrawText("bottomBar", x, y, 12, Color.BLACK);
    }

    private static void RenderGrid(int x, int y, Board b)
    {
        DebugInfo.Add("ColCount", Settings.ColCount.ToString());
        DebugInfo.Add("CellWidth", Settings.CellWidth.ToString());

        foreach (var cell in b.IterateCells())
        {
            if (cell.Cell.Active)
            {
                Raylib.DrawRectangle(
                    (cell.Row * Settings.CellHeight) + x,
                    cell.Col * Settings.CellWidth,
                    Settings.CellWidth,
                    Settings.CellHeight,
                    Color.BLACK);
            }
            else
            {
                // Raylib.DrawRectangleLinesEx(new Rectangle(
                //     cell.Row * Settings.CellHeight,
                //     cell.Col * Settings.CellWidth,
                //     Settings.CellWidth,
                //     Settings.CellHeight
                // ), 1, Color.BLACK);
            }
        }
    }

    private static void RenderDebugInfo()
    {
        var offset = 10;
        foreach (var kv in DebugInfo.InternalDict)
        {
            Raylib.DrawText(kv.Key, 10, offset, 20, Color.RED);
            Raylib.DrawText(kv.Value, 200, offset, 20, Color.RED);
            offset += 20;
        }
    }
}