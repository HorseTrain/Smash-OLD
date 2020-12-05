using MoonSharp.Interpreter;
using OpenTK;
using OpenTK.Input;
using SimpleGameEngine.Graphics;
using Smash.Game.Fighter;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Smash.Game.Input
{
    public enum ControllerMode
    {
        Keyboard,
        Controller
    }

    public enum ControllerDirection
    {
        Up,
        Forward,
        Down,
        Back,
        Neuteral,
        Null
    }

    public enum CstickMode
    {
        Attack,
        Smash,
        Special
    }

    [MoonSharpUserData]
    public class MultiButtonSet
    {
        public bool Buffered;
        public bool Pressed;
        public bool Down;
        public bool Released;

        Button[] buttons;

        public MultiButtonSet(Button[] Buttons)
        {
            buttons = Buttons;

            foreach (Button button in Buttons)
            {
                if (button.Buffered)
                {
                    Buffered = true;
                }

                if (button.Pressed)
                {
                    Pressed = true;
                }

                if (button.Down)
                {
                    Down = true;
                }

                if (button.Released)
                {
                    Released = true;
                }
            }
        }

        public void EndBuffer()
        {
            foreach (Button button in buttons)
            {
                button.EndBuffer();
            }
        }

        public void VBuffer()
        {
            Buffered = true;
        }
    }

    [MoonSharpUserData]
    public class FighterInput
    {
        public const int BufferWindow = 10;
        public ControllerMode mode { get; set; } = ControllerMode.Keyboard;
        public KeyboardController KS { get; set; }
        public JoystickInput JS { get; set; }
        public fighter fighterref { get; set; }

        List<Button> Inputs { get; set; } = new List<Button>();
        List<InputAxis> Axis { get; set; } = new List<InputAxis>();

        public InputAxis Cdir => Axis[0];
        public InputAxis Ydir => Axis[1];
        public Stick MovementStick { get; set; }
        public Stick CStick { get; set; }
        public MultiButtonSet JumpButton => new MultiButtonSet(new Button[] { Inputs[0], Inputs[4] });
        public MultiButtonSet AButton => new MultiButtonSet(new Button[] { Inputs[1] });
        public MultiButtonSet BButton => new MultiButtonSet(new Button[] { Inputs[2] });
        public MultiButtonSet CatchButton => new MultiButtonSet(new Button[] { Inputs[3] });
        public CstickMode cStickMode { get; set; } = CstickMode.Attack;

        public AttackBuffer AttackControllerA { get; set; } = new AttackBuffer();
        public AttackBuffer AttackControllerB { get; set; } = new AttackBuffer();

        public FighterInput(fighter fref)
        {
            fighterref = fref;

            JS = new JoystickInput(fref.Index);
            KS = new KeyboardController();

            Inputs.Add(new Button(Key.Space,6)); // Jump

            Inputs.Add(new Button(Key.Z, 1));
            Inputs.Add(new Button(Key.X, 2));
            Inputs.Add(new Button(Key.C,5 ));

            Inputs.Add(new Button(Key.LShift, 3)); // Jump1

            Axis.Add(new InputAxis(Key.Left,Key.Right,0));
            Axis.Add(new InputAxis(Key.Down, Key.Up, 1,true));

            Axis.Add(new InputAxis(Key.A, Key.D, 4));
            Axis.Add(new InputAxis(Key.S, Key.W, 5, true));

            MovementStick = new Stick(Cdir, Ydir, fighterref); 
            CStick = new Stick(Axis[2], Axis[3], fighterref);
        }

        public void Update()
        {
            KS.Update();
            JS.Update();

            if (fighterref.Index == 0)
            {
                if (KS.IsAnyKeyDown())
                    mode = ControllerMode.Keyboard;

                if (JS.IsAnyKeyDown())
                    mode = ControllerMode.Controller;

                foreach (Button button in Inputs)
                {
                    button.Update(KS, JS, mode);
                }

                foreach (InputAxis axis in Axis)
                {
                    axis.Update(KS, JS, mode);
                }

                MovementStick.Update(fighterref);
                CStick.Update(fighterref);

                DetectAttack();

                AttackControllerA.Update();
                AttackControllerB.Update();
            }
            else
            {
                
            }
        }

        public void DetectAttack()
        {
            if (AButton.Buffered)
            {
                AttackControllerA.BufferAttack(MovementStick.AttackDirection);

                AButton.EndBuffer();
            }

            if (BButton.Buffered)
            {
                AttackControllerB.BufferAttack(MovementStick.AttackDirection);

                BButton.EndBuffer();
            }

            if (CStick.SlowTapped)
            {
                AttackControllerA.BufferAttack(CStick.AttackDirection);
            }
        }

        public static int GetDir(float x)
        {
            if (x < 0)
                return -1;

            if (x > 0)
                return 1;

            return 0;
        }
    }

    [MoonSharpUserData]
    public class Button
    {
        public Key keyboardKey { get; set; }
        public int ControllerIndex { get; set; }

        KeyboardController cachedks;
        JoystickInput cachedjs;

        public Button(Key key = 0,int controller = 0)
        {
            keyboardKey = key;
            ControllerIndex = controller;
        }

        public void Update(KeyboardController ks, JoystickInput js,ControllerMode mode)
        {
            cachedks = ks;
            cachedjs = js;

            switch (mode)
            {
                case ControllerMode.Controller: Pressed = js.GetButtonPressed(ControllerIndex); Released = js.GetButtonReleased(ControllerIndex); Down = js.GetButton(ControllerIndex); Buffered = js.ButtonBuffered(ControllerIndex); break;
                case ControllerMode.Keyboard: Pressed = ks.GetKeyPressed(keyboardKey); Released = ks.GetKeyUp(keyboardKey); Down = ks.GetKey(keyboardKey); Buffered = ks.GetKeyBuffered(keyboardKey); break;
            }
        }

        public void EndBuffer()
        {
            if (cachedjs != null)
            cachedjs.EndBuffer(ControllerIndex);

            if (cachedks != null)
            cachedks.EndBuffer(keyboardKey);
        }

        public bool Pressed { get; private set; }
        public bool Released { get; private set; }
        public bool Down { get; private set; }
        public bool Buffered { get; set; }
    }

    [MoonSharpUserData]
    public class InputAxis
    {
        float LastValue { get; set; }
        public float Value { get; private set; }
        public int Dir { get; private set; }
        public bool Tapped { get; private set; }
        public bool Released { get; private set; } = true;
        public int Ldir { get; private set; }
        public bool TapBuffered => TapBuffer > 0;
        public bool SlowTap { get;private set; }
        float TapBuffer { get; set; }

        Key l, r;
        int index;

        int dir = 1;
        int kdir = 1;

        public InputAxis(Key left, Key right,int axisindex,bool invert = false,bool invertkeys = false)
        {
            l = left;
            r = right;
            index = axisindex;

            if (invert)
                dir = -1;

            if (invertkeys)
                kdir = -1;
        }

        public void Update(KeyboardController ks, JoystickInput js, ControllerMode mode)
        {
            TapBuffer -= Window.MainWindow.GlobalDeltaTime;

            switch (mode)
            {
                case ControllerMode.Controller: Value = js.Axis[index].value * dir; Tapped = js.Axis[index].Tapped; Dir = js.Axis[index].Dir * dir; break;
                case ControllerMode.Keyboard: 
                    
                    Dir = kdir * ks.Subtract(l, r);

                    Tapped = false;

                    if (Released)
                    {
                        if (Dir != 0)
                        {
                            Tapped = true;
                            Released = false;
                        }
                    }
                    else
                    {
                        if (Dir == 0)
                        {
                            Released = true;
                        }
                    }

                    Value = Dir;
                    
                    break;
            }

            if (Dir != 0)
                Ldir = Dir;

            if (Tapped)
                TapBuffer = 5;

            SlowTap = (Math.Abs(LastValue) <= 0.5f && Math.Abs(Value) > 0.5f);

            LastValue = Value;
        }

        public static implicit operator int(InputAxis axis)
        {
            return axis.Dir;
        }
    }

    [MoonSharpUserData]
    public class Stick
    {
        public InputAxis x { get; private set; }
        public InputAxis y { get; private set; }
        public bool Relesaed { get; private set; }
        bool checkrelease { get; set; }
        public bool SlowTapped => x.SlowTap || y.SlowTap;
        public bool CanUse { get; set; }

        int Gdir { get; set; }

        public Stick(InputAxis X, InputAxis Y,fighter fighterref)
        {
            x = X;
            y = Y;

            Gdir = fighterref.Gdir;
        }

        public float Angle => MathHelper.RadiansToDegrees((float)Math.Acos(Vector2.Dot(new Vector2(0, 1), new Vector2(x.Value, y.Value))));
        public float Size => new Vector2(x.Value,y.Value).Length;
        public ControllerDirection AttackDirection
        {
            get
            {
                float angle = Angle;

                float asplit = 70;

                if (Size > 0.5f)
                {
                    if (angle < asplit)
                    {
                        return ControllerDirection.Up;
                    }
                    else if (angle >= asplit && angle < (180 - asplit))
                    {
                        if (x.Dir == Gdir)
                        {
                            return ControllerDirection.Forward;
                        }
                        else

                        {
                            return ControllerDirection.Back;
                        }
                    }
                    else
                    {
                        return ControllerDirection.Down;
                    }
                }
                else
                {
                    return ControllerDirection.Neuteral;
                }
            }
        }
        
        public void Update(fighter fref)
        {
            Gdir = fref.Gdir;

            Relesaed = false;

            if (Size > 0.2f)
            {
                checkrelease = true;
            }

            if (checkrelease)
            {
                if (Size < 0.2f)
                {
                    Relesaed = true;
                    CanUse = true;
                    checkrelease = false;
                }
            }
        }

        public void StopUse()
        {
            CanUse = false;
        }
    }

    [MoonSharpUserData]
    public class AttackBuffer
    {
        public float BufferLocation { get; private set; }
        public int Direction { get; set; }

        public void Update()
        {
            BufferLocation -= (float)Window.MainWindow.GlobalDeltaTime;
        }

        public bool Buffered => BufferLocation > 0;

        public void BufferAttack(ControllerDirection dir)
        {
            BufferLocation = FighterInput.BufferWindow;
            Direction = (int)dir;
        }

        public void KillBuffer()
        {
            BufferLocation = 0;
        }
    }
}
