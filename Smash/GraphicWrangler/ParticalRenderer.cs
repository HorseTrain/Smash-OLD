using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public class ParticalObject
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public float Scale = 1;

        public Matrix4 Transform = Matrix4.Identity;
        public ParticalRenderer parent { get; set; }

        public virtual void Update()
        {

        }

        public void SetTransform()
        {
            Transform = Matrix4.CreateScale(Scale) * Matrix4.CreateTranslation(Position);
        }

        public void Destroy()
        {
            parent.RemoveObject(this);
        }
    }

    public class ParticalRenderer : IRenderable
    {
        public static List<ParticalRenderer> ParticalRenderers = new List<ParticalRenderer>();

        public RenderMesh Mesh { get; set; }
        public UniformBufferObject TransformBuffer { get; set; }
        List<ParticalObject> Objects { get; set; } = new List<ParticalObject>();

        List<ParticalObject> destructionque = new List<ParticalObject>();
        public void AddObject(ParticalObject Object)
        {
            if (Objects.Count < 1024)
            {
                Object.parent = this;
                Objects.Add(Object);
            }
        }

        public void RemoveObject(ParticalObject Object)
        {
            destructionque.Add(Object);
        }

        public unsafe ParticalRenderer()
        {
            TransformBuffer = new UniformBufferObject("TransformBuffer", 1024*sizeof(Matrix4));

            Material.RenderShader = RenderShader.AllShaders["ParticalRenderer"];
        }

        public unsafe void UpdateTransformBuffers()
        {
            for (int i = 0; i < Objects.Count && i < 1024; i++)
            {
                Objects[i].Update();

                Objects[i].SetTransform();

                ((Matrix4*)TransformBuffer.Location)[i] = Objects[i].Transform;
            }

            TransformBuffer.UpdateBuffer();

            TransformBuffer.BindToMaterial(Material);
        }

        public override void GLDraw()
        {
            UpdateTransformBuffers();

            if (Mesh == null)
            {
                Mesh = RenderMesh.Quad;
            }

            Mesh.Bind();

            GL.DrawElementsInstanced(Mesh.RenderMode,Mesh.IndexData.Length,DrawElementsType.UnsignedShort,new IntPtr(0),Objects.Count);

            foreach (ParticalObject Object in destructionque)
            {
                Objects.Remove(Object);
            }

            destructionque = new List<ParticalObject>();
        }
    }
}
