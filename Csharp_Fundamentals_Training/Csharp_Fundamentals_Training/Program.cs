using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();

        double angle = 0;

        while (!Console.KeyAvailable)
        {
            Console.Clear();

            DrawCube(angle);

            angle += 0.05;

            Thread.Sleep(40);
        }

        Console.CursorVisible = true;
    }

    static void DrawCube(double angle)
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        double size = 10;

        for (int i = -10; i <= 10; i += 2)
        {
            for (int j = -10; j <= 10; j += 2)
            {
                // 3D point on cube surface
                double x = i;
                double y = j;
                double z = 10;

                // rotate Y axis
                double x1 = x * Math.Cos(angle) - z * Math.Sin(angle);
                double z1 = x * Math.Sin(angle) + z * Math.Cos(angle);

                // rotate X axis
                double y1 = y * Math.Cos(angle) - z1 * Math.Sin(angle);
                double z2 = y * Math.Sin(angle) + z1 * Math.Cos(angle);

                z2 += 30;

                int screenX = (int)(width / 2 + x1 * 2);
                int screenY = (int)(height / 2 + y1);

                if (screenX >= 0 && screenX < width &&
                    screenY >= 0 && screenY < height)
                {
                    Console.SetCursorPosition(screenX, screenY);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("*");
                }
            }
        }
    }
}