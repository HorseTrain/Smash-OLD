using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.GraphicWrangler;
using OpenTK;

namespace Smash.Game.Stages.Training
{
    public class TrainingBack : IRenderable
    {
        public TrainingBack()
        {
            Material.RenderShader = RenderShader.AllShaders["TrainingBack"];
        }

        public float scale = 10;

        public override void GLDraw()
        {
            Material.UseMaterial();

            Material.UniformMat4("Transform", RenderCamera.MainCamera.CameraViewThrustum);

            Material.UniformFloat("ScaleClamp",RenderCamera.MainCamera.CameraFOV);

            GL.CullFace(CullFaceMode.Back);

            GL.Begin(BeginMode.Quads);

            GL.Vertex3((RenderCamera.MainCamera.CameraFOV * Window.MainWindow.ScreenAspect) + RenderCamera.MainCamera.CameraPosition.X, (RenderCamera.MainCamera.CameraFOV) + RenderCamera.MainCamera.CameraPosition.Y, 0);
            GL.Vertex3(-(RenderCamera.MainCamera.CameraFOV * Window.MainWindow.ScreenAspect) + RenderCamera.MainCamera.CameraPosition.X, (RenderCamera.MainCamera.CameraFOV) + RenderCamera.MainCamera.CameraPosition.Y, 0);
            GL.Vertex3(-(RenderCamera.MainCamera.CameraFOV * Window.MainWindow.ScreenAspect) + RenderCamera.MainCamera.CameraPosition.X, -(RenderCamera.MainCamera.CameraFOV) + RenderCamera.MainCamera.CameraPosition.Y, 0);
            GL.Vertex3((RenderCamera.MainCamera.CameraFOV * Window.MainWindow.ScreenAspect) + RenderCamera.MainCamera.CameraPosition.X, -(RenderCamera.MainCamera.CameraFOV) + RenderCamera.MainCamera.CameraPosition.Y, 0);

            GL.End();
        }
    }
}
