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
        private readonly uint _color;
        private readonly int xMax = 480;
        private readonly int yMax = 480;
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
            graphics.DrawLine(0xFFbd1a1a, xMax, 0, xMax, yMax, 2);
            graphics.DrawLine(0xFFbd1a1a, 0, yMax, xMax, yMax, 2);
        }
    }
}
