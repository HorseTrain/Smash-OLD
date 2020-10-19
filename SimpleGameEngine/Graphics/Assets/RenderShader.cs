using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace SimpleGameEngine.Graphics.Assets
{
    public class ShaderSource
    {
        public int Handler { get; set; } = -1;
        public string Source { get; set; }
        public ShaderType Type { get; set; }
        public void Compile()
        {
            Handler = GL.CreateShader(Type);

            GL.ShaderSource(Handler,Source);
            GL.CompileShader(Handler);

            string sources = GL.GetShaderInfoLog(Handler);
            
            if (sources != "")
            {
                throw new Exception(Type + ":" + sources);
            }
        }

        ~ShaderSource()
        {
            if (Window.Active && Handler != -1)
            {
                //GL.DeleteShader(Handler);
            }
        }
    }

    public class RenderShader
    {
        public static Dictionary<string, RenderShader> AllShaders { get; set; } = new Dictionary<string, RenderShader>();
        public int Handler { get; private set; } = -1;
        public bool Compiled => Handler != -1;
        public List<ShaderSource> Sources { get; set; } = new List<ShaderSource>();
        public string Source { get; set; }

        public void CompileSources()
        {
            Handler = GL.CreateProgram();

            foreach (ShaderSource source in Sources)
            {
                source.Compile();

                GL.AttachShader(Handler,source.Handler);
            }

            GL.LinkProgram(Handler);
            GL.ValidateProgram(Handler);
        }

        public void Use()
        {
            if (!Compiled)
            {
                CompileSources();
            }

            GL.UseProgram(Handler);
        }

        ~RenderShader()
        {
            if (Window.Active && Handler != -1)
            {
                GL.DeleteProgram(Handler);
            }
        }
    }
}
