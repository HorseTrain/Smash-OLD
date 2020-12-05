using MoonSharp.Interpreter;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO.XML;
using Smash.Game.Interaction;
using Smash.Game.Physics;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game
{
    [MoonSharpUserData]
    public class SceneObject
    {
        public XMLElement PeramSource { get; set; }
        public RenderModel Model { get; set; }
        public List<Animator> Animators { get; set; } = new List<Animator>();
        public Animator anim => Animators[0];
        public Animator defaultanimator => Animators[1];
        public RenderSkeleton skeleton => Model.Skeleton;
        public TransformNode RootNode => skeleton.RootNode;
        public SimplePhysics phy { get; set; }
        public float GeneralSpeed { get; set; } = 1;
        public static bool MaterialTesting { get; set; } = false;
        public float FinalSpeed => GeneralSpeed * Window.MainWindow.GlobalDeltaTime;
        public int Gdir { get; set; } = 1;
        public bool AccountCamera = true;
        public int Index { get; set; }
        public Random RNG = new Random();
        public List<Hitbox> MyHitboxes = new List<Hitbox>();

        public SceneObject()
        {
            Scene.CurrentScene.SceneObjects.Add(this);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Model.GenericDraw();
        }

        public int GetRandomInt(int nx, int px)
        {
            return RNG.Next(nx,px);
        }

        public virtual void OnAnimationChange(Animator animator)
        {
            
        }
    }
}
