using MoonSharp.Interpreter;
using OpenTK;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics.ES11;
using OpenTK.Input;
using SimpleGameEngine.Audio;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash.Game.Scenes
{
    public unsafe class ArenaScene : Scene
    {
        public List<fighter> Fighters { get; set; }

        public override void Start()
        {
            UserData.RegisterAssembly();

            Fighters = new List<fighter>();

            foreach (string name in LoadQue)
                AddFighter(name);

            SimplePhysics.SceneGeomatry.Add(new Line2D(new Vector2(-800, 0), new Vector2(800, 0)));

            base.Start();
        }

        public override void Update()
        {
            UpdateCamera();

            base.Update();

            UpdateFighters();

            RenderSkeleton.GlobalUpdate();

            SimplePhysics.DrawSceneGeomatry();
        }

        public void UpdateCamera()
        {
            RenderCamera.MainCamera.ViewType = CameraType.Orthotgraphics;
            RenderCamera.MainCamera.CameraPosition = new Vector3(0, 45, 20);
            RenderCamera.MainCamera.CameraFOV = 100;
        }

        public void UpdateFighters()
        {
            Hitbox.UpdateAllHitBoxes();

            foreach (fighter fighter in Fighters)
            {
                fighter.Update();
            }
        }

        public void AddFighter(string name)
        {
            string fname = name.Split(' ')[0];
            int id = int.Parse(name.Split(' ')[1]);

            fighter temp = new fighter();

            temp.Model = Parsers.LoadModel(@"fighter\" +fname+ @"\model\body\c0" + id);

            string[] keys = temp.Model.MaterialKeys.Keys.ToArray();

            foreach (string key in keys)
            {
                temp.Model.MaterialKeys[key].RenderShader = RenderShader.AllShaders["Fighter"];
            }            

            temp.Animators.Add(Parsers.LoadAnimationCollection(@"fighter\" + fname + @"\motion\body\c0" + id,temp));

            temp.Animators.Add(Parsers.CoppyAnimator(temp.Animators[0]));

            temp.anim.CrossFade("wait1");

            temp.skeleton.RootNode.LocalPosition = new Vector3(Fighters.Count * 20,0,0);

            temp.Name = fname;
            temp.Index = Fighters.Count;

            Fighters.Add(temp);
        }
    }
}
