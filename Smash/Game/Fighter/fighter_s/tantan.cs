using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.fighter_s
{
    public class tantan : fighter
    {
        public override void anm_attack11()
        {
            base.anm_attack11();

            CreateHitboxAtTime(6, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 9.3f }, { "Z", 10.0f }, { "Size", 4f }, { "EndTime", 3 }, { "HitLag", 3 } }, 0);

            ComboAttack(8, "attack12");
        }

        public override void anm_attack12()
        {
            base.anm_attack12();

            CreateHitboxAtTime(7, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 4f }, { "Z", 13.0f }, { "Size", 4f }, { "EndTime", 6 },{ "Angle",5f},{ "KB",5f}, { "HitLag", 3 } }, 0);

            ComboAttack(8, "attack100start");
        }

        public override void anm_attack100()
        {
            base.anm_attack100();

            if (anim.FinishedAnimation)
            {
                AttackA("attackend");
            }

            if (anim.CurrentKeyIndex % 2 == 0 && anim.CurrentKeyIndex != 0)
            {
                CreateHitboxAtTime(anim.CurrentKeyIndex, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7f }, { "Z", 13.0f }, { "Size", 4f }, { "EndTime", 1 }, { "HitLag", 1 } }, 0);
            }

           // GeneralSpeed = 0.1f;
        }

        public override void anm_attackend()
        {
            base.anm_attackend();

            CreateHitboxAtTime(5, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7f }, { "Z", 8.0f }, { "Size", 8f }, { "EndTime", 1 }, { "HitLag", 10 }, { "KB", 30f }, { "Angle", 60f } }, 0);
        }
    }
}
