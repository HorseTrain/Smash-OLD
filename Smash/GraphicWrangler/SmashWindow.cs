using SimpleGameEngine.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using SimpleGameEngine.Graphics.Assets;
using System.Threading;
using System.Diagnostics;
using Smash.IO;
using System;
using Smash.Game;
using Smash.Game.Scenes;
using Smash.Game.UI;

namespace Smash.GraphicWrangler
{
    public class SmashWindow : Window
    {
        public static Scene CurrentScene { get; set; }

        public override void Start()
        {
            Parsers.LoadAllShaders();

            CurrentScene = new ArenaScene();

            //((MenuScene)CurrentScene).Buttons.Add(new Button());
        }

        public override void Update(object obj, FrameEventArgs args)
        {
            PreWindow();

            CurrentScene.Update();

            IRenderable.DrawEntireDrawQue();

            window.Title = FrameRate.ToString() + " fps";

            PostWindow();
        }
    }
}
