using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public unsafe class IRenderable 
    {
        public static FrameBufferObject MainFrameBuffer { get; set; }

        public static UniformBufferObject SceneBuffer { get; set; } = new UniformBufferObject("SceneBuffer",100 * sizeof(Matrix4));
        public static List<IRenderable> DrawQue { get; set; } = new List<IRenderable>();
        public bool Active { get; set; } = true;
        public string Name { get; set; }
        public SmashMaterial Material { get; set; } = new SmashMaterial();
        public CullFaceMode CullMode { get; set; } = CullFaceMode.Back;

        public static void IRenderableBegin()
        {

        }

        public void Draw()
        {
            if (Active && Material != null)
            DrawQue.Add(this);
        }

        public virtual void GLDraw()
        {

        }

        public static void DrawEntireDrawQue()
        {
            SceneBuffer.UpdateBuffer();

            foreach (IRenderable renderable in DrawQue)
            {
                SceneBuffer.BindToMaterial(renderable.Material);

                renderable.GLDraw();
            }

            DrawQue = new List<IRenderable>();
        }

        public static void DrawScreen()
        {
            DrawEntireDrawQue();
        }
    }
}
