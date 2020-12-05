using OpenTK;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Audio;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SimpleGameEngine.Graphics
{
    public class Window
    {
        public static Window MainWindow { get; private set; }
        public int WindowWidth { get => window.Width; set { window.Width = value; } }
        public int WindowHeight { get => window.Height; set { window.Height = value; } }
        public GameWindow window { get; private set; }
        public static bool Active { get; protected set; }
        public long FrameTime { get; protected set; } //Miliseconds
        public float ScreenAspect => (float)WindowWidth / WindowHeight;
        private Stopwatch Time { get; set; }
        public long FrameRendertime { get; private set; } //In miliseconds
        public double FrameRate { get; private set; }
        double DeltaTime { get; set; }
        public static Random GlobalRNG = new Random();
        public float GlobalDeltaTime
        {
            get
            {
                if (DeltaTime < 1)
                    return (float)DeltaTime;
                else
                    return 1;
            }
        }
        public float TargetFramerate { get; set; } = 60;
        long WaitTime { get; set; }
        public ALContext MainSoundContext { get; set; }
        
        public Window()
        {
            MainWindow = this;

            Time = new Stopwatch();
        }

        public unsafe void SetUp(int width, int height)
        {
            window = new GameWindow(width,height);

            window.RenderFrame += Update;

            MainSoundContext = new ALContext(true);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);

            window.VSync = VSyncMode.Off;

            Active = true;

            Start();

            window.Run();

            Active = false;

            MainSoundContext.DestroyContext();
        }

        public virtual void Start()
        {

        }

        public virtual void Update(object obj, FrameEventArgs args)
        {

        }

        public void PreWindow()
        {
            Time.Restart();
            Time.Start();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(0.2f,0.2f,0.2f,1);

            GL.Viewport(0,0,WindowWidth,WindowHeight);
        }

        public void PostWindow()
        {
            window.SwapBuffers();

            TimeStuff();
        }

        public void TimeStuff()
        {
            Time.Stop();

            FrameRendertime = Time.ElapsedTicks;

            FrameRate = 10000000d / FrameRendertime;

            DeltaTime = TargetFramerate / FrameRate;
        }
    }
}
