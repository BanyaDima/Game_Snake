using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Snake
{
    class Bullet : IGameObject
    {
        protected ConsoleGraphics _graphics;       
        protected const int size = 40;
        protected readonly uint _color;
        protected const int speed = 40;
        private string direction;
        public int X { get; private set; }
        public int Y { get; private set; }

        public Bullet(uint color, int x, int y, ConsoleGraphics graphics)
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
        public void AddNewBullet(ref CustomList.List<Bullet> bullet)
        {
            bullet.Add(new Bullet(_color, X, Y,_graphics)); 
        }

        public void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.LEFT) && !Input.IsKeyDown(Keys.DOWN) && !Input.IsKeyDown(Keys.UP))
            {
                direction = "Left"; ;
            }
            if (Input.IsKeyDown(Keys.RIGHT) && !Input.IsKeyDown(Keys.DOWN) && !Input.IsKeyDown(Keys.UP))
            {
                direction = "Right";
            }
            if (Input.IsKeyDown(Keys.UP))
            {
                direction = "Up";
            }
            if (Input.IsKeyDown(Keys.DOWN))
            {
                direction = "Down";
            }

            switch (direction)
            {
                case "Right":
                    X += speed;
                    if (X > _graphics.ClientWidth - size)
                        engine.isAlive = false;
                    break;
                case "Left":
                    X -= speed;
                    if (X < 0)
                        engine.isAlive = false;
                    break;
                case "Down":
                    Y += speed;
                    if (Y > _graphics.ClientHeight + size)
                        engine.isAlive = false;
                    break;
                case "Up":
                    Y -= speed;
                    if (Y < 0)
                        engine.isAlive = false;
                    break;
                default:
                    break;
            }

        }
    }
}
