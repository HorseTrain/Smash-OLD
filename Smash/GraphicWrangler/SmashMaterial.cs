using OpenTK;
using SimpleGameEngine.Graphics.Assets;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public class SmashMaterial : RenderMaterial
    {
        public override void UploadUniforms()
        {
            foreach (MaterialAttribute attribute in Attributes)
            {
                if (attribute.Type == "Vector4")
                {
                    UniformVector4(attribute.Name,Parsers.Convert<Vector4, SmashLabs.Structs.Vector4>((SmashLabs.Structs.Vector4)attribute.Data));
                }
            }
        }
    }
}
