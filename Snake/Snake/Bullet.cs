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
        protected const int size = 20;
        protected int _x, _y;
        protected readonly uint _color;
        protected const int speed = 2;

        public Bullet(uint color, int x, int y)
        {
            _color = color;
            _x = x;
            _y = y;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(_color, _x, _y, size, size);
        }

        public void Update(Canvas canvas)
        {
            if (Input.IsKeyDown(Keys.LEFT) && !Input.IsKeyDown(Keys.DOWN) && !Input.IsKeyDown(Keys.UP))
            {
                _x -= speed;
                if (_x < 0)
                    _x = canvas.ClientWidth;
            }
            if (Input.IsKeyDown(Keys.RIGHT) && !Input.IsKeyDown(Keys.DOWN) && !Input.IsKeyDown(Keys.UP))
            {
                _x += speed;
                if (_x > canvas.ClientWidth)
                    _x = 0;
            }
            if (Input.IsKeyDown(Keys.UP))
            {
                _y -= speed;
                if (_y < 0)
                    _y = canvas.ClientHeight;
            }
            if (Input.IsKeyDown(Keys.DOWN))
            {
                _y += speed;
                if (_y > canvas.ClientHeight)
                    _y = 0;
            }


        }
    }
}
