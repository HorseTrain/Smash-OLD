using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public class FighterParam : XMLParsable //By default mario
    {
        public float JumpHeight { get; set; } = 8;
        public float ShortJumpHeight { get; set; } = 4;
        public float FallSpeed { get; set; } = 0.08f;
        public int JumpCount { get; set; } = 2;
        public float JumpDrag { get; set; } = 5;
        public float TermenalVelocity { get; set; } = 1.5f;
        public float DashSpeed { get; set; } = 2;
        public float RunBreakSpeed { get; set; } = 8;
        public float TurnRunSpeed { get; set; } = 10;
        public int DashMid { get; set; } = 11;
        public float AirAcc { get; set; } = 20;
        public float AirSpeedMax { get; set; } = 1.5f;
        public int TurnMode { get; set; } 
    }
}
