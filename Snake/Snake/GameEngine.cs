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
        private CustomList.List<IGameObject> bullet = new CustomList.List<IGameObject>();
        private CustomList.List<IGameObject> simpleBullet = new CustomList.List<IGameObject>();

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        private bool contact = false;
        
        public void Play()
        {
            Canvas canvas = new Canvas(0xffffffff, _graphics.ClientWidth, _graphics.ClientHeight);
            Bullet bulet = new Bullet(0xFF00FF00, 0, 0, _graphics);            
            SimpleBullet.SimpleBuletsList(ref simpleBullet, _graphics);
            Random random = new Random();
            int index = random.Next(0, simpleBullet.Count); 

            while (true)
            {
                bulet.Update();

                canvas.Render(_graphics);
                bulet.Render(_graphics);
                simpleBullet[index].Render(_graphics);

                SimpleBullet.Contact((SimpleBullet)simpleBullet[index], bulet, ref contact);

                if(contact)
                {
                    bullet.Add(simpleBullet[index]);
                    simpleBullet.RemoveAt(index);
                    index = random.Next(0, simpleBullet.Count);
                }

               _graphics.FlipPages();
                Thread.Sleep(100);
            }
        }

    }
}
