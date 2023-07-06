namespace GameOfLife;

public struct Board
{
    public Cell[][] Cells { get; set; }

    private readonly int _rows;
    private readonly int _cols;

    public Board(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        Cells = new Cell[rows][];
        for (var i = 0; i < Cells.Length; i++)
        {
            Cells[i] = new Cell[cols];
        }

    }

    public IEnumerable<(int Row, int Col, Cell Cell)> IterateCells()
    {
        for (var i = 0; i < Cells.Length; i++)
        {
            for (var j = 0; j < Cells[i].Length; j++)
            {
                var c = Cells[i][j];

                c.AdjCount = CountAdj(i, j);
                yield return (i, j, c);
            }
        }
    }

    public void Reset()
    {
        for (var i = 0; i < Cells.Length; i++)
        {
            for (var j = 0; j < Cells[i].Length; j++)
            {
                Cells[i][j].Active = false;


            }
        }
    }

    public void SetCell(int x, int y, bool state)
    {
        Cells[x][y].Active = state;
    }

    public Cell GetCell(int x, int y) => Cells[x][y];

    public int CountAdj(int x, int y)
    {
        var startx = x == 0 ? 0 : x - 1;
        var endx = x == _rows - 1 ? x : x + 1;

        var starty = y == 0 ? 0 : y - 1;
        var endy = y == _cols - 1 ? y : y + 1;

        int count = 0;

        for (var i = startx; i <= endx; i++)
        {
            for (var j = starty; j <= endy; j++)
            {
                if (i == x && j == y)
                {
                    continue;
                }
                if (Cells[i][j].Active ) //&& !(i == x && j == y))
                {
                    count++;
                }
            }
        }

        return count;
    }
}