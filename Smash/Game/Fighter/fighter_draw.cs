using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public partial class fighter
    {
        public void DrawFighter()
        {
            if(!MaterialTesting)
            UpdateAnimation();

            Model.GenericDraw();
        }

        public void UpdateAnimation()
        {
            FaceCharecter();

            foreach (Animator animator in Animators)
            {
                animator.Update();
            }
        }

        public void FaceCharecter()
        {
            TransformNode RootNode = skeleton.RootNode;

            if (Peram != null)
            switch (Peram.TurnMode)
            {
                case (int)TurnMode.TurnWithScale: RootNode.LocalScale = new Vector3(-1, 1, -Gdir); RootNode.LocalRotation = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(-90)); break;
                case (int)TurnMode.TurnWithRotation: RootNode.LocalScale = new Vector3(-1, 1, 1);  RootNode.LocalRotation = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(90 * Gdir)); break;
            }
        }
    }
}
