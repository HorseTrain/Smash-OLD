using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.UI
{
    public class MenuScene : Scene
    {
        public List<Button> Buttons { get; set; } = new List<Button>();

        public MenuScene()
        {

        }

        public override void Update()
        {
            foreach (Button button in Buttons)
            {
                button.Update();
            }
        }
    }
}
