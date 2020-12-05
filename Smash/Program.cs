using OpenTK;
using OpenTK.Audio.OpenAL;
using SimpleGameEngine.Audio;
using Smash.Game;
using Smash.Game.Fighter;
using Smash.Game.Scenes;
using Smash.GraphicWrangler;
using Smash.IO;
using System;
using System.IO;
using System.Threading;

namespace Smash
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exporter.Program.Main(new string[0] { });

            //FileLoader.RootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ @"\Assets\";

            Console.WriteLine(FileLoader.RootPath);

            Console.WriteLine("Make sure you exit out of Steam for Controller Support. :)");

            args = new string[] { "pit 1","mario 7"};
            
            Scene.LoadQue = args;      

            SmashWindow window = new SmashWindow();

            window.SetUp(500,500);
        }
    }

}
