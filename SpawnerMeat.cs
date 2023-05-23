using GameLib;
using SFML.System;
using System;

namespace Gameproject
{
    public class SpawnerMeat : Group
    {
        Meat meat;
        Group allObj;
        Clock clock;
        float randomtime;

        Random random = new Random();
        public SpawnerMeat(Group allObj)
        {
            Origin = new Vector2f(-1450, -350);
            this.allObj = allObj;
            clock = new Clock();
        }

        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
            if (clock.ElapsedTime.AsSeconds() > randomtime)
            {
                randomtime = 0.25f;

                meat = new Meat(allObj, Origin);
                allObj.Add(meat);
                clock.Restart();
            }
        }
    }
}