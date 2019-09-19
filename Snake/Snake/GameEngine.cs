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
        private ConsoleGraphics _graphics;
        private CustomList.List<SnekePartMove> snakeParts = new CustomList.List<SnekePartMove>();
        private CustomList.List<SimpleSnakePart> simpleSnakeParts = new CustomList.List<SimpleSnakePart>();
        private bool contact = false;
        public bool isAlive = true;
        private int points;
        public bool Restarting { get; private set; }

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        public void Restart()
        {
            Canvas canvas = new Canvas(0xffffffff, _graphics.ClientWidth, _graphics.ClientHeight);

            while (true)
            {
                canvas.Render(_graphics);

                _graphics.DrawString("GAME OVER", "Arial", 0xFFbd1a1a, 100, 200, 30);
                _graphics.DrawString($"You have: {points} points", "Arial", 0xFFbd1a1a, 100, 250, 16);
                _graphics.DrawString($"Do you wont play again?\nPress Y(Yes)/N(No)", "Arial", 0xFFbd1a1a, 100, 270, 16);

                if (Input.IsKeyDown(Keys.KEY_N))
                {
                    Restarting = false;
                    break;
                }
                else if (Input.IsKeyDown(Keys.KEY_Y))
                {
                    Restarting = true;
                    break;
                }
                _graphics.FlipPages();
            }
        }

        public void Play()
        {
            Canvas canvas = new Canvas(0xffffffff, _graphics.ClientWidth, _graphics.ClientHeight);
            SnekePartMove snakePart = new SnekePartMove(0xFF1e8a19, 0, 200, _graphics);
            SimpleSnakePart simpleSnakePart = new SimpleSnakePart();
            Snake snake = new Snake(this);

            snake.Add(snakePart, ref snakeParts);
            simpleSnakePart.CriateSimplePart(ref simpleSnakeParts, snakeParts, _graphics);

            while (isAlive)
            {
                canvas.Render(_graphics);

                snake.Render(_graphics, snakeParts);
                snake.Move(snakeParts);

                simpleSnakeParts[0].Render(_graphics);

                snake.ContactWithOneself(snakeParts);
                simpleSnakePart.Contact(simpleSnakeParts[0], snakePart, ref contact);

                if (contact)
                {
                    snake.Add(simpleSnakeParts[0], ref snakeParts);
                    simpleSnakeParts.RemoveAt(0);
                    simpleSnakePart.CriateSimplePart(ref simpleSnakeParts, snakeParts, _graphics);
                    points++;
                }
        
                _graphics.FlipPages();

                Thread.Sleep(100);
            }

        }

    }
}
