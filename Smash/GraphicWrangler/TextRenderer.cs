using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public enum TextMode
    {
        World = 0,
        Screen = 1
    }

    public struct GLCharecter
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
    }

    public struct ivec2
    {
        public int X;
        public int Y;

        public ivec2(Vector2 Vec)
        {
            this.X = (int)Vec.X;
            this.Y = (int)Vec.Y;
        }
    }

    public struct GLTextPointer
    {
        public int ID;
        public ivec2 Offset;
        public int Padding;
    }

    public class TextRenderer : IRenderable
    {
        public TextMode RenderMode { get; set; } = TextMode.Screen;

        public Matrix4 Transform = Matrix4.Identity;

        public RenderFont Font { get; set; }

        UniformBufferObject CharecterDataBuffer { get; set; }
        UniformBufferObject TextBuffer { get; set; }

        public float PixelSize = 20;
        public float UniformSize => PixelSize / (float)Font.Size;

        string text;

        public Vector2 AveragePosition { get; private set; }

        public string Text
        {
            get => text;

            set
            {
                text = value;

                BufferNewText(text);
            }
        }

        public unsafe TextRenderer(RenderFont font)
        {
            Font = font;

            SetUp();
        }

        public unsafe TextRenderer()
        {
            Font = Parsers.LoadFont(@"custom\Fonts\FOT-Rodin");

            SetUp();
        }

        public unsafe void SetUp()
        {
            Material.RenderShader = RenderShader.AllShaders["Text"];

            Material.Textures[0] = Font.FontSheet;

            BufferFont();

            TextBuffer = new UniformBufferObject("TextBuffer", 1000 * sizeof(GLTextPointer));

            Text = "Hello World!!";
        }

        public unsafe void BufferFont()
        {
            CharecterDataBuffer = new UniformBufferObject("CharecterDataBuffer", 256 * sizeof(GLCharecter));

            foreach (CharecterData data in Font.FontData)
            {
                if (data.Valid)
                {
                    GLCharecter charecter = new GLCharecter();

                    charecter.X = data.X;
                    charecter.Y = data.Y;
                    charecter.Width = data.Width;
                    charecter.Height = data.Height;

                    ((GLCharecter*)CharecterDataBuffer.Location)[data.ID] = charecter;
                }
            }

            CharecterDataBuffer.UpdateBuffer();
        }

        public unsafe void BufferNewText(string text)
        {
            Vector2 CurrentOffset = new Vector2();

            float maxx = 0;

            for (int i = 0; i < text.Length; i++)
            {
                ((GLTextPointer*)TextBuffer.Location)[i].ID = text[i];
                ((GLTextPointer*)TextBuffer.Location)[i].Offset = new ivec2(CurrentOffset + new Vector2(Font.FontData[text[i]].XOffset, Font.FontData[text[i]].YOffset));

                if (CurrentOffset.X + Font.FontData[text[i]].Width > maxx)
                    maxx = CurrentOffset.X + Font.FontData[text[i]].Width;

                CurrentOffset += new Vector2(Font.FontData[text[i]].XAdvance, 0);

                if (text[i] == 13 || text[i] == 10)
                {
                    CurrentOffset.Y += Font.NewLine;
                    CurrentOffset.X = 0;
                }
            }

            AveragePosition = new Vector2(maxx / 2f,0);

            TextBuffer.UpdateBuffer();
        }

        public override void GLDraw()
        {
            Material.UseMaterial();

            CharecterDataBuffer.BindToMaterial(Material);
            TextBuffer.BindToMaterial(Material);

            Material.UniformVector2("ScreenDimesions",new Vector2(Window.MainWindow.WindowWidth, Window.MainWindow.WindowHeight));
            Material.UniformInt("RenderMode", (int)RenderMode);
            Material.UniformMat4("Transform",Transform);
            Material.UniformFloat("Scale", UniformSize);

            GL.CullFace(CullFaceMode.Front);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha,BlendingFactor.OneMinusSrcAlpha);

            GL.Disable(EnableCap.CullFace);

            RenderMesh.Quad.Bind();
            GL.DrawElementsInstanced(BeginMode.Quads, RenderMesh.Quad.IndexData.Length,DrawElementsType.UnsignedShort,new IntPtr(0),text.Length);

            GL.Disable(EnableCap.Blend);
        }
    }
}
