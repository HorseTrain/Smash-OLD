using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game.Scenes;
using Smash.GraphicWrangler;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.SceneAssets
{
    public class Stage : SceneObject
    {
        public List<RenderModel> Models = new List<RenderModel>();

        public override void Draw()
        {
            foreach (RenderModel model in Models)
            {
                model.GenericDraw();
            }
        }

        public static Stage LoadModels(string name)
        {
            Stage Out = new Stage();

            string[] Dirs = FileLoader.GetDirs(@"stage\" + name+ @"\battle\model");

            foreach (string dir in Dirs)
            {
                if (!dir.Contains("floating"))
                {

                    RenderModel temp = Parsers.LoadModel(dir);

                    string[] rkeys = temp.MaterialKeys.Keys.ToArray();

                    foreach (string key in rkeys)
                    {
                        RenderMaterial mat = temp.MaterialKeys[key];
                    }

                    if (temp != null)
                    {
                        foreach (SkinnedMeshRenderer mesh in temp.Meshes)
                        {
                            mesh.Material.RenderShader = RenderShader.AllShaders["Stage"];
                        }

                        Out.Models.Add(temp);
                    }
                }
            }

            return Out;
        }
    }
}
