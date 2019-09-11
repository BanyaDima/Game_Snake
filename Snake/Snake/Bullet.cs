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
        protected int _x, _y;
        protected  uint _color;
        protected const int speed = 40;
        private string direction;

        public Bullet(uint color, int x, int y, ConsoleGraphics graphics)
        {
            _color = color;
            _x = x;
            _y = y;
            _graphics = graphics;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, _x, _y, size, size);
        }

        public void Update()
        {
            if (Input.IsKeyDown(Keys.LEFT) && !Input.IsKeyDown(Keys.DOWN) && !Input.IsKeyDown(Keys.UP))
            {
                direction = "Left";;
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
                    _x += speed;
                    if (_x > _graphics.ClientWidth)
                        _x = 0;
                    break;
                case "Left":
                    _x -= speed;
                    if (_x < 0)
                        _x = _graphics.ClientWidth;
                    break;
                case "Down":
                    _y += speed;
                    if (_y > _graphics.ClientHeight)
                        _y =0 ;
                    break;
                case "Up":
                    _y -= speed;
                    if (_y < 0)
                        _y = _graphics.ClientHeight;
                    break;
                default:
                    break;
            }

        }
    }
}
