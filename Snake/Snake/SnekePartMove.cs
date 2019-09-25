using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class SnekePartMove : IGameObject
    {
        protected ConsoleGraphics _graphics;
        protected const int size = 40;
        protected readonly uint _color;
        protected const int speed = 40;
        protected const int _columns = 12;
        protected const int _lines = 12;
        private readonly int SideBorder = 480;
        private readonly int BottomLine = 480;
        private int xSpeed;
        private int ySpeed;
        public int X { get; internal set; }
        public int Y { get; internal set; }

        public SnekePartMove(uint color, int x, int y, ConsoleGraphics graphics)
        {
            _graphics = graphics;
            _color = color;
            X = x;
            Y = y;
        }

        public virtual void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, X, Y, size, size);
        }

        public bool IsAlive()
        {
            if (X > SideBorder - size || Y > BottomLine - size)
                return false;
            else if (X < 0 || Y < 0)
                return false;
            else
                return true;
        }

        public void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.LEFT))
            {
                ySpeed = 0;
                xSpeed = 0;
                xSpeed -= speed;
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                ySpeed = 0;
                xSpeed = 0;
                xSpeed += speed;
            }
            else if (Input.IsKeyDown(Keys.UP))
            {
                xSpeed = 0;
                ySpeed = 0;
                ySpeed -= speed;
            }
            else if (Input.IsKeyDown(Keys.DOWN))
            {
                xSpeed = 0;
                ySpeed = 0;
                ySpeed += speed;
            }

            X += xSpeed;
            Y += ySpeed;    
        }
    }
}
