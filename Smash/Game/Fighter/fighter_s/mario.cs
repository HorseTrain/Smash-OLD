using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.fighter_s
{
    public class mario : fighter
    {
        public override void Wait()
        {
            base.Wait();

            anim.AnimationSpeed = 1.1f;
        }

        public override void anm_catch()
        {
            base.anm_catch();

            CreateHitboxAtTime(6,new Dictionary<string, object>() { { "Bone","Trans"}, { "X", 0f }, { "Y", 0f }, { "Z", 0f },{ "Size",10f},{"EndTime",2 } },0,Interaction.HitboxType.Grab);
        }

        public override void anm_attack11()
        {
            base.anm_attack11();

            EndAttack(11);
        }
    }
}
