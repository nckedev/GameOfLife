namespace GameOfLife;

public class Game
{
    public int Generation { get; private set; }
    public Board Current { get; set; }

    public Game()
    {
        Generation = 1;
        Current = new Board(Settings.RowCount, Settings.ColCount);
    }

    public void MoveToNextGeneration()
    {
        Generation++;
        Current = CalculateNextBoard();
    }

    private Board CalculateNextBoard()
    {
        // Next.Reset();
        var next = new Board(Settings.RowCount, Settings.ColCount);
        foreach (var (row, col, cell) in Current.IterateCells())
        {
            var newState = false;
            if (cell.AdjCount > 3)
            {
                var debug = 1;
            }

            if (cell.Active)
            {
                newState = cell.AdjCount switch
                {
                    < 2 or > 3 => false,
                    _ => true,
                };
            }
            else
            {
                if (cell.AdjCount == 3)
                {
                    newState = true;
                }
            }

            var newState2 = cell switch
            {
                { AdjCount: < 2, Active: true } => false,
                { AdjCount: 2 or 3, Active: true } => true,
                { AdjCount: > 3, Active: true } => false,
                { AdjCount: 3, Active: false } => true,
                _ => false,
            };
            next.SetCell(row, col, newState);
        }

        return next;
    }

    public void SetRandomStart(int seed = 0, double activebias = 0.5)
    {
        if (seed == 0)
        {
            seed = new Random().Next(0, 9999);
        }

        DebugInfo.Add("Seed", seed.ToString());

        var r = new Random(seed);
        foreach (var x in Current.IterateCells())
        {
            var n = r.NextDouble();
            if ( n <= activebias)
                Current.SetCell(x.Row, x.Col, true);
            // Current.SetCell(x.Row, x.Col, r.Next(0, 2) != 0);
        }
    }

    public void SetBlockStart()
    {
        Current.SetCell(5, 2, true);
        Current.SetCell(5, 3, true);
        Current.SetCell(5, 4, true);
    }
}