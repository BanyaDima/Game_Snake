using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        GameEngine _gameEngine;

        public Snake(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public void Add(SnekePartMove bullet, ref CustomList.List<SnekePartMove> snake)
        {
            snake.Add(bullet);
        }

        public void Move(CustomList.List<SnekePartMove> snake)
        {
            SnekePartMove head = snake[0];
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].X = snake[i - 1].X;
                snake[i].Y = snake[i - 1].Y;
            }
            head.Update(_gameEngine);
        }

        public void Render(ConsoleGraphics consoleGraphics, CustomList.List<SnekePartMove> snake)
        {
            for (int i = 0; i < snake.Count; i++)
            {
                snake[i].Render(consoleGraphics);
            }
        }
        public void ContactWithOneself(CustomList.List<SnekePartMove> snake)
        {
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                    _gameEngine.isAlive = false;
            }
        }
    }
}
