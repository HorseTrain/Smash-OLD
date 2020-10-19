using SimpleGameEngine.Graphics.Assets;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Smash.GraphicWrangler
{
    public class RenderModel
    {
        public List<SkinnedMeshRenderer> Meshes { get; set; } = new List<SkinnedMeshRenderer>();
        public RenderSkeleton Skeleton { get; set; }
        public Dictionary<string, SmashMaterial> MaterialKeys { get; set; } = new Dictionary<string, SmashMaterial>();
        //public Dictionary<string, RenderTexture> TextureKeys { get; set; } = new Dictionary<string, RenderTexture>();
        public Dictionary<string,List<SkinnedMeshRenderer>> RenderKeys { get; set; }
        public void BuildRenderKeys()
        {
            RenderKeys = new Dictionary<string, List<SkinnedMeshRenderer>>();

            foreach (SkinnedMeshRenderer mesh in Meshes)
            {
                string name = mesh.Name.Replace("_VIS_O_OBJShape","");

                if (!RenderKeys.ContainsKey(name))
                    RenderKeys.Add(name,new List<SkinnedMeshRenderer>());

                RenderKeys[name].Add(mesh);
            }
        }
        public void GenericDraw()
        {
            Skeleton.Update();

            foreach (SkinnedMeshRenderer renderer in Meshes)
            {
                renderer.CullMode = Skeleton.CullMode;

                renderer.Draw();
            }
        }
    }
}
