using GameLib;
using SFML.Graphics;
using SFML.System;


namespace Game08
{
    public class Block : KinematicBody
    {
        FloatRect rect;
        public Block(FloatRect rect)
        {
            var texture = TextureCache.Get("tileset.png");
            var sprite = new SpriteEntity(texture);
            sprite.Position = rect.GetPosition();
            sprite.Scale = new Vector2f(1, 1);
            Add(sprite);

            var shape = new CollisionRect(sprite.GetGlobalBounds());
            var collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            Add(collisionObj);
        }
    }
}
