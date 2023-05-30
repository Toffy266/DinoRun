using GameLib;
using SFML.System;
using System;

namespace Gameproject
{
    public class SpawnerFly : Group
    {
        EnemyFly enemyfly;
        Group allObj;
        Clock clock;
        Random rand;
        float randomtime;


        public SpawnerFly(Group allObjs)
        {
            Origin = new Vector2f(-1450, -250);
            this.allObj = allObjs;
            clock = new Clock();
        }
        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
            if (clock.ElapsedTime.AsSeconds() > randomtime)
            {
                rand = new Random();
                randomtime = rand.Next(4, 6);

                enemyfly = new EnemyFly(allObj, Origin);
                allObj.Add(enemyfly);
                clock.Restart();
            }

        }

    }
}
