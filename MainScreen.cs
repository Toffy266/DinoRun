using Game08;
using GameLib;
using SFML.Graphics;
using System;

namespace Gameproject
{
    public class MainScreen : Group
    {
        Group visual = new Group();
        Game game;

        public MainScreen(Game game, String character)
        {
            this.game = game;

            moveScene();
            var trigger = new Trigger(3.39f, true, moveScene);
            visual.Add(trigger);

            var score = new Score(0);
            visual.Add(score);

            var life = new Life(1020);
            visual.Add(life);

            var dino = new Dino(life, score, character, game);
            visual.Add(dino);

            var spawnerWalk = new SpawnerWalk(visual);
            visual.Add(spawnerWalk);

            var spawnerFly = new SpawnerFly(visual);
            visual.Add(spawnerFly);

            var meat = new SpawnerMeat(visual);
            visual.Add(meat);

            this.Add(visual);
        }

        public void moveScene()
        {
            var block = new Block(new FloatRect(0, 540, 1280, 300));
            block.V.X = -380;
            visual.Add(block);
        }
    }
}
