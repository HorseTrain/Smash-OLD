using OpenTK;
using Smash.Game;
using Smash.Game.Fighter;
using Smash.Game.Scenes;
using Smash.GraphicWrangler;
using Smash.IO;
using System.IO;

namespace Smash
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exporter.Program.Main(null);

            args = new string[] { "mario","donkey" };


            new int();

            //FileLoader.RootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Assets\\";

            Scene.LoadQue = args;        

            SmashWindow window = new SmashWindow();

            window.SetUp(500,500);
        }
    }

}
