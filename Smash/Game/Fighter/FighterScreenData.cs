using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.GraphicWrangler;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public class FighterScreenData : SceneObject
    {
        public fighter fref;

        UIImageRenderer FighterPortrait { get; set; } = new UIImageRenderer();

        TextRenderer AboveFighterText { get; set; } = new TextRenderer();

        public FighterScreenData(fighter fref)
        {
            this.fref = fref;
        }

        public override void Update()
        {
            AboveFighterTextProcess();
        }

        public void AboveFighterTextProcess()
        {
            AboveFighterText.Text = fref.Damage.ToString() + "%";

            AboveFighterText.PixelSize = 5;

            AboveFighterText.Transform = Matrix4.CreateTranslation(fref.skeleton.RootNode.LocalPosition + new Vector3(-(AboveFighterText.AveragePosition * AboveFighterText.UniformSize).X,25,0)) * RenderCamera.MainCamera.CameraViewThrustum;

            AboveFighterText.RenderMode = TextMode.World;

            AboveFighterText.Draw();
        }
    }
}
