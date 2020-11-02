using OpenTK;
using Smash.Game;
using Smash.Game.Fighter;
using Smash.Game.Scenes;
using Smash.GraphicWrangler;
using Smash.IO;
using System;
using System.IO;

namespace Smash
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exporter.Program.Main(null);

            FileLoader.RootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ @"\Assets\";

            Console.WriteLine("Make sure you exit out of Steam for Controller Support. :)");

            //Console.WriteLine(FileLoader.RootPath);

            args = new string[] { "pit", "mario"};
            
            Scene.LoadQue = args;      

            SmashWindow window = new SmashWindow();

            window.SetUp(500,500);
        }
    }

}
