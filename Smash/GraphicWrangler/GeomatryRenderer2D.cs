using SimpleGameEngine.Graphics.Assets;
using System;
using System.Collections.Generic;
using OpenTK;
using SimpleGameEngine.Graphics.Structs;
using Smash.Game.Physics.Structs;
using OpenTK.Graphics.OpenGL;

namespace Smash.GraphicWrangler
{
    public class GeomatryRenderer2D : IRenderable
    {
        public float Rotation { get; set; }
        public Vector2 Position { get; set; }
        public Vector4 Color { get; set; } = new Vector4(1,0,0,1);

        List<Vector2> Lines = new List<Vector2>();

        public void BuildMesh(List<Line2D> geomatry)
        {
            Material = new SmashMaterial();
            Material.RenderShader = RenderShader.AllShaders["2DGeomatryRenderer"];

            List<ushort> ind = new List<ushort>();
            List<RenderVertex> vert = new List<RenderVertex>();

            foreach (Line2D line in geomatry)
            {
                Lines.Add(line.Point0);
                Lines.Add(line.Point1);
            }
        }

        public override void GLDraw()
        {
            Material.UseMaterial();

            Material.UniformMat4("Transform", Matrix4.CreateFromQuaternion(Quaternion.FromAxisAngle(new Vector3(0, 0, 1), MathHelper.DegreesToRadians(Rotation))) * Matrix4.CreateTranslation(new Vector3(Position)));
            Material.UniformVector4("color",Color);

            GL.Begin(BeginMode.Lines);

            for (int i = 0; i < Lines.Count; i+= 2)
            {
                GL.Vertex2(Lines[i]);
                GL.Vertex2(Lines[i+1]);
            }

            GL.End();
        }
    }
}
