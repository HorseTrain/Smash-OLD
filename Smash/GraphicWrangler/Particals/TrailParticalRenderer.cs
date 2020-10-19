using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler.Particals
{
    public class TrailParticalRenderer : IRenderable
    {
        public List<Vector2> ParticalPositions { get; set; } = new List<Vector2>();
        public int InstanceCount { get; set; } = 100;
        public RenderMesh Mesh { get; set; }

        public TrailParticalRenderer()
        {
            Material = new SmashMaterial();

            Material.RenderShader = RenderShader.AllShaders["FighterTrail"];

            Mesh = RenderMesh.Quad;
        }

        public void Update()
        {
            Draw();
        }

        public override void GLDraw()
        {

        }
    }
}
