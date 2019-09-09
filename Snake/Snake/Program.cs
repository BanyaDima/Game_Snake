using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomList;
using NConsoleGraphics;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 60;
            Console.WindowHeight = 40;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            GameEngine game = new GameEngine(graphics);
            game.Play();

        }
    }
}
