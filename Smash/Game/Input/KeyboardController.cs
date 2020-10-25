using OpenTK.Input;
using SimpleGameEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Input
{
    public class KeyboardController
    {
        public KeyboardState LastState { get; set; }
        public KeyboardState State { get; set; }
        public float[] Buffers { get; set; }

        public KeyboardController()
        {
            Buffers = new float[132];
        }

        public void Update()
        {
            LastState = State;
            State = Keyboard.GetState();

            for (int i = 0; i < 132; i++)
            {
                Buffers[i] -= (float)Window.MainWindow.GlobalDeltaTime;

                if (GetKeyPressed((Key)i))
                {
                    Buffers[i] = FighterInput.BufferWindow;
                }
            }
        }

        public bool GetKeyBuffered(Key key)
        {
            return Buffers[(int)key] > 0;
        }

        public void EndBuffer(Key key)
        {
            Buffers[(int)key] = 0;
        }

        public bool GetKey(Key key)
        {
            return State.IsKeyDown(key);
        }

        public bool GetKeyPressed(Key key)
        {
            return State.IsKeyDown(key) && !LastState.IsKeyDown(key);
        }
        public bool GetKeyUp(Key key)
        {
            return !State.IsKeyDown(key) && LastState.IsKeyDown(key);
        }

        public int Subtract(Key left, Key right)
        {
            int Out = 0;

            if (GetKey(left))
                Out--;

            if (GetKey(right))
                Out++;

            return Out;
        }

        public bool IsAnyKeyDown()
        {
            return State.IsAnyKeyDown;
        }
    }
}
