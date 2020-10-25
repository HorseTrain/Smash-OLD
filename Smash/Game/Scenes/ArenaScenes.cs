using OpenTK;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics.ES11;
using OpenTK.Input;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO;
using SimpleGameEngine.IO.Collada;
using SimpleGameEngine.IO.Collada.Scene;
using SimpleGameEngine.IO.XML;
using Smash.Game.Fighter;
using Smash.Game.Interaction;
using Smash.Game.Physics;
using Smash.Game.Physics.Shapes;
using Smash.Game.Physics.Structs;
using Smash.Game.SceneAssets;
using Smash.Game.Stages.Training;
using Smash.GraphicWrangler;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Scenes
{
    public unsafe class ArenaScene : Scene
    {
        public static float GLobalSpeed { get; set; } 

        public List<fighter> Fighters = new List<fighter>();
        bool HasFighters => Fighters.Count != 0;
        public CameraType cameraMode { get; set; } = CameraType.Orthotgraphics;

        public bool DebugCamera = false;

        public List<Ledge> Ledges { get; set; } = new List<Ledge>();

        TrainingBack back;

        public ArenaScene()
        {
            back = new TrainingBack();

            Skybox = new SkyboxRenderer("StandardCubeMap");

            Camera = new RenderCamera();

            Camera.ViewType = cameraMode;

            foreach (string load in LoadQue)
            {
                AddFighter(load,0);
            }

            int SizeAdd = 800;

            Vector2 Left = new Vector2(-SizeAdd, 0);
            Vector2 Right = new Vector2(SizeAdd, 0);

            Vector2 BLeft = new Vector2(Left.X + 10, -20); 
            Vector2 BRight = new Vector2(Right.X - 10, -20);

            //Ground
            SimplePhysics.SceneGeomatry = SimplePhysics.LinesFromPoints(new Vector2[] { Left,Right,BRight, BLeft },true);

            //SimplePhysics.SceneGeomatry.AddRange(SimplePhysics.LinesFromPoints(new Vector2[] { new Vector2(-150, 50), new Vector2(150, 50), new Vector2(140, -30 +50), new Vector2(-140, -30 + 50) }, true));

            Ledges.Add(new Ledge(Left,1,-1));
            Ledges.Add(new Ledge(Right, 1, 1));

            SceneObject.MaterialTesting = false;
        }

        public override void Update()
        {
            base.Update();

            //Skybox.Draw();

            Hitbox.UpdateAllHitBoxes();

            if (HasFighters)
            {
                GLobalSpeed = (float)Window.MainWindow.GlobalDeltaTime;

                UpdateFighters();

                CameraControles();

                if (Fighters[0].input.KS.GetKey(OpenTK.Input.Key.R))
                {
                    for (int i = 0; i < Fighters.Count; i++)
                    {
                        Fighters[i].skeleton.RootNode.LocalPosition = new Vector3(i * 20, 0, 0);
                        Fighters[i].InDamageFly = false;

                        if (Fighters[i].HeldLedge != null)
                        {
                            Fighters[i].HeldLedge.Release();
                        }
                    }
                }
            }

            SimplePhysics.DrawSceneGeomatry();

            back.Draw();
        }

        float MinX;
        float MaxX;

        float MinY;
        float MaxY;

        float DisX;
        float DisY;

        float avgx;
        float avgy;

        public void CameraAvg()
        {
            MinX = Fighters[0].skeleton.RootNode.LocalPosition.X;
            MaxX = MinX;

            MinY = Fighters[0].skeleton.RootNode.LocalPosition.Y;
            MaxY = MinY;

            foreach (fighter f in Fighters)
            {
                if (f.skeleton.RootNode.LocalPosition.X < MinX)
                    MinX = f.skeleton.RootNode.LocalPosition.X;

                if (f.skeleton.RootNode.LocalPosition.X > MaxX)
                    MaxX = f.skeleton.RootNode.LocalPosition.X;

                if (f.skeleton.RootNode.LocalPosition.Y < MinY)
                    MinY = f.skeleton.RootNode.LocalPosition.Y;

                if (f.skeleton.RootNode.LocalPosition.Y > MaxY)
                    MaxY = f.skeleton.RootNode.LocalPosition.Y;
            }

            DisX = Math.Abs(MaxX - MinX);
            DisY = Math.Abs(MaxY - MinY);

            avgx = (MinX + MaxX) / 2;
            avgy = (MinY + MaxY) / 2;
        }

        public void CameraControles()
        {
            CameraAvg();

            if (DebugCamera)
                CameraDebug();
            else
            switch (cameraMode)
            {
                case CameraType.Perspective: CameraPers(); break;
                case CameraType.Orthotgraphics: CameraOrtho(); break;
            }
        }

        public float CameraLerp { get; set; } = 2;
        public float CameraMinFOV { get; set; } = 50;

        float WantedSize;
        float lws;

        public void CameraOrtho()
        {
            Vector2 AveragePosition = Vector2.Zero;

            float WantedCameraSizeX = (Math.Abs(MaxX - MinX) / Window.MainWindow.ScreenAspect) + 50;
            float WantedCameraSizeY = Math.Abs(MaxY - MinY) + 50;     

            if (WantedCameraSizeX > WantedCameraSizeY)
            {
                WantedSize = WantedCameraSizeX;
            }
            else
            {
                WantedSize = WantedCameraSizeY;
            }

            if (WantedSize <= lws)
                CameraLerp += (40 - CameraLerp) / (10 /Window.MainWindow.GlobalDeltaTime);
            else
                CameraLerp += (20 - CameraLerp) / (5 / Window.MainWindow.GlobalDeltaTime);

            lws = WantedSize;

            Camera.CameraFOV += ((WantedSize) - Camera.CameraFOV) / (CameraLerp / (float)Window.MainWindow.GlobalDeltaTime);

            Camera.CameraPosition += (new Vector3((MinX+ MaxX)/2f, ((MinY + MaxY) / 2f) + 10, 20) - Camera.CameraPosition) / (CameraLerp / (float)Window.MainWindow.GlobalDeltaTime);
        }

        public void CameraPers()
        {
            float disx = GetTriangleA(Camera.CameraFOV, DisX/2) + 100;
            float disy = GetTriangleA(Camera.CameraFOV, DisY/2) + 100;

            if (disx > disy)
            {
                Camera.CameraPosition += (new Vector3(avgx, avgy + 20, disx) - Camera.CameraPosition)/CameraLerp;
            }
            else
            {
                Camera.CameraPosition += (new Vector3(avgx, avgy + 20, disx) - Camera.CameraPosition) / CameraLerp;
            }
        }

        Vector2 Angle = new Vector2();


        public void CameraDebug()
        {
            RenderCamera.MainCamera.ViewType = CameraType.Perspective;

            KeyboardState kstate = Keyboard.GetState();
            MouseState mstate = Mouse.GetState();

            Angle = new Vector2(mstate.X,-mstate.Y)/20.0f;

            Camera.Yaw = Angle.X;
            Camera.Pitch = Angle.Y;

            Camera.CameraFOV = 60;

            RenderCamera.MainCamera.CameraPosition += new Vector3(0,0,0);
        }

        public static float Avg(float x,float y)
        {
            return (x + y) / 2;
        }

        public static float GetTriangleA(float t, float o)
        {
            return o / (float)Math.Atan(MathHelper.DegreesToRadians(t));
        }

        public void UpdateFighters()
        {
            foreach (fighter f in Fighters)
            {
                f.Update();

                DetectLedge(f);
            }

            foreach (Ledge ledge in Ledges)
            {
                ledge.Update();
            }
        }

        public void DetectLedge(fighter f)
        {
            foreach (Ledge ledge in Ledges)
            {
                ledge.TestLedge(f);
            }
        }

        public void AddFighter(string name,int id) //for god sake make cleaner 
        {
            fighter f = LoadFighterStatic(name,id);

            f.FighterIndex = Fighters.Count;

            f.skeleton.RootNode.LocalPosition = new Vector3(Fighters.Count * 20,0,0);

            Fighters.Add(f);
        }

        public static fighter LoadFighterStatic(string name, int id)
        {
            Type t = Type.GetType("Smash.Game.Fighter.fighter_s." + name);

            fighter f;

            if (t == null)
                f = new fighter();
            else
                f = (fighter)Activator.CreateInstance(t);

            f.Model = Parsers.LoadModel(@"fighter/" + name + @"/model/body/c0" + id);

            foreach (SkinnedMeshRenderer renderer in f.Model.Meshes)
            {
                renderer.Material.RenderShader = RenderShader.AllShaders["Fighter"];
            }

            f.Animators.Add(Parsers.LoadAnimationCollection(@"fighter/" + name + @"/motion/body/c0" + id));

            f.Animators.Add(Parsers.CoppyAnimator(f.Animators[0]));

            f.defaultanimator.CrossFade(@"defaulteyelid");

            f.name = name;

            return f;
        }
    }
}
