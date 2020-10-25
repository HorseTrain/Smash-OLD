using OpenTK;
using OpenTK.Input;
using SimpleGameEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Input
{
    public class JoystickInput
    {
        public int ControllerID { get; set; }

        JoystickState lastState { get; set; }
        public JoystickState state { get; set; }

        public ControllerAxis[] Axis = new ControllerAxis[10];

        public float[] Buffers = new float[20];
        public JoystickInput(int index)
        {
            this.ControllerID = index;

            for (int i = 0; i < Axis.Length; i++)
            {
                Axis[i] = new ControllerAxis(i);
            }
        }

        public void Update()
        {
            lastState = state;

            state = Joystick.GetState(ControllerID);

            foreach (ControllerAxis axis in Axis)
            {
                axis.Update(state);
            }

            for (int i = 0; i < 20; i++)
            {
                if (GetButtonPressed(i))
                {
                    Buffers[i] = FighterInput.BufferWindow;
                }

                Buffers[i] -= (float)Window.MainWindow.GlobalDeltaTime;
            }
        }

        public bool GetButton(int button)
        {
            return state.GetButton(button) == ButtonState.Pressed;
        }

        public bool GetButtonPressed(int button)
        {
            return  GetButton(button) && (lastState.GetButton(button) == ButtonState.Released);
        }

        public bool GetButtonReleased(int button)
        {
            return !GetButton(button) && lastState.GetButton(button) == ButtonState.Pressed;
        }

        public bool ButtonBuffered(int button)
        {
            return Buffers[button] > 0;
        }

        public void EndBuffer(int index)
        {
            Buffers[index] = 0;
        }

        public bool IsAnyKeyDown()
        {
            return state.IsAnyButtonDown;
        }
    }
}
