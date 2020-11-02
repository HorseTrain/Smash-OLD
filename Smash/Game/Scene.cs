using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO;
using Smash.GraphicWrangler;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game
{
    public unsafe class Scene
    {
        public static string[] LoadQue { get; set; }
        public static SkyboxRenderer Skybox{ get; set; }
        public RenderCamera Camera { get; set; }
        public static Scene CurrentScene { get; set; }
        public List<SceneObject> SceneObjects { get; set; } = new List<SceneObject>();
        public static Random GlobalRandom = new Random();

        public static float RandomFloat(int min, int max)
        {
            return GlobalRandom.Next(min * 100, max * 100) / 100;
        }

        public Scene()
        {
            CurrentScene = this;

            Camera = new RenderCamera();

            LoadAllShaders();
        }

        bool Started = false;

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            if (!Started)
            {
                Start();

                Started = true;
            }

            ((Matrix4*)IRenderable.SceneBuffer.Location)[0] = Camera.CameraViewThrustum;

            RenderSkeleton.GlobalUpdate();
        }

        public virtual void UpdateObjects()
        {
            foreach (SceneObject Object in SceneObjects)
            {
                Object.Update();
            }
        }

        public static void LoadAllShaders()
        {
            /*
            string[] files = FileLoader.GetAllFiles("Shaders");

            foreach (string file in files)
            {
                RenderShader CurrentShader = ShaderLoader.LoadShader(FileLoader.ReadFileBytes(file));

                string name = Path.GetFileName(file).Split('.')[0];

                RenderShader.AllShaders.Add(name,CurrentShader);
            }
            */
        }
    }
}
