using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class Canvas
    {
        //private const int _columns = 12;
        //private const int _lines = 12;
        private readonly uint _color;
        public int Width { get; }
        public int Height { get; }

        public Canvas(uint color, int width, int height)
        {
            _color = color;
            Width = width;
            Height = height;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, 0, 0, Width, Height);
            graphics.DrawLine(0xFFbd1a1a, 480, 0, 480, 480, 1);
            graphics.DrawLine(0xFFbd1a1a, 0, 480, 480, 480, 1);
        }
    }
}
