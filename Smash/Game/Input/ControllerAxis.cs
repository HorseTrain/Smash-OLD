using OpenTK.Input;
using SimpleGameEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Input
{
    public class ControllerAxis
    {
        public int AxisIndex { get; set; }
        public float value { get; private set; }
        float tapcounter { get; set; }
        public bool released { get; private set; }
        public bool Tapped { get; private set; }
        public float Mult = 1 / 0.7f;
        public bool Inverted { get; set; } = false;

        public ControllerAxis(int index)
        {
            AxisIndex = index;
        }

        int interval = 3;

        public void Update(JoystickState state)
        {
            value = (int)(state.GetAxis(AxisIndex) * Mult * interval) / (float)interval;

            if (Inverted)
                value *= -1;

            Tapped = false;

            if (Math.Abs(value) > 0.2f)
            {
                tapcounter += (float)Window.MainWindow.DeltaTime;

                if (tapcounter < 5)
                {
                    if (Math.Abs(value) > 0.9f && released)
                    {
                        Tapped = true;
                        released = false;
                    }
                }
            }
            else
            {
                tapcounter = 0;

                released = true;
            }
        }

        public int Dir
        {
            get
            {
                if (value < 0)
                    return -1;

                if (value > 0)
                    return 1;

                return 0;
            }
        }
    }
}
