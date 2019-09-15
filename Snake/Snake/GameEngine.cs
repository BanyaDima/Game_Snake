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
        private CustomList.List<Bullet> bullets = new CustomList.List<Bullet>();
        private CustomList.List<SimpleBullet> simpleBullets = new CustomList.List<SimpleBullet>();
        private bool contact = false;
        public bool isAlive = true;
        private int points;
        private int bestpoints;

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }


        public void Play()
        {
            Canvas canvas = new Canvas(0xffffffff, _graphics.ClientWidth, _graphics.ClientHeight);
            Bullet bullet = new Bullet(0xFF00FF00, 0, 0, _graphics);

            SimpleBullet.SimpleBuletsList(ref simpleBullets, _graphics);
            Random random = new Random();
            int index = random.Next(0, simpleBullets.Count);

            bullets.Add(bullet);

            while (isAlive)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].Update(this); 
                }

                canvas.Render(_graphics);

                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].Render(_graphics);                   
                }

                simpleBullets[index].Render(_graphics);
                SimpleBullet.Contact(simpleBullets[index], bullet, ref contact);

                if (contact)
                {
                    bullet.AddNewBullet(ref bullets);                    
                    simpleBullets.RemoveAt(index);
                    index = random.Next(0, simpleBullets.Count);
                }

                if (!isAlive)
                {
                    _graphics.DrawString("GAME OVER", "Arial", 0xFF00FF00, 100, 200, 30);
                    _graphics.DrawString($"You have: {points} points", "Arial", 0xFF00FF00, 100, 250, 16);
                    _graphics.DrawString($"Best result: {bestpoints} points", "Arial", 0xFF00FF00, 100, 270, 16);
                }
                _graphics.FlipPages();
                Thread.Sleep(100);
            }

        }

    }
}
