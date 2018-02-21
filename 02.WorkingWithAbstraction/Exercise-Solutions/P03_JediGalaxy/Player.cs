public class Player
{
    private int row;
    private int col;
    private long sum;

    public Player(int row, int col)
    {
        this.row = row;
        this.col = col;
        this.sum = 0;
    }

    public int[,] MoveEnemy(int[,] matrix)
    {
        while (this.Row >= 0 && this.Col >= 0)
        {
            if (IsInMatrix(matrix, this.Row, this.Col))
            {
                matrix[this.Row, this.Col] = 0;
            }
            this.Row--;
            this.Col--;
        }
        return matrix;
    }

    public int[,] MoveIvo(int[,] matrix)
    {
        while (this.Row >= 0 && this.Col < matrix.GetLength(1))
        {
            if (IsInMatrix(matrix, this.Row, this.Col))
            {
                this.Sum += matrix[this.Row, this.Col];
            }

            this.Row--;
            this.Col++;
        }
        return matrix;
    }

    private bool IsInMatrix(int[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) 
            && col >= 0 && col < matrix.GetLength(1);
    }

    public int Row { get => row; set => row = value; }
    public int Col { get => col; set => col = value; }
    public long Sum { get => sum; set => sum = value; }
}
