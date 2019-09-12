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
        private uint _color;
        private const int speed = 0;
        private ConsoleGraphics _graphics;
        private const int _columns = 11;
        private const int _lines = 11;
        public int X { get; private set; }
        public int Y { get; private set; }

        public SimpleBullet(uint color, int x, int y, ConsoleGraphics graphics) : base(color, x, y, graphics)
        {
            _color = color;
            X = x;
            Y = y;
            _graphics = graphics;
        }

        public static CustomList.List<IGameObject> SimpleBuletsList(ref CustomList.List<IGameObject> list, ConsoleGraphics _graphics)
        {
            int y = 0;
            for (int i = 0; i < _lines; i++)
            {
                int x = 0;

                for (int j = 0; j < _columns; j++)
                {
                    list.Add(new SimpleBullet(0xFF00FF00, x, y, _graphics));

                    x += 40;
                }
                y += 40;
            }
            return list;
        }

        public void Render(ConsoleGraphics _graphics)
        {
            _graphics.FillRectangle(_color, X, Y, size, size);
        }
        public void Update() { }

        public static void Contact(SimpleBullet simpleBullet, Bullet bullet, ref bool contact)
        {
            if (simpleBullet.X == bullet.X && simpleBullet.Y == bullet.Y)
            {
                contact = true;
            }
            else
            {
                contact = false;
            }                 
        }
    }
}
