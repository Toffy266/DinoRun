using GameLib;
using SFML.Graphics;
using SFML.System;
using System;

namespace Gameproject
{
    public class EnemyWalk : Obstruction
    {
        Texture texture1, texture2, texture3, texture4, randomTexture;
        Random random = new Random();
        public EnemyWalk(Group allObjs, Vector2f origin) : base(allObjs)
        {
            Origin = origin;
            var sprite = new SpriteEntity();
            sprite.Scale = new Vector2f(5, 5);
            Add(sprite);

            texture1 = TextureCache.Get("monred.png");
            texture2 = TextureCache.Get("mongreen.png");
            texture3 = TextureCache.Get("monblue.png");
            texture4 = TextureCache.Get("monyellow.png");

            Texture[] textures = { texture1, texture2, texture3, texture4 };
            randomTexture = textures[random.Next(0, textures.Length)];

            var fragments = FragmentArray.Create(randomTexture, 16, 16);
            var walk = new Animation(sprite, fragments.SubArray(0, 6), speed);
            Add(walk);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.8f, 0.86f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        public override void PhysicsUpdate(float fixTime)
        {
            Vector2f a = new Vector2f(0, 1000);
            V += a * fixTime;
            base.PhysicsUpdate(fixTime);
        }
    }
}
