using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;
using CustomList;
using System.Threading;

namespace Snake
{
    class GameEngine
    {
        private CustomList.List<SnekePartMove> snakeParts = new CustomList.List<SnekePartMove>();
        private ConsoleGraphics _graphics;
        private Canvas _canvas;
        private int points;

        public GameEngine(ConsoleGraphics graphics, Canvas canvas)
        {
            _graphics = graphics;
            _canvas = canvas;
        }

        public bool Restart()
        {
            while (true)
            {
                _canvas.Render(_graphics);

                _graphics.DrawString("GAME OVER", "Arial", 0xFFbd1a1a, 100, 200, 30);
                _graphics.DrawString($"You have: {points} points", "Arial", 0xFFbd1a1a, 100, 250, 16);
                _graphics.DrawString($"Do you wont play again?\nPress Y(Yes)/N(No)", "Arial", 0xFFbd1a1a, 100, 270, 16);

                if (Input.IsKeyDown(Keys.KEY_N))
                {
                    return  false;
                }
                else if (Input.IsKeyDown(Keys.KEY_Y))
                {
                     return true;
                }
                _graphics.FlipPages();

                Thread.Sleep(30);
            }
        }

        public void Play()
        {
            SnekePartMove snakePart = new SnekePartMove(0xFF1e8a19, 0, 200, _graphics);
            SimpleSnakePart simpleSnakePart = new SimpleSnakePart(0xFF325230, 400, 200, _graphics);
            Snake snake = new Snake(this);

            snakeParts.Add(snakePart);            

            while (snakePart.IsAlive())
            {
                _canvas.Render(_graphics);

                snake.Render(_graphics, snakeParts);
                snake.Move(snakeParts);

                simpleSnakePart.Render(_graphics);

                if (snake.ContactWithOneself(snakeParts))
                    break;

                if (simpleSnakePart.Contact(simpleSnakePart, snakePart))
                {
                    snakeParts.Add(simpleSnakePart);
                    simpleSnakePart = simpleSnakePart.CriateSimplePart(snakeParts, _graphics);
                    points++;
                }
        
                _graphics.FlipPages();

                Thread.Sleep(100);
            }

        }

    }
}
