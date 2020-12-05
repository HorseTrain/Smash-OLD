using SimpleGameEngine.Audio;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Audio.OpenAL;

namespace Smash.Game.Sound
{
    public static class SoundDevice
    {
        public static Dictionary<string, AudioClip> Clips = new Dictionary<string, AudioClip>();

        public static void LoadSoundCollection(string path)
        {
            if (FileLoader.DirectoryExists(path))
            {
                string[] Files = FileLoader.GetFiles(path);

                foreach (string file in Files)
                {
                    string name = Path.GetFileName(file).Replace(".wav", "");

                    if (file.EndsWith(".wav") && !Clips.ContainsKey(name))
                    {
                        Clips.Add(name, SoundLoader.LoadWav(FileLoader.ReadFileBytes(file)));
                    }
                }
            }
        }

        public static void PlaySound(string name ,bool Loop = false)
        {
            if (Clips.ContainsKey(name))
            {
                Clips[name].PlaySource(Loop);
            }
        }
    }
}
