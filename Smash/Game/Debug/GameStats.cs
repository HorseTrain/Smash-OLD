using SimpleGameEngine.Graphics;
using Smash.GraphicWrangler;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Debug
{
    public class GameStats
    {
        static TextRenderer DisplayData;

        public static void ShowGameStats()
        {
            if (DisplayData == null)
            {
                DisplayData = new TextRenderer(Parsers.LoadFont(@"custom\Fonts\FOT-Rodin"));
            }

            string displaytext = "";

            displaytext += ((int)Window.MainWindow.FrameRate).ToString() + " - fps\n";

            DisplayData.Text = displaytext;

            DisplayData.Draw();
        }
    }
}
