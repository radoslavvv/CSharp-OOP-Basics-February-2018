using System;

public class Sneaking
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[][] room = CreateRoom(n);

        char[] moves = Console.ReadLine().ToCharArray();
        int[] samPosition = FindSamPosition(room);

        foreach (char move in moves)
        {
            MoveEnemies(room);

            int[] enemyPosition = FindEnemy(room, samPosition[0]);
            CheckIfSamIsDead(room, samPosition, enemyPosition);

            MoveSam(room, samPosition, move);
            enemyPosition = FindEnemy(room, samPosition[0]);

            CheckIfNikolazeIsDead(room, samPosition, enemyPosition);
        }
    }

    private static void CheckIfNikolazeIsDead(char[][] room, int[] samPosition, int[] enemyPosition)
    {
        if (room[enemyPosition[0]][enemyPosition[1]] == 'N' && samPosition[0] == enemyPosition[0])
        {
            room[enemyPosition[0]][enemyPosition[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");

            PrintRoom(room);
        }
    }

    private static void CheckIfSamIsDead(char[][] room, int[] samPosition, int[] enemyPosition)
    {
        if (enemyPosition[0] == samPosition[0])
        {
            if ((room[enemyPosition[0]][enemyPosition[1]] == 'd' && samPosition[1] < enemyPosition[1]) ||
                (room[enemyPosition[0]][enemyPosition[1]] == 'b' && samPosition[1] > enemyPosition[1]))
            {
                room[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                PrintRoom(room);
            }
        }
    }

    private static int[] FindEnemy(char[][] room, int samRow)
    {
        int[] enemyPosition = new int[2];
        for (int col = 0; col < room[samRow].Length; col++)
        {
            if (room[samRow][col] != '.' && room[samRow][col] != 'S')
            {
                enemyPosition[0] = samRow;
                enemyPosition[1] = col;
            }
        }
        return enemyPosition;
    }

    private static void PrintRoom(char[][] room)
    {
        foreach (char[] row in room)
        {
            Console.WriteLine(string.Join("", row));
        }
        Environment.Exit(0);
    }

    private static void MoveEnemies(char[][] room)
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'b')
                {
                    if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col + 1] = 'b';
                        col++;
                    }
                    else
                    {
                        room[row][col] = 'd';
                    }
                }
                else if (room[row][col] == 'd')
                {
                    if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col - 1] = 'd';
                    }
                    else
                    {
                        room[row][col] = 'b';
                    }
                }
            }
        }
    }

    private static void MoveSam(char[][] room, int[] samPosition, char move)
    {
        room[samPosition[0]][samPosition[1]] = '.';
        switch (move)
        {
            case 'U':
                samPosition[0]--;
                break;
            case 'D':
                samPosition[0]++;
                break;
            case 'L':
                samPosition[1]--;
                break;
            case 'R':
                samPosition[1]++;
                break;
        }
        room[samPosition[0]][samPosition[1]] = 'S';
    }

    private static int[] FindSamPosition(char[][] room)
    {
        int[] samPosition = new int[2];
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'S')
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                }
            }
        }

        return samPosition;
    }

    private static char[][] CreateRoom(int n)
    {
        char[][] room = new char[n][];

        for (int row = 0; row < n; row++)
        {
            var input = Console.ReadLine().ToCharArray();
            room[row] = new char[input.Length];
            for (int col = 0; col < input.Length; col++)
            {
                room[row][col] = input[col];
            }
        }

        return room;
    }
}

