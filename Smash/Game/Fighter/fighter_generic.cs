using SimpleGameEngine.Graphics;
using SimpleGameEngine.IO.XML;
using Smash.Game.Scenes;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public enum TurnMode
    {
        TurnWithScale = 0,
        TurnWithRotation = 1
    }

    public partial class fighter
    {
        public static Random FighterRNG = new Random();

        public virtual void Wait()
        {
            if (!phy.Grounded)
            {
                anim.CrossFade("fall",100);
            }

            if (anim.CurrentAnimationName == "wait1")
            {
                WhenFinishedGoTo("wait" + FighterRNG.Next(1, 4));
            }
            else
            {
                WhenFinishedGoTo("wait1");
            }

            phy.MoveX(0, 5);

            DetectDash();

            DetectWalk();
        }

        public virtual void TurnWhenDone()
        {
            if (anim.FinishedAnimation)
            {
                Gdir *= -1;
            }
        }

        public virtual void WhenFinishedGoTo(string name,int lerp = 0)
        {
            if (anim.FinishedAnimation)
            {
                anim.CrossFade(name,lerp);
            }
        }

        public int Jumps { get; private set; }
        public virtual void DetectJump()
        {
            if (input.JumpButton.Buffered)
            {
                if (Jumps > 0)
                {
                    if (phy.Grounded)
                    {
                        if (anim.CurrentAnimationName == "turndash")
                        {
                            if (anim.CurrentKeyIndex > 5)
                            {
                                Gdir *= -1;
                            }
                        }

                        if (anim.CurrentAnimationName == "turnrun")
                        {
                            Gdir *= -1;
                        }

                        anim.CrossFade("jumpsquat"); 
                    }
                    else
                    {
                        if (input.Cdir.Dir == 0 || input.Cdir == Gdir)
                        {
                            anim.CrossFade("jumpaerialf", 0, true);
                        }
                        else
                        {
                            anim.CrossFade("jumpaerialb", 0, true);
                        }

                        phy.Velocity.Y = Peram.JumpHeight;
                    }

                    input.JumpButton.EndBuffer();
                }

                Jumps--;
            }
        }

        public bool Landed { get; private set; } = false;
        public float AirTime { get; private set; }

        public virtual void FighterGeneral()
        {
            if (!phy.Grounded)
            {
                if (!HoldingLedge)
                {
                    Air();
                }
            }
            else
            {
                Ground();
            }

            if (TurnWhenFinished)
            {
                if (anim.FinishedAnimation)
                {
                    Gdir *= -1;

                    TurnWhenFinished = false;
                }
            }

            ScriptMain();
        }

        public virtual void Air()
        {
            Landed = false;

            AirTime += (float)Window.MainWindow.DeltaTime;

            DetectJump();

            AirMovement();

            DetectFall();

            DetectHitTop();

            if (phy.Velocity.Y > 0)
                AirVelocityEverPositive = true;

            DetectAerial();
        }

        public virtual void AirMovement()
        {
            if (phy.Velocity.Y > 0.5f)
            {
                phy.DoGravity = false;

                phy.MoveY(0, Peram.JumpDrag);
            }

            if (input.Cdir != 0)
            {
                phy.MoveX(input.Cdir * Peram.AirSpeedMax,Peram.AirAcc);
            }
            else
            {
                phy.MoveX(0, Peram.AirAcc * 3);
            }
        }

        public virtual void Ground()
        {
            DetectLanding();

            DetectJump();

            AirVelocityEverPositive = false;
        }

        public virtual void DetectLanding()
        {
            if (!Landed)
            {
                if (!anim.CurrentAnimationName.Contains("attack"))
                {
                    if (AirTime < 20)
                        anim.CrossFade("landinglight");
                    else
                        anim.CrossFade("landingheavy");
                }
                else
                {
                    anim.CrossFade("landing" + Parsers.SplitString(6,anim.CurrentAnimationName));
                }

                Jumps = Peram.JumpCount;
                AirTime = 0;
                Landed = true;

                if (TurnWhenFinished)
                {
                    Gdir *= -1;
                    TurnWhenFinished = false;
                }
            }
        }

        public virtual void Jump()
        {
            if (anim.CurrentAnimationName.Contains("aerial"))
            {
                WhenFinishedGoTo("fallaerial");
            }
            else
            {
                WhenFinishedGoTo("fall");
            }
        }

        public virtual void Fall()
        {
            if (anim.CurrentAnimationName.Contains("aerial"))
            {
                if (input.Cdir == Gdir)
                {
                    anim.CrossFade("fallaerialf", 100, false, false);
                }
                else if (input.Cdir == -Gdir)
                {
                    anim.CrossFade("fallaerialb", 100, false, false);
                }
                else
                {
                    anim.CrossFade("fallaerial", 100, false, false);
                }
            }
            else
            {
                if (input.Cdir == Gdir)
                {
                    anim.CrossFade("fallf", 100, false, false);
                }
                else if(input.Cdir == -Gdir)
                {
                    anim.CrossFade("fallb", 100, false, false);
                }
                else
                {
                    anim.CrossFade("fall", 100, false, false);
                }
            }
        }

        public void Landing()
        {
            WhenFinishedGoTo("wait1");
            
            if (anim.CurrentKeyIndex > 3)
            {
                DetectWalk();
            }

            phy.MoveX(0,3);

            DetectDash();

            phy.HugLedge();
        }

        public void DetectDash()
        {
            if (input.Cdir.Tapped)
            {
                if (input.Cdir == Gdir)
                {
                    Dash("dash");
                }
                else
                {
                    Dash("turndash",true);
                }
            }
        }

        public void DetectWalk()
        {
            if (input.Cdir == -Gdir && !input.Cdir.Tapped)
            {
                anim.CrossFade("turn");

                phy.MoveX(input.Cdir,5);
            }

            if (input.Cdir == Gdir && !input.Cdir.Tapped)
            {
                anim.CrossFade("walkslow",100);
            }
        }

        public void Dash(string name,bool turn = false)
        {
            if (turn)
                phy.Velocity.X = -Gdir * Peram.DashSpeed;
            else
                phy.Velocity.X = Gdir * Peram.DashSpeed;

            anim.CrossFade(name,0,true);
        }

        float RunStopTimer = 0;
        public virtual void RunBreak()
        {
            DetectDash();

            WhenFinishedGoTo("wait1");

            phy.MoveX(0,Peram.RunBreakSpeed);

            phy.HugLedge();

            RunStopTimer = 0;
        }

        public void MoveInAnimation()
        {
            phy.Velocity.X = anim.MovementX * Gdir;
            phy.Velocity.Y = anim.MovementY;
        }

        public void Walk()
        {
            if (input.Cdir == 0)
            {
                anim.CrossFade("wait1", 100);
            }
            else if (Math.Abs(input.Cdir.Value) < 0.3f)
            {
                anim.CrossFade("walkslow",100);
            }
            else if (Math.Abs(input.Cdir.Value) >= 0.3f && Math.Abs(input.Cdir.Value) <= 0.7f)
            {
                anim.CrossFade("walkmiddle",100);
            }
            else if (Math.Abs(input.Cdir.Value) > 0.7f)
            {
                anim.CrossFade("walkfast",100);
            }

            MoveInAnimation();

            DetectDash();

            DetectMoveFall("walk");
        }

        public virtual void DetectFall()
        {

        }

        public void RunFall() //change to move falll?
        {
            WhenFinishedGoTo("fall",10);
        }

        public void DetectMoveFall(string name = "run")
        {
            if (!phy.Grounded)
            {
                if (anim.CurrentAnimationName == "turndash")
                {
                    Gdir *= -1;
                }

                float rt = (float)Math.Abs(skeleton.GetNode("ToeR").WorldTransform.ExtractTranslation().X);
                float lt = (float)Math.Abs(skeleton.GetNode("ToeL").WorldTransform.ExtractTranslation().X);

                if (rt >= lt)
                {
                    anim.CrossFade(name + "fallr");
                }
                else
                {
                    anim.CrossFade(name + "falll");
                }
            }
        }

        public void DetectHitWall()
        {
            if (phy.HitSide)
            {
                if (anim.CurrentAnimationName == "turndash")
                    Gdir *= -1;

                anim.CrossFade("stopwall");
            }
        }

        public void DetectHitTop()
        {
            if (phy.HitTop)
            {
                anim.CrossFade("stopceil");
            }
        }

        public bool AirVelocityEverPositive { get; set; }

        public virtual void DetectAerial()
        {
            if (input.AttackController.Buffered)
            {
                switch (input.AttackController.Direction)
                {
                    case Input.ControllerDirection.Up: AttackA("attackairhi"); break;
                    case Input.ControllerDirection.Forward: AttackA("attackairf"); break;
                    case Input.ControllerDirection.Back: AttackA("attackairb"); break;
                    case Input.ControllerDirection.Down: AttackA("attackairlw"); break;
                    case Input.ControllerDirection.Neuteral: AttackA("attackairn"); break;
                }    
            }
        }

        public virtual void AttackAir()
        {
            WhenFinishedGoTo("fall");            
        }

        public void AttackA(string name,bool force = false)
        {
            input.AttackController.KillBuffer();

            anim.CrossFade(name,0, force);
        }

        List<XMLElement> elements { get; set; } = new List<XMLElement>();

        bool TurnWhenFinished { get; set; }

        public void RunAnimationPerams()
        {

        }

        public void Push(float x, float y)
        {
            phy.Velocity = new OpenTK.Vector2(x, y);
        }

        public void Entry()
        {
            WhenFinishedGoTo("wait1");
        }
    }
}
