using GameLib;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameproject
{
    public class Dino : KinematicBody
    {
        CollisionObj collisionObj;
        AnimationStates states;
        Clock clockHit;
        Score score;
        Life life;
        Game game;
        bool onFloor, isSlide, isJump, hit = false;

        float speed = 0.5f;
        int jumpCount = 0;
        int allLife = 5;

        public Dino(Life life, Score score, String character, Game game)
        {
            this.life = life;
            this.score = score;
            this.game = game;

            Origin = new Vector2f(-100, 30);
            var sprite = new SpriteEntity();
            sprite.Scale = new Vector2f(6, 6);
            Add(sprite);

            var texture = TextureCache.Get(character);
            var fragments = FragmentArray.Create(texture, 24, 24);
            var idle = new Animation(sprite, fragments.SubArray(4, 6), speed);
            var jump = new Animation(sprite, fragments.SubArray(10, 4), speed);
            var hurt = new Animation(sprite, fragments.SubArray(14, 3), speed);
            var slide = new Animation(sprite, fragments.SubArray(17, 7), speed);

            states = new AnimationStates(idle, jump, hurt, slide);
            Add(states);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.7f, 0.7f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;

            Add(collisionObj);

        }

        Dictionary<CollisionObj, Vector2f> directions = new Dictionary<CollisionObj, Vector2f>();
        private void OnCollide(CollisionObj objB, CollideData Data)
        {
            var obstruction = objB.Parent as Obstruction;
            if (Data.FirstContact)
                directions[objB] = this.collisionObj.RelativeDirection(Data.OverlapRect);

            var direction = directions[objB];
            if (direction.Y == 1)
            {
                onFloor = true;
                jumpCount = 0;
            }

            if (direction.Y == 1 && obstruction == null)
            {
                isJump = false;
                V.Y = 0;
                Position -= new Vector2f(0, Data.OverlapRect.Height * direction.Y);
            }

            if (obstruction != null && !hit)
            {
                life.allLife -= 204;

                Sound sound = new Sound();
                sound.SoundHit();

                hit = true;
                allLife -= 1;
                if (allLife <= 0)
                {
                    game.StopMainScene();
                }

                clockHit = new Clock();

            }

            var meat = objB.Parent as Meat;
            if (meat != null && !hit)
            {
                meat!.Detach();
                score.playScore += 5;
            }
        }

        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
            var direction = DirectionKey.Normalized;

            if (isJump && !hit)
                states.Animate(1);

            else if (hit)
            {
                states.Animate(2);
                if (clockHit.ElapsedTime.AsSeconds() > 0.8f)
                    hit = false;
            }

            else if (isSlide)
                states.Animate(3);

            else
                states.Animate(0);
        }

        public override void PhysicsUpdate(float fixTime)
        {
            onFloor = false;
            Vector2f a = new Vector2f(0, 2000);
            V += a * fixTime;
            base.PhysicsUpdate(fixTime);
        }

        Object[] jumpKey = { Keyboard.Key.Space, Keyboard.Key.W, Keyboard.Key.Up };
        Object[] slideKey = { Keyboard.Key.S, Keyboard.Key.Down };
        public override void KeyPressed(KeyEventArgs e)
        {
            base.KeyPressed(e);
            if (jumpKey.Contains(e.Code) && jumpCount < 2)
            {
                jumpCount += 1;
                this.isJump = true;
                V.Y = -850;
            }

            if (slideKey.Contains(e.Code) && isSlide == false)
                this.isSlide = true;
        }

        public override void KeyReleased(KeyEventArgs e)
        {
            base.KeyReleased(e);
            if (slideKey.Contains(e.Code))
                this.isSlide = false;
        }
    }
}
