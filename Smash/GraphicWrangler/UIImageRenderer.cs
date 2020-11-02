using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public class UIImageRenderer : IRenderable
    {
        public Vector2 Position;

        public RenderTexture2D Image
        {
            get => (RenderTexture2D)Material.Textures[0];

            set
            {
                Material.Textures[0] = value;
            }
        }

        public UIImageRenderer()
        {
            Material.RenderShader = RenderShader.AllShaders["UIImageRenderer"];
        }

        public override void GLDraw()
        {
            if (Image != null)
            {
                Material.UseMaterial();

                Material.UniformVector2("ImageDimensions", new Vector2(Image.Width, Image.Height));
                Material.UniformVector2("Position", Position);
                Material.UniformVector2("ScreenDimesions", new Vector2(Window.MainWindow.WindowWidth, Window.MainWindow.WindowHeight));

                RenderMesh.Quad.GenericDraw();
            }
        }
    }
}
