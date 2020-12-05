using MoonSharp.Interpreter;
using SimpleGameEngine.Graphics;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public partial class fighter 
    {
        public bool Landed;

        public float FallTime;
        public bool FastFalling;
        public int JumpCount;

        public float RunStop = 5;
        public float WalkStart = 5;
        public float AttackInputLag = 3;

        public float SmashAttackLag = 3;

        public float JumpDrag = 2;

        public bool InHitStun = false;

        public float Damage = 0;

        public float GameDeltaTime => Window.MainWindow.GlobalDeltaTime;

        public bool InAttack = false;

        public string AnimationEnd => Parsers.SplitString(anim.CurrentAnimationName.Length - 3,anim.CurrentAnimationName);

        public void Turn()
        {
            Gdir *= -1;
        }

        public void MoveInAnimation()
        {
            phy.SetVelocity(anim.MovementX * Gdir,anim.MovementY);
        }

        public bool FootMajor()
        {
            return ((Math.Abs(skeleton.GetNode("ToeR").WorldPosition.X) > Math.Abs(skeleton.GetNode("ToeL").WorldPosition.X)));
        }
    }
}
