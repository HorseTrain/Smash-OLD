using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Assets
{
    public class RenderTexture2D : Texture
    {
        public RenderTexture2D()
        {

        }

        public RenderTexture2D(Bitmap map)
        {
            Create();

            Bind();

            BufferBitmap(map);

            SetMag(TextureMagFilter.Linear);

            CreateMips();
        }

        public override void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, Handler);
        }

        public override void Use(TextureUnit Location = TextureUnit.Texture0)
        {
            GL.ActiveTexture(Location);
            GL.BindTexture(TextureTarget.Texture2D,Handler);
        }
    }
}
