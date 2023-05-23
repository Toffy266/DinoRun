using GameLib;
using SFML.Graphics;
using SFML.System;

namespace Gameproject
{
    public class Score : BlankEntity
    {
        Text text;
        public int playScore { get; set; }

        const string fixStr = "Score: ";
        public Score(int playScore)
        {
            this.playScore = playScore;
            var font = FontCache.Get("210 8bit Bold.ttf");
            text = new Text(fixStr, font, 40);
            text.Position = new Vector2f(25, 25);
            text.FillColor = Color.Black;
        }

        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
            string score = fixStr + playScore;
            text.DisplayedString = score;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            text.Draw(target, states);
        }
    }
}
