using GameLib;
using SFML.System;
using System;

namespace Gameproject
{
    public class SpawnerWalk : Group
    {
        EnemyWalk enemyWalk;
        Group allObj;
        Clock clock;
        Random rand;
        float randomtime;
        public SpawnerWalk(Group allObj)
        {
            Origin = new Vector2f(-1450, -350);
            this.allObj = allObj;
            clock = new Clock();
        }

        public override void FrameUpdate(float deltaTime)
        {
            if (clock.ElapsedTime.AsSeconds() > randomtime)
            {
                rand = new Random();
                randomtime = rand.Next(2, 6);

                enemyWalk = new EnemyWalk(allObj, Origin);
                allObj.Add(enemyWalk);
                clock.Restart();
            }
            base.FrameUpdate(deltaTime);
        }
    }
}
