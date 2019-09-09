using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;
using CustomList;

namespace Snake
{
    class GameEngine
    {
        private ConsoleGraphics _graphics;
        private CustomList.List<IGameObject> bullet = new CustomList.List<IGameObject>();
        private CustomList.List<IGameObject> staticBullet = new CustomList.List<IGameObject>();

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        public void Play()
        {

            Canvas canvas = new Canvas(0xffffffff, _graphics.ClientWidth, _graphics.ClientHeight);
            Bullet bulet = new Bullet(0xFF00FF00, 0, 0);
            IGameObject statBullet = new StaticBullet(0xFF00FF00, 100, 80);


            while (true)
            {
                bulet.Update(canvas);

                canvas.Render(_graphics);
                bulet.Render(_graphics);
                statBullet.Render(_graphics);




                _graphics.FlipPages();
            }
        }
}
}
