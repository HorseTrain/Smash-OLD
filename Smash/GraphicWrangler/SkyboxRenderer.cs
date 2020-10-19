using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public class SkyboxRenderer : IRenderable
    {
        public RenderTexture3D TextureData { get; set; }

        public SkyboxRenderer(string name)
        {
            Material.RenderShader = RenderShader.AllShaders["Skybox"];

            TextureData = Parsers.CubemapFromName(name);
        }

        private static float SIZE = 500;

        private static float[] VERTICES = {
        -SIZE,  SIZE, -SIZE,
        -SIZE, -SIZE, -SIZE,
        SIZE, -SIZE, -SIZE,
        SIZE, -SIZE, -SIZE,
        SIZE,  SIZE, -SIZE,
        -SIZE,  SIZE, -SIZE,

        -SIZE, -SIZE,  SIZE,
        -SIZE, -SIZE, -SIZE,
        -SIZE,  SIZE, -SIZE,
        -SIZE,  SIZE, -SIZE,
        -SIZE,  SIZE,  SIZE,
        -SIZE, -SIZE,  SIZE,

        SIZE, -SIZE, -SIZE,
        SIZE, -SIZE,  SIZE,
        SIZE,  SIZE,  SIZE,
        SIZE,  SIZE,  SIZE,
        SIZE,  SIZE, -SIZE,
        SIZE, -SIZE, -SIZE,

        -SIZE, -SIZE,  SIZE,
        -SIZE,  SIZE,  SIZE,
        SIZE,  SIZE,  SIZE,
        SIZE,  SIZE,  SIZE,
        SIZE, -SIZE,  SIZE,
        -SIZE, -SIZE,  SIZE,

        -SIZE,  SIZE, -SIZE,
        SIZE,  SIZE, -SIZE,
        SIZE,  SIZE,  SIZE,
        SIZE,  SIZE,  SIZE,
        -SIZE,  SIZE,  SIZE,
        -SIZE,  SIZE, -SIZE,

        -SIZE, -SIZE, -SIZE,
        -SIZE, -SIZE,  SIZE,
        SIZE, -SIZE, -SIZE,
        SIZE, -SIZE, -SIZE,
        -SIZE, -SIZE,  SIZE,
        SIZE, -SIZE,  SIZE};

		public override void GLDraw()
        {
            /*
            Material.UseMaterial();

            GL.CullFace(CullFaceMode.Back);

            Material.UniformMat4("CameraRotation", RenderCamera.MainCamera.CameraRotationMatrix);
            Material.UniformMat4("CameraView", RenderCamera.MainCamera.CameraProjectionMatrix);

            GL.Begin(BeginMode.Triangles);

            for (int i = 0; i < VERTICES.Length; i+=3)
            {
                GL.Vertex3(new Vector3(VERTICES[i], VERTICES[i + 1], VERTICES[i + 2]));
            }

            GL.End();
            */
        }
    }
}
