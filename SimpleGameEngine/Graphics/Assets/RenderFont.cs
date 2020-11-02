using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Assets
{
    public struct CharecterData
    {
        public int ID;
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int XOffset;
        public int YOffset;
        public int XAdvance;
        public bool Valid;

        public override string ToString()
        {
            return 
                "ID " + ID + "\n" +
                "X " + X + "\n" +
                "Y " + Y + "\n" +
                "Width " + Width + "\n" +
                "Height " + Height + "\n" +
                "Xoffset " + XOffset + "\n" + 
                "Yoffset " + YOffset + "\n" + 
                "Xadvance " + XAdvance + "\n"


                ;
        }
    }

    public class RenderFont
    {
        public RenderTexture2D FontSheet { get; set; }

        public CharecterData[] FontData = new CharecterData[256]; //Ascci

        public float NewLine { get; set; }
        public float Size { get; set; } = 200;

        public RenderFont(RenderTexture2D Sheet, string MetaData)
        {
            FontSheet = Sheet;

            string[] parts = MetaData.Split('\n');

            int count = 0;

            foreach (string line in parts)
            {
                string[] Attr = line.Split(' ');

                if (Attr[0] == "char")
                {
                    CharecterData temp = new CharecterData();

                    count++;

                    foreach (string attr in Attr)
                    {
                        string[] data = attr.Split('=');

                        if (attr.StartsWith("id="))
                        {
                            temp.ID = int.Parse(data[1]);
                        }

                        if (attr.StartsWith("x="))
                        {
                            temp.X = int.Parse(data[1]);
                        }

                        if (attr.StartsWith("y="))
                        {
                            temp.Y = int.Parse(data[1]);
                        }

                        if (attr.StartsWith("width="))
                        {
                            temp.Width = int.Parse(data[1]);
                        }

                        if (attr.StartsWith("height="))
                        {
                            temp.Height = int.Parse(data[1]);

                            NewLine += temp.Height * 1.2f;
                        }

                        if (attr.StartsWith("xoffset="))
                        {
                            temp.XOffset = int.Parse(data[1]);
                        }

                        if (attr.StartsWith("yoffset="))
                        {
                            temp.YOffset = int.Parse(data[1]);
                        }

                        if (attr.StartsWith("xadvance="))
                        {
                            temp.XAdvance = int.Parse(data[1]);
                        }
                    }

                    temp.Valid = true;

                    FontData[temp.ID] = temp;
                }
                else
                {
                    string[] data = line.Split(' ');

                    foreach (string dat in data)
                    {
                        string[] attr = dat.Split('=');

                        if (attr[0] == "size")
                        {
                            Size = int.Parse(attr[1]);
                        }
                    }
                }
            }

            NewLine /= count;
        }
    }
}
