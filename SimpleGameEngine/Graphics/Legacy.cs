using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics
{
    public static class Legacy
    {
        public static void DrawQuad()
        {
            GL.Begin(BeginMode.Quads);

            GL.Vertex3(0,0,0);
            GL.Vertex3(1, 0, 0);
            GL.Vertex3(1, 1, 0);
            GL.Vertex3(0, 1, 0);

            GL.End();
        }
    }
}
