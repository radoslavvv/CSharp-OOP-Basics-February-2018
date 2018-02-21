using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] matrixSizes = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = CreateMatrix(matrixSizes);

        Player ivo = new Player(0,0);
        Player enemy = new Player(0,0);

        string command = Console.ReadLine();
        while (command != "Let the Force be with you")
        {
            int[] ivoPosition = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] enemyPosition = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SetNewStartingPoints(ivo, enemy, ivoPosition, enemyPosition);
            MovePlayers(matrix, ivo, enemy);

            command = Console.ReadLine();
        }
        Console.WriteLine(ivo.Sum);
    }

    private static void MovePlayers(int[,] matrix, Player ivo, Player enemy)
    {
        enemy.MoveEnemy(matrix);
        ivo.MoveIvo(matrix);
    }

    private static void SetNewStartingPoints(Player ivo, Player enemy, int[] ivoPosition, int[] enemyPosition)
    {
        enemy.Row = enemyPosition[0];
        enemy.Col = enemyPosition[1];

        ivo.Row = ivoPosition[0];
        ivo.Col = ivoPosition[1];
    }

    private static int[,] CreateMatrix(int[] dimestions)
    {
        int[,] matrix = new int[dimestions[0], dimestions[1]];

        int value = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = value;
                value++;
            }
        }

        return matrix;
    }
}

