using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics
{
    public class FrameBufferObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Handler = -1;
        public bool Exists => Handler != -1;

        public FrameBufferObject()
        {

        }

        public void Gen()
        {
            Handler = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer,Handler);
        }

        public void DrawUse(DrawBufferMode mode = DrawBufferMode.ColorAttachment0)
        {
            GL.DrawBuffer(mode);
        }

        public void Bind(FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            GL.BindFramebuffer(target, Handler);
            GL.Viewport(0,0,Width,Height);
        }

        public static void DefaultBind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            GL.Viewport(0, 0, Window.MainWindow.WindowWidth, Window.MainWindow.WindowHeight);
        }

        public RenderTexture2D GenerateRenderTexture(FramebufferAttachment mode)
        {
            RenderTexture2D Out = new RenderTexture2D();

            Out.Create();

            Out.Bind();

            Texture.CreateEmptyTextureBuffer(Width,Height);

            GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, Out.Handler, 0);

            Texture.SetMag();

            return Out;
        }

        ~FrameBufferObject()
        {
            if (Window.Active && Handler != -1)
            {
                GL.DeleteFramebuffer(Handler);
            }
        }
    }
}
