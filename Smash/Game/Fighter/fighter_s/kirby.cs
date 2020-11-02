using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.fighter_s
{
    public class kirby : fighter
    {
        public override void DetectJump()
        {
            base.DetectJump();

            if (JumpedB)
            {
                anim.CrossFade("jumpaerialf");

                InitSlowTurn(10);
            }
        }

    }
}
