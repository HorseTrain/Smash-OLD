using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Assets
{
    public class RenderTexture3D : Texture //Cube map
    {
        public RenderTexture3D(List<Bitmap> Maps)
        {
            Create();

            GL.BindTexture(TextureTarget.TextureCubeMap,Handler);

            for (int i = 0; i < Maps.Count; i++)
            {
                BufferBitmap(Maps[i],TextureTarget.TextureCubeMapPositiveX + i);
            }

            SetMag(TextureMagFilter.Linear,TextureTarget.TextureCubeMap);

            CreateMips(GenerateMipmapTarget.TextureCubeMap);
        }

        public override void Use(TextureUnit Location = TextureUnit.Texture0)
        {
            GL.ActiveTexture(Location);
            GL.BindTexture(TextureTarget.TextureCubeMap, Handler);
        }
    }
}
