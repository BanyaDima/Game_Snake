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
        public SimpleSnakePart(uint color, int x, int y, ConsoleGraphics graphics) : base(color, x, y, graphics) { }

        public SimpleSnakePart CriateSimplePart(CustomList.List<SnekePartMove> list, ConsoleGraphics _graphics)
        {
            Random random = new Random();

            int xCord = size * random.Next(1, _columns);
            int yCord = size * random.Next(1, _lines);

            for (int i = 0; i < list.Count; i++)
            {
                if (xCord == list[i].X && yCord == list[i].Y)
                {
                    i = -1;
                    xCord = size * random.Next(1, _columns);
                    yCord = size * random.Next(1, _lines);
                }
            }
            return new SimpleSnakePart(0xFF325230, xCord, yCord, _graphics);
        }

        public bool Contact(SimpleSnakePart simplePart, SnekePartMove movePart)
        {
            if (simplePart.X == movePart.X && simplePart.Y == movePart.Y)
                return true;
            else
                return false;
        }
    }
}
