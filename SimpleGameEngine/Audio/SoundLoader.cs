using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Audio
{
    public static class SoundLoader
    {
        public static AudioClip LoadWav(byte[] Data)
        {
            AudioClip Out = new AudioClip();

            MemoryStream stream = new MemoryStream(Data);

            int channels, bits, rate;

            Out.buffer = LoadRawWave(stream,out channels,out bits, out rate);
            Out.Frequency = rate;

            Out.BufferData(GetSoundFormat(channels,bits));

            return Out;
        }

        //https://github.com/mono/opentk/blob/master/Source/Examples/OpenAL/1.1/Playback.cs
        static byte[] LoadRawWave(Stream stream, out int channels, out int bits, out int rate)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (BinaryReader reader = new BinaryReader(stream))
            {
                // RIFF header
                string signature = new string(reader.ReadChars(4));

                if (signature != "RIFF")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                int riff_chunck_size = reader.ReadInt32();

                string format = new string(reader.ReadChars(4));
                if (format != "WAVE")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                // WAVE header
                string format_signature = new string(reader.ReadChars(4));
                if (format_signature != "fmt ")
                    throw new NotSupportedException("Specified wave file is not supported.");

                int format_chunk_size = reader.ReadInt32();
                int audio_format = reader.ReadInt16();
                int num_channels = reader.ReadInt16();
                int sample_rate = reader.ReadInt32();
                int byte_rate = reader.ReadInt32();
                int block_align = reader.ReadInt16();
                int bits_per_sample = reader.ReadInt16();

                string data_signature = new string(reader.ReadChars(4));
                if (data_signature != "data")
                    throw new NotSupportedException("Specified wave file is not supported.");

                int data_chunk_size = reader.ReadInt32();

                channels = num_channels;
                bits = bits_per_sample;
                rate = sample_rate;

                return reader.ReadBytes((int)reader.BaseStream.Length);
            }
        }

        public unsafe static short[] ConvertByteArray(byte[] Data)
        {
            short[] Out = new short[Data.Length / 2];

            fixed (byte* temp = Data)
            {
                short* temp1 = (short*)temp;

                for (int i = 0; i < Out.Length; i++)
                {
                    Out[i] = temp1[i];
                }
            }

            return Out;
        }

        public static ALFormat GetSoundFormat(int channels, int bits)
        {
            switch (channels)
            {
                case 1: return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
                case 2: return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
                default: throw new NotSupportedException("The specified sound format is not supported.");
            }
        }

        
    }
}
