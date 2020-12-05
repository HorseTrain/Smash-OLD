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
using Smash.Game.Debug;
using SimpleGameEngine.Audio;
using Smash.Game.Sound;

namespace Smash.GraphicWrangler
{
    public class SmashWindow : Window
    {
        public static Scene CurrentScene { get; set; }

        public override void Start()
        {
            Parsers.LoadAllShaders();

            SoundDevice.LoadSoundCollection(@"custom\Sounds\General Sounds");

            CurrentScene = new ArenaScene();
        }

        public override void Update(object obj, FrameEventArgs args)
        {
            PreWindow();

            CurrentScene.Update();

            GameStats.ShowGameStats();

            IRenderable.DrawEntireDrawQue();

            Garbage.CollectTrash();

            PostWindow();
        }
    }
}
