using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Input
{
    public class KBWrapper
    {
        public KeyboardState State;
        public Dictionary<Key, bool> Overloads = new Dictionary<Key, bool>();

        public void OverloadButton(Key key, bool Pressed)
        {
            if (!Overloads.ContainsKey(key))
                Overloads.Add(key,default);

            Overloads[key] = Pressed;
        }

        public KBWrapper(KeyboardState state)
        {
            this.State = state;
        }

        public bool IsKeyDown(Key key)
        {
            if (Overloads.ContainsKey(key))
            {
                return Overloads[key];
            }

            return State.IsKeyDown(key);
        }

        public bool IsAnyKeyDown => State.IsAnyKeyDown;
    }
}
