using GameLib;
using SFML.Graphics;
using SFML.System;

namespace Gameproject
{
    public class Life : KinematicBody
    {
        public int allLife { get; set; }
        FragmentArray fragments;
        SpriteEntity spriteLife;
        public Life(int allLife)
        {
            this.allLife = allLife;
            var textureDead = TextureCache.Get("Dead.png");
            var spriteDead = new SpriteEntity(textureDead);
            spriteDead.Position = new Vector2f(945, 30);
            spriteDead.Scale = new Vector2f(0.3f, 0.3f);
            Add(spriteDead);
        }

        Texture textureLife = TextureCache.Get("Life.png");
        public override void FrameUpdate(float deltaTime)
        {
            if (allLife >= 0)
            {
                fragments = FragmentArray.Create(textureLife, allLife, 154, 1, 1);
                spriteLife = new SpriteEntity(fragments.Fragments[0]);
                spriteLife.Position = new Vector2f(945, 30);
                spriteLife.Scale = new Vector2f(0.3f, 0.3f);
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            spriteLife?.Draw(target, states);
        }
    }
}
