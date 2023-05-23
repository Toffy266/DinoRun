using GameLib;
using SFML.System;
using System.Collections.Generic;

namespace Gameproject
{
    public class Meat : KinematicBody
    {
        protected Group allObjs;
        protected CollisionObj collisionObj;
        protected bool onFloor = false;

        public Meat(Group allObjs, Vector2f origin)
        {
            this.allObjs = allObjs;
            Origin = origin;
            var texture = TextureCache.Get("Meat.png");
            var sprite = new SpriteEntity(texture);
            sprite.Scale = new Vector2f(3, 3);
            Add(sprite);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(1, 1));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        protected Dictionary<CollisionObj, Vector2f> directions = new Dictionary<CollisionObj, Vector2f>();
        protected void OnCollide(CollisionObj objB, CollideData Data)
        {
            var monster = objB.Parent as Obstruction;
            if (Data.FirstContact)
                directions[objB] = this.collisionObj.RelativeDirection(Data.OverlapRect);
            var direction = directions[objB];

            if (direction.Y == 1)
                onFloor = true;

            if (direction.Y == 1)
            {
                V.Y = 0;
                Position -= new Vector2f(0, Data.OverlapRect.Height * direction.Y);
            }

            if (monster != null)
            {
                this.Detach();
            }
        }

        public override void FrameUpdate(float deltaTime)
        {
            this.V.X = -400;
            base.FrameUpdate(deltaTime);
            if (Position.X < -1500)
            {
                this.Detach();
            }
        }
        public override void PhysicsUpdate(float fixTime)
        {
            onFloor = false;
            Vector2f a = new Vector2f(0, 1000);
            V += a * fixTime;
            base.PhysicsUpdate(fixTime);
        }
    }
}