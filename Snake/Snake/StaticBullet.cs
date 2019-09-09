using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class StaticBullet : Bullet, IGameObject
    {
        private const int size = 20;
        private int _x, _y;
        private readonly uint _color;
        private const int speed = 0;

        public StaticBullet(uint color, int x, int y) : base(color, x, y)
        {
            _color = color;
            _x = x;
            _y = y;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, _x, _y, size, size);
        }
        public void Update()
        {
            
        }

    }
}
