using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.fighter_s
{
    public class roy : fighter
    {
        public override void anm_attack11()
        {
            base.anm_attack11();

            AttackSword(4,3,20,40,7.5f,60,0.1f,10);
        }

        public void AttackSword(int Frame, int Endtime, float BaseKnockBack, float KnockBack, float Damage, float Angle, float KnockbackMultiplier, int HitLag)
        {
            CreateHitboxAtTime(Frame, new Dictionary<string, object>() { { "EndTime", Endtime }, { "Angle", Angle }, { "BKB", BaseKnockBack }, { "KB", KnockBack }, { "Damage", Damage }, { "KBMult", KnockbackMultiplier }, { "Bone", "HandR" }, { "Y", 10f }, { "Size", 5f }, { "HitLag", HitLag } }, 0, Interaction.HitboxType.Attack, 0);
            CreateHitboxAtTime(Frame, new Dictionary<string, object>() { { "EndTime", Endtime }, { "Angle", Angle }, { "BKB", BaseKnockBack / 4 }, { "KB", KnockBack/2 }, { "Damage", Damage }, { "KBMult", KnockbackMultiplier }, { "Bone", "HandR" }, { "Y", 5f }, { "Size", 4f }, { "HitLag", HitLag/2 } }, 1, Interaction.HitboxType.Attack, 0);
        }
    }
}
