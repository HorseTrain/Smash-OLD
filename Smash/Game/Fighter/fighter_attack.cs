using OpenTK.Graphics.ES11;
using SimpleGameEngine.Graphics;
using Smash.Game.Input;
using Smash.Game.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public partial class fighter
    {
        Dictionary<int,Hitbox[]> ExistingQue = new Dictionary<int, Hitbox[]>();
        public bool DestroyAllHitBoxes { get; set; }
        public bool InAttack { get; set; } = false;
        bool Attacked { get; set; }

        public List<fighter>[] FighterHitExclusion;

        public void ResetExclusionQue()
        {
            FighterHitExclusion = new List<fighter>[100];

            for (int i = 0; i < FighterHitExclusion.Length; i++)
            {
                FighterHitExclusion[i] = new List<fighter>();
            }
        }

        public void AttackMain()
        {            
            if (anim.AnimationChange)
            {
                ResetExclusionQue();

                ExistingQue = new Dictionary<int, Hitbox[]>();

                //HitLayers = new HashSet<int>();

                if (!Attacked)
                {
                    InAttack = false;
                }
            }

            DestroyAllHitBoxes = anim.AnimationChange;

            DetectAttacks();

            Attacked = false;
        }

        ControllerDirection bufferedg;

        float ckill = 3;

        public void DetectAttacks()
        {
            ckill -= Window.MainWindow.GlobalDeltaTime;

            if (ckill < 0)
                bufferedg = ControllerDirection.Null;

            if (!InAttack)
            {
                if (phy.Grounded)
                {
                    if (anim.CurrentAnimationName != "jumpsquat" && phy.Velocity.Y <= 0)
                    {
                        if (bufferedg != ControllerDirection.Null)
                        {
                            if (input.Ydir.TapBuffered || input.Cdir.TapBuffered)
                            {
                                switch (bufferedg)
                                {
                                    case ControllerDirection.Up: AttackA("attackhi4"); break;
                                    case ControllerDirection.Down: AttackA("attacklw4"); break;
                                    case ControllerDirection.Forward: AttackA("attacks4s"); break;
                                    case ControllerDirection.Back: AttackA("attacks4s"); Gdir *= -1; break;
                                }
                            }
                            else
                            {
                                switch (bufferedg)
                                {
                                    case ControllerDirection.Neuteral: if (anim.CurrentAnimationName.Contains("turn")) Gdir *= -1; AttackA("attack11"); break;
                                    case ControllerDirection.Up: AttackA("attackhi3"); break;
                                    case ControllerDirection.Down: AttackA("attacklw3"); break;
                                }

                                if (bufferedg == ControllerDirection.Forward || bufferedg== ControllerDirection.Back)
                                {
                                    if (anim.CurrentAnimationName.Contains("dash") && anim.CurrentKeyIndex > 5)
                                    {
                                        AttackA("attackdash");

                                        Gdir = input.Cdir;
                                    }
                                    else if (anim.CurrentAnimationName == "run")
                                    {
                                        AttackA("attackdash");
                                    }
                                    else
                                    {
                                        AttackA("attacks3s");
                                    }
                                }
                            }
                        }

                        if (input.AButton.Buffered)
                        {
                            bufferedg = input.AttackController.Direction;

                            input.AButton.EndBuffer();

                            ckill = 5;
                        }
                    }
                }
                else
                {
                    DetectAerial();
                }
            }
        }

        public void CreateHitboxAtTime(int frame,Dictionary<string,object> Data,int ID,HitboxType Type = HitboxType.Attack,int HitboxLayer = -1)
        {
            if (anim.CurrentKeyIndex == frame)
            {
                CreateHitbox(Data,ID,Type, HitboxLayer);
            }
        }

        public Hitbox CreateHitbox(Dictionary<string,object> Data,int ID,HitboxType Type,int HLayer)
        {
            int frame = anim.CurrentKeyIndex;

            if (!ExistingQue.ContainsKey(frame))
            {
                ExistingQue.Add(frame,new Hitbox[100]);
            }

            if (ExistingQue[frame][ID] == null)
            {
                Hitbox Out = new Hitbox();

                Out.fRef = this;

                Out.Data = Data;
                Out.SetUp(Type, HLayer);

                ExistingQue[frame][ID] = Out;
            }

            return ExistingQue[frame][ID];
        }

        public void EndAttack(int frame)
        {
            if (anim.CurrentKeyIndex >= frame)
                InAttack = false;
        }

        public virtual void DetectAerial()
        {
            if (input.AttackController.Buffered)
            {
                switch (input.AttackController.Direction)
                {
                    case ControllerDirection.Up: AttackA("attackairhi"); break;
                    case ControllerDirection.Forward: AttackA("attackairf"); break;
                    case ControllerDirection.Back: AttackA("attackairb"); break;
                    case ControllerDirection.Down: AttackA("attackairlw"); break;
                    case ControllerDirection.Neuteral: AttackA("attackairn"); break;
                }
            }
        }

        public void ComboAttack(int frame, string name)
        {
            if (input.AButton.Buffered && anim.CurrentKey >= frame) 
            {
                AttackA(name,true);
            }
        }

        public void DamageN()
        {
            WhenFinishedGoTo("wait1");

            phy.MoveX(0,5);
        }

        public void GroundAttack(string endname = "wait1")
        {
            WhenFinishedGoTo(endname);

            phy.Velocity.X = anim.MovementX * Gdir;

            phy.HugLedge();
        }
    }
}
