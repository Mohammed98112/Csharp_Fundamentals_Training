using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();

        double angle = 0;
        ConsoleColor[] colors = {
            ConsoleColor.Cyan,
            ConsoleColor.Yellow,
            ConsoleColor.Magenta,
            ConsoleColor.Green,
            ConsoleColor.Red,
            ConsoleColor.Blue
        };

        int colorIndex = 0;

        while (!Console.KeyAvailable)
        {
            Console.Clear();

            Console.ForegroundColor = colors[colorIndex];

            DrawCube(angle);

            angle += 0.05;

            // change color every frame
            colorIndex = (colorIndex + 1) % colors.Length;

            Thread.Sleep(60);
        }

        Console.ResetColor();
        Console.CursorVisible = true;
    }

    static void DrawCube(double angle)
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        for (int i = -10; i <= 10; i += 2)
        {
            for (int j = -10; j <= 10; j += 2)
            {
                double x = i;
                double y = j;
                double z = 10;

                // rotation Y
                double x1 = x * Math.Cos(angle) - z * Math.Sin(angle);
                double z1 = x * Math.Sin(angle) + z * Math.Cos(angle);

                // rotation X
                double y1 = y * Math.Cos(angle) - z1 * Math.Sin(angle);

                z1 += 30;

                int screenX = (int)(width / 2 + x1 * 2);
                int screenY = (int)(height / 2 + y1);

                if (screenX >= 0 && screenX < width &&
                    screenY >= 0 && screenY < height)
                {
                    Console.SetCursorPosition(screenX, screenY);
                    Console.Write("*");
                }
            }
        }
    }
}