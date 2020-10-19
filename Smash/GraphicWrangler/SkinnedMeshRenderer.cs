using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public class SkinnedMeshRenderer : IRenderable
    {
        public RenderMesh Mesh { get; set; }
        public RenderSkeleton BindedSkeleton { get; set; }
        public bool Rigged;
        public string ParentBoneName { get; set; }
        public int UVMapToUse { get; set; }         

        public override void GLDraw()
        {
            BindedSkeleton.BindToMaterial(Material, 1);

            if (Name.Contains("Eye"))
            {
                Material.UniformInt("UVMap", 1);
            }
            else
            {
                Material.UniformInt("UVMap", 0);
            }

            if (Rigged)
            {
                Material.UniformInt("rigged", 1);
            }
            else
            {
                Material.UniformInt("rigged", 0);

                TransformNode test = BindedSkeleton.GetNode(ParentBoneName);

                if (test != null)
                    Material.UniformMat4("UnriggedTransform",BindedSkeleton.WorldTransformCache[test.Index]);
                else
                    Material.UniformMat4("UnriggedTransform",Matrix4.Identity);
            }

            Material.UniformVector3("CameraNormal",RenderCamera.MainCamera.CameraNormal);
            Material.UniformVector3("CameraPosition", RenderCamera.MainCamera.CameraPosition);

            Material.UseMaterial();

            GL.CullFace(CullMode);

            Mesh.GenericDraw();
        }
    }
}
