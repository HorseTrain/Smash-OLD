using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Assets
{
    public class TextureTrash : Garbage
    {
        public int ID;

        public override void Dispose()
        {
            GL.DeleteTexture(ID);
        }
    }

    public class Texture
    {
        public int Handler { get; private set; } = -1;
        public bool Loaded => Handler != -1;
        public int Width { get; set; }
        public int Height { get; set; }

        public Texture()
        {

        }

        public virtual void Create()
        {
            Handler = GL.GenTexture();
        }

        public virtual void Bind()
        {

        }

        public static void BufferBitmap(Bitmap data,TextureTarget target = TextureTarget.Texture2D)
        {
            BitmapData bData = data.LockBits(new Rectangle(0,0,data.Width,data.Height),ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(target,0,PixelInternalFormat.Rgba,data.Width,data.Height,0,OpenTK.Graphics.OpenGL.PixelFormat.Bgra,PixelType.UnsignedByte,bData.Scan0);

            data.UnlockBits(bData);
        }

        public static void CreateEmptyTextureBuffer(int Width, int Height, TextureTarget target = TextureTarget.Texture2D)
        {
            GL.TexImage2D(target, 0, PixelInternalFormat.Rgba, Width, Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte,IntPtr.Zero);
        }

        public static void SetMag(TextureMagFilter filter = TextureMagFilter.Linear,TextureTarget target = TextureTarget.Texture2D)
        {
            GL.TexParameter(target, TextureParameterName.TextureMinFilter, (int)filter);
            GL.TexParameter(target, TextureParameterName.TextureMagFilter, (int)filter);
        }

        public static void CreateMips(GenerateMipmapTarget target = GenerateMipmapTarget.Texture2D)
        {
            GL.GenerateMipmap(target);
        }

        public virtual void Use(TextureUnit Location = TextureUnit.Texture0)
        {

        }

        ~Texture()
        {
            if (Loaded && Window.Active)
            {
                new TextureTrash()
                {
                    ID = Handler
                };
            }
        }

        public void Dispose()
        {
            GL.DeleteTexture(Handler);
        }
    }
}
