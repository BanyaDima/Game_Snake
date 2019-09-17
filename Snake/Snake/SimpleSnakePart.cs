using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class SimpleSnakePart : SnekePartMove
    {
        private const int _columns = 12;
        private const int _lines = 12;

        public SimpleSnakePart() : base() { }

        public SimpleSnakePart(uint color, int x, int y, ConsoleGraphics graphics) : base(color, x, y, graphics) { }

        public  void SimplePartsList(ref CustomList.List<SimpleSnakePart> list, ConsoleGraphics _graphics)
        {
            int y = 0;
            for (int i = 0; i < _lines; i++)
            {
                int x = 0;

                for (int j = 0; j < _columns; j++)
                {
                    list.Add(new SimpleSnakePart(0xFF325230, x, y, _graphics));
                    x += 40;
                }
                y += 40;
            }            
        }

        public override void Render(ConsoleGraphics graphics)
        {
            base.Render(graphics);
        }

        public void Contact(SimpleSnakePart simpleBullet, SnekePartMove bullet, ref bool contact)
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
