using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class Canvas : IGameObject
    {
        private readonly uint _color;
        public int ClientWidth { get; }
        public int ClientHeight { get; }

        public Canvas(uint color,int clientWidth, int clientHeight)
        {
            _color = color;
            ClientWidth = clientWidth;
            ClientHeight = clientHeight;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, 0, 0, ClientWidth, ClientHeight);
        }

        public void Update(Canvas canvas){}
    }
}
