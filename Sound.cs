using GameLib;
using SFML.Audio;
using SFML.Window;
using System;
using System.Linq;
using System.Media;

namespace Gameproject
{
    public class Sound : BlankEntity
    {

        SoundBuffer jumpBuffer = new SoundBuffer("Jump.wav");
        SoundBuffer slideBuffer = new SoundBuffer("Slide.wav");
        SoundBuffer hitBuffer = new SoundBuffer("Hit.wav");
        SoundPlayer music = new SoundPlayer("song.wav");


        bool playJump, playSlide = false;
        public Sound()
        {
            music.PlayLooping();
        }

        public void SoundHit()
        {
            SFML.Audio.Sound soundHit = new SFML.Audio.Sound(hitBuffer);
            soundHit.Play();
        }

        Object[] jumpKey = { Keyboard.Key.Space, Keyboard.Key.W, Keyboard.Key.Up };
        Object[] slideKey = { Keyboard.Key.S, Keyboard.Key.Down };
        public override void KeyPressed(KeyEventArgs e)
        {
            base.KeyPressed(e);
            if (jumpKey.Contains(e.Code) && !playJump)
            {
                SFML.Audio.Sound sound = new SFML.Audio.Sound(jumpBuffer);
                sound.Play();
                playJump = true;
            }

            if (slideKey.Contains(e.Code) && !playSlide)
            {

                SFML.Audio.Sound sound = new SFML.Audio.Sound(slideBuffer);
                sound.Play();
                playSlide = true;
            }
        }

        public override void KeyReleased(KeyEventArgs e)
        {
            base.KeyReleased(e);
            if (jumpKey.Contains(e.Code) && playJump)
            {
                playJump = false;
            }

            if (slideKey.Contains(e.Code) && playSlide)
            {
                playSlide = false;
            }
        }
    }
}
