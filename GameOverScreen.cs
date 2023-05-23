using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Gameproject
{
    public class GameOverScreen : Group
    {
        Game game;
        ImageButton yesButton;
        ImageButton noButton;

        public GameOverScreen(Game game)
        {
            this.game = game;
            var sprite = new SpriteEntity("GameOverScreen.png");
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            Origin = new Vector2f(0, 0);
            Add(sprite);
            Buttonimg();
        }

        public void Buttonimg()
        {
            var font = FontCache.Get("210 8bit Bold.ttf");
            var buttonimg = new SpriteEntity("Button.png") { Scale = new Vector2f(1.0f, 1.0f) };
            var againButton = new ImageButton("Play Again", font, 50, 2, buttonimg)
            {
                Position = new Vector2f(340, 400),
                TextColor = Color.White,
            };

            Add(againButton);
        }
        public override void MouseButtonPressed(MouseButtonEventArgs e)
        {
            base.MouseButtonPressed(e);
            game.Reset();
        }
    }
}
