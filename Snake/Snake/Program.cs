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

            while (true)
            {
                ConsoleGraphics graphics = new ConsoleGraphics();
                Canvas canvas = new Canvas(0xffffffff, graphics.ClientWidth, graphics.ClientHeight);
                GameEngine game = new GameEngine(graphics, canvas);

                game.Play();
                
                if (!game.Restart())
                    break;                
            }
        }
    }
}
