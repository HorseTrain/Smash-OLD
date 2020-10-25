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
            Exporter.Program.Main(null);

            args = new string[] { "fox","yoshi" };
            
            Scene.LoadQue = args;        

            SmashWindow window = new SmashWindow();

            window.SetUp(500,500);
        }
    }

}
