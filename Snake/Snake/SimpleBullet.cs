using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class SimpleBullet : Bullet, IGameObject
    {
        private const int size = 40;
        private int _x, _y;
        private uint _color;
        private const int speed = 0;
        private ConsoleGraphics _graphics;

        public SimpleBullet(uint color, int x, int y, ConsoleGraphics graphics) : base(color, x, y, graphics)
        {
            _color = color;
            _x = x;
            _y = y;
            _graphics = graphics;
        }
        public static SimpleBullet[,] SimpleBulletsMas()
        {
            SimpleBullet[,] simpleBullets = new SimpleBullet[11, 11];
            for (int i = 0; i < 11; i++)
            {
                int y = 0;

                for (int j = 0; j < 11; j++)
                {
                    
                    int x = 0;
                    simpleBullets[i, j]._x = x;
                    simpleBullets[i, j]._y = j;
                    simpleBullets[i, j]._color = 0xFF00FF00;
                    x += 40;
                }
                y += 40;
            }

            return simpleBullets;
        }


        public void Render(ConsoleGraphics _graphics)
        {
            _graphics.FillRectangle(_color, _x, _y, size, size);
        }
        public void Update() { }

    }
}
