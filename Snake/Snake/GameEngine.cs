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
        //private int bestPoints;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }
        
        public void Play()
        {
            Canvas canvas = new Canvas(0xffffffff, _graphics.ClientWidth, _graphics.ClientHeight);
            SnekePartMove snakePart = new SnekePartMove(0xFF1e8a19, 0, 0, _graphics);
            SimpleSnakePart simpleSnakePart = new SimpleSnakePart();

            simpleSnakePart.SimplePartsList(ref simpleSnakeParts, _graphics);

            Random random = new Random();
            int index = random.Next(0, simpleSnakeParts.Count);

            Snake snake = new Snake(this);
            snake.Add(snakePart, ref snakeParts);

            while (isAlive)
            {
                canvas.Render(_graphics);

                snake.Render(_graphics, snakeParts);
                snake.Move(snakeParts);

                simpleSnakeParts[index].Render(_graphics);
                snake.ContactWithOneself(snakeParts);
                simpleSnakePart.Contact(simpleSnakeParts[index], snakePart, ref contact);

                if (contact)
                {
                    snake.Add(simpleSnakeParts[index], ref snakeParts);
                    simpleSnakeParts.RemoveAt(index);
                    index = random.Next(0, simpleSnakeParts.Count);
                    points++;
                }

                if (!isAlive)
                {
                    _graphics.DrawString("GAME OVER", "Arial", 0xFFbd1a1a, 100, 200, 30);
                    _graphics.DrawString($"You have: {points} points", "Arial", 0xFFbd1a1a, 100, 250, 16);
                    //_graphics.DrawString($"Best result: {bestPoints} points", "Arial", 0xFF00FF00, 100, 270, 16);                    
                }
                _graphics.FlipPages();
                Thread.Sleep(100);
            }

        }

    }
}
