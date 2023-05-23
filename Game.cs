using GameLib;
using SFML.Window;
using System;
using System.Diagnostics;

namespace Gameproject
{
    public class Game : Group
    {
        GameWindow window = new GameWindow(new VideoMode(1280, 720), "Game Project");
        Group allObjs = new Group();
        Group screen = new Group();
        TitleScreen titlescreen;
        MainScreen mainScreen;
        GameOverScreen gameOverScreen;
        public Game()
        {
            titlescreen = new TitleScreen(this);
            gameOverScreen = new GameOverScreen(this);
        }
        public void GameMain()
        {
            allObjs.Add(this);
            allObjs.Add(screen);
            screen.Add(titlescreen);

            window.RunGameLoop(allObjs);
        }

        public void StartMainScene(String character)
        {
            screen.Clear();
            mainScreen = new MainScreen(this, character);
            screen.Add(mainScreen);
            allObjs.Add(new Sound());
        }

        public void StopMainScene()
        {
            screen.Clear();
            screen.Add(gameOverScreen);
        }
        public void Reset()
        {
            screen.Clear();
            var currentExecutablePath = System.Environment.ProcessPath;
            window.Close();
            Process.Start(currentExecutablePath);
        }
    }
}
