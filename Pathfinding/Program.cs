using System;

namespace Pathfinding
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Pathfinding.Services.IServiceLocator serviceLocator = new Pathfinding.Services.ServiceLocator();
            using (var game = new Game1(serviceLocator))
                game.Run();
        }
    }
}
