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
        private const int _columns = 12;
        private const int _lines = 12;
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

            int y = 0;
            for (int i = 0; i <_lines; i++)
            {
                int x = 0;
                for (int j = 0; j < _columns; j++)
                {
                    graphics.DrawLine(0xff00ff00, x, y, x, Height, 1);
                    graphics.DrawLine(0xff00ff00, 0, y, Width, y, 1);
                    x += 40;
                }               
                y += 40;
            }
        }
    }
}
