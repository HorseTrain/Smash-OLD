using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO.Collada.Scene;
using Smash.GraphicWrangler;

namespace Smash.Game.UI
{
    public class Button : IRenderable
    {
        public static float MenuScale => Window.MainWindow.WindowHeight;
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; } = new Vector2(1,1);

        Matrix4 Transform => TransformNode.TRS(new Vector3(Position.X, Position.Y, 0), Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(Rotation)), new Vector3(Scale.X, Scale.Y, 1));

        public Button()
        {
            Material.RenderShader = RenderShader.AllShaders["Button"];
        }

        public void Update()
        {
            Draw();
        }

        public override void GLDraw()
        {
            Material.UseMaterial();

            Material.UniformMat4("transform", Transform);

            Legacy.DrawQuad();
        }
    }
}
