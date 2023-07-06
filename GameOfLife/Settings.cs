namespace GameOfLife;

public static class Settings
{
    public const int RowCount = 100;
    public const int ColCount = 100;

    public const int GridHeight = 500;
    public const int GridWidth = 500;

    public static int CellHeight => GridHeight / ColCount;
    public static int CellWidth => GridWidth / RowCount;

    public static int MenuWidth = 200;
    public static int BottomBarHeight = 20;
    public static int TotalWidth => GridWidth + MenuWidth;
    public static int TotalHeight => GridHeight + BottomBarHeight;

    public static int TestRef = 10;

    public static int UpdateInteval = 1;

    public const int TargetFPS = 60;
}