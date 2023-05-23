using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Windows.Forms;
namespace Gameproject
{
    public class TitleScreen : Group
    {
        Game game;

        public TitleScreen(Game game)
        {
            this.game = game;
            var sprite = new SpriteEntity("MainScreen.png");
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            Origin = new Vector2f(0, 0);
            Add(sprite);
            Buttonimg();
        }

        public void Buttonimg()
        {
            var font = FontCache.Get("210 8bit Bold.ttf");
            var buttonimg = new SpriteEntity("Button.png") { Scale = new Vector2f(1.0f, 1.0f) };
            var playbutton = new ImageButton("Play", font, 50, 1, buttonimg)
            {
                Position = new Vector2f(340, 400),
                TextColor = Color.White,
            };

            Add(playbutton);

        }
        public override void MouseButtonPressed(MouseButtonEventArgs e)
        {
            base.MouseButtonPressed(e);
            var form = new SelectedCharacter();
            Application.Run(form);
            Character(form.isSelected, form.character);
        }

        public void Character(bool isSelected, String character)
        {
            if (isSelected)
                game.StartMainScene(character);
        }
    }
}
