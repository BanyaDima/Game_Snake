using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class SimpleBullet : Bullet
    {
        private const int _columns = 12;
        private const int _lines = 12;

        public SimpleBullet(uint color, int x, int y, ConsoleGraphics graphics) : base(color, x, y, graphics) { }

        public static CustomList.List<SimpleBullet> SimpleBuletsList(ref CustomList.List<SimpleBullet> list, ConsoleGraphics _graphics)
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

        public override void Render(ConsoleGraphics graphics)
        {
            base.Render(graphics);
        }

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
