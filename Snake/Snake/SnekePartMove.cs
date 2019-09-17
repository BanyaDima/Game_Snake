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
        private int xSpeed;
        private int ySpeed;

        public int X { get; internal set; }
        public int Y { get; internal set; }

        public SnekePartMove() { }

        public SnekePartMove(uint color, int x, int y, ConsoleGraphics graphics)
        {
            _color = color;
            X = x;
            Y = y;
            _graphics = graphics;
        }

        public virtual void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, X, Y, size, size);
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

            if (X > _graphics.ClientWidth - size || Y > _graphics.ClientHeight - size)
                engine.isAlive = false;
            else if (X < 0 || Y < 0)
                engine.isAlive = false;
        }
    }
}
