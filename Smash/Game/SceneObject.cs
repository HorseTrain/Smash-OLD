using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO.XML;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game
{
    public class SceneObject
    {
        public XMLElement PeramSource { get; set; }
        public RenderModel Model { get; set; }
        public List<Animator> Animators { get; set; } = new List<Animator>();
        public Animator anim => Animators[0];
        public Animator defaultanimator => Animators[1];
        public RenderSkeleton skeleton => Model.Skeleton;
        public float GeneralSpeed { get; set; } = 1;
        public Dictionary<string, XMLElement> AnimationPerams { get; set; }
        public string name { get; set; }
        public static bool MaterialTesting { get; set; } = false;

        public SceneObject()
        {
            Scene.CurrentScene.SceneObjects.Add(this);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
