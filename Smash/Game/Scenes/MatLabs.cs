using OpenTK.Input;
using OpenTK;
using Smash.Game.Fighter;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using Smash.Game.SceneAssets;
using SimpleGameEngine.Graphics;

namespace Smash.Game.Scenes
{
    public class MatLabs : Scene //For debuging materials
    {
        public List<IRenderable> Renderables { get; set; } = new List<IRenderable>();

        public List<fighter> fighters = new List<fighter>();

        Stage test;

        public override void Start()
        {
            Skybox = new SkyboxRenderer(@"StandardCubeMap");

            foreach (string l in LoadQue)
            {
                fighter f = ArenaScene.LoadFighterStatic(l,0);

                f.skeleton.RootNode.LocalPosition = new OpenTK.Vector3(fighters.Count * 30,0,0);

                fighters.Add(f);
            }

            Camera.CameraPosition = new OpenTK.Vector3(0, 0, 30);

            SceneObject.MaterialTesting = true;

            test = Stage.LoadModels("fe_shrine");
        }

        public override void Update()
        {
            mstate = Mouse.GetState();

            lkstate = kstate;
            kstate = Keyboard.GetState();

            DebugCamera();

            base.Update();

            Skybox.Draw();

            test.Draw();

            UpdateObjects();
        }

        KeyboardState kstate;
        KeyboardState lkstate;
        MouseState mstate;

        Vector2 MouseVel { get; set; }
        Vector2 lastmouse { get; set; }
        float speed = 0.3f;

        public void DebugCamera()
        {
            Vector2 currentmouse = new Vector2(mstate.X,mstate.Y);

            MouseVel = ((currentmouse - lastmouse)*(float)Window.MainWindow.DeltaTime) / 2;

            lastmouse = currentmouse;

            float plock = 90;

            if (!kstate.IsKeyDown(Key.Q))
            {
                Camera.Yaw += MouseVel.X;
                Camera.Pitch += MouseVel.Y;

                if (Camera.Pitch < -plock)
                    Camera.Pitch = -plock;

                if (Camera.Pitch > plock)
                    Camera.Pitch = plock;

                if (kstate.IsKeyDown(Key.R))
                {
                    Camera.CameraPosition = new OpenTK.Vector3(0, 0, 30);

                    Camera.Pitch = 0;
                    Camera.Yaw = 0;

                    speed = 0.3f;
                }

                if (kstate.IsKeyDown(Key.W))
                {
                    Camera.CameraPosition -= Camera.CameraRotationMatrix.Column2.Xyz * (float)Window.MainWindow.DeltaTime * speed;
                }

                if (kstate.IsKeyDown(Key.S))
                {
                    Camera.CameraPosition += Camera.CameraRotationMatrix.Column2.Xyz * (float)Window.MainWindow.DeltaTime * speed;
                }

                if (kstate.IsKeyDown(Key.A))
                {
                    Camera.CameraPosition -= Camera.CameraRotationMatrix.Column0.Xyz * (float)Window.MainWindow.DeltaTime * speed;
                }

                if (kstate.IsKeyDown(Key.D))
                {
                    Camera.CameraPosition += Camera.CameraRotationMatrix.Column0.Xyz * (float)Window.MainWindow.DeltaTime * speed;
                }
            }
        }
    }
}
