using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

namespace GameOfLife;

public static class MenuControls
{
    public static void DrawSlider(int x, int y, int w, int h, int min, int max, ref int value, string title = "")
    {
        Debug.Assert(max > min);
        
        Raylib.DrawText(title, x, y, 13, Color.BLACK);
        Raylib.DrawText(value.ToString(), x + w -20, y, 13, Color.BLACK);

        var bar = new Rectangle(x, y + 10, w, h);
        Raylib.DrawRectangleRec(bar, Color.RED);

        //todo ca
        var r = new Rectangle(value - 10 + x, y, 20, 20);
        Raylib.DrawRectangleRec(r, Color.PINK);

        bool b = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), r);

        if (b && Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
        {
            var mouseX = Raylib.GetMousePosition().X;
            if (mouseX > bar.x + bar.width) mouseX = bar.x + bar.width;
            if (mouseX < bar.x) mouseX = bar.x;
            
            //todo factor för min och max
            value = (int)mouseX; //- (int)(r.width / 2);
        }
    }

    public static void DrawCheckBox(int x, int y, int size, ref bool value)
    {
    }
}