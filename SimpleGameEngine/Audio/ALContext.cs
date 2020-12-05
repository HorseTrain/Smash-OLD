using OpenTK;
using OpenTK.Audio.OpenAL;
using SimpleGameEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Audio
{
    public class ALContext 
    {
        public IntPtr Location { get; private set; }
        public ContextHandle Context { get; private set; }
        public string Name { get; set; }
        public string Version { get; private set; }
        public string Vendor { get; private set; }
        public string Renderer { get; private set; }

        public ALContext(bool createcontext = true)
        {
            if (createcontext)
            CreateContext();
        }

        public unsafe void CreateContext(string name = null,bool MakeCurrent = true)
        {
            Location = Alc.OpenDevice(name);
            Context = Alc.CreateContext(Location,(int*)null);

            Name = name;

            if (MakeCurrent)
            {
                this.MakeCurrent();                
            }

            FillData();
        }

        void FillData()
        {
            Version = AL.Get(ALGetString.Version);
            Vendor = AL.Get(ALGetString.Vendor);
            Renderer = AL.Get(ALGetString.Renderer);
        }

        public void MakeCurrent()
        {
            Alc.MakeContextCurrent(Context);
        }

        public void DestroyContext()
        {
            if (Context != ContextHandle.Zero)
            {
                Alc.MakeContextCurrent(ContextHandle.Zero);
                Alc.DestroyContext(Context);
            }

            if (Location != IntPtr.Zero)
            {
                Alc.CloseDevice(Location);
            }

            Location = IntPtr.Zero;
        }

        ~ALContext()
        {
            DestroyContext();
        }
    }
}
