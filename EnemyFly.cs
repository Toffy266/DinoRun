using GameLib;
using SFML.Graphics;
using SFML.System;
using System;

namespace Gameproject
{
    public class EnemyFly : Obstruction
    {
        Texture texture1, texture2, texture3, texture4, randomTexture;
        FragmentArray fragments;
        Animation fly;
        Random random = new Random();

        public EnemyFly(Group allObjs, Vector2f origin) : base(allObjs)
        {

            Origin = new Vector2f(-1290, random.Next(270, 340) * -1);
            var sprite = new SpriteEntity();
            sprite.Scale = new Vector2f(4.2f, 4.2f);
            Add(sprite);

            texture1 = TextureCache.Get("monfish.png");
            texture2 = TextureCache.Get("mongin.png");
            texture3 = TextureCache.Get("monbird.png");
            texture4 = TextureCache.Get("monowl.png");

            Texture[] textures = { texture1, texture2, texture3, texture4 };
            randomTexture = textures[random.Next(0, textures.Length)];

            if (randomTexture != texture4)
            {
                fragments = FragmentArray.Create(randomTexture, 16, 16);
                if (randomTexture == texture3)
                    fly = new Animation(sprite, fragments.SubArray(0, 3), speed);
                else
                    fly = new Animation(sprite, fragments.SubArray(0, 4), speed);
            }
            else
            {
                fragments = FragmentArray.Create(randomTexture, 32, 32);
                fly = new Animation(sprite, fragments.SubArray(0, 3), speed);
            }

            Add(fly);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.47f, 0.47f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            Add(collisionObj);
        }
    }
}
