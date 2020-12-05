using OpenTK.Audio.OpenAL;
using SimpleGameEngine.Graphics;
using System;
using System.IO;

namespace SimpleGameEngine.Audio
{
    public class AudioTrash : Garbage
    {
        public int Buffer;
        public int Source;

        public override void Dispose()
        {
            AL.DeleteBuffer(Buffer);
            AL.DeleteSource(Source);
        }
    }

    public class AudioClip 
    {
        public int Buffer { get; private set; } = -1;
        public int Source { get; private set; } = -1;
        public bool Loaded => Buffer != -1 && Source != -1;
        public int Frequency { get; set; } = 10000; //Defalut
        public bool Loops { get; set; } = true; //Defalut

        public byte[] buffer { get; set; }

        public AudioClip()
        {

        }

        void GenBuffer()
        {
            Buffer = AL.GenBuffer();
            Source = AL.GenSource();
        }

        public void BufferData(ALFormat format = ALFormat.Mono16)
        {
            GenBuffer();

            AL.BufferData(Buffer,format,buffer,buffer.Length,Frequency);
            AL.Source(Source,ALSourcei.Buffer,Buffer);
        }

        public void PlaySource(bool loop = false)
        {
            AL.Source(Source, ALSourceb.Looping, loop);

            AL.SourcePlay(Source);
        }

        ~AudioClip()
        {
            if (Loaded)
            {
                new AudioTrash()
                {
                    Buffer = Buffer,
                    Source = Source
                };
            }
        }
    }
}
