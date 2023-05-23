using System;

namespace Gameproject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            new Game().GameMain();
        }
    }
}