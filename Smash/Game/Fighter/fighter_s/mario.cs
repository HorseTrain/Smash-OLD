using Smash.Game.Interaction;
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

            ComboAttack(8, "attack12");
        }

        public override void anm_attack12()
        {
            base.anm_attack12();

            ComboAttack(8,"attack13");

            EndAttack(11);
        }

        public override void anm_attack13()
        {
            base.anm_attack13();
        }

        public override void anm_attackairhi()
        {
            base.anm_attackairhi();

            EndAttack(28);
        }

        public override void anm_attackairn()
        {
            base.anm_attackairn();

            CreateHitboxAtTime(3, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 6f }, { "EndTime", 9 }, { "Angle", 60f }, { "Y",6f},{ "BKB", 5f }, { "HitLag", 10 }, { "KBMult", 0.9f }, { "Damage", 3f } }, 0);

            EndAttack(39);
        }

        public override void anm_attackairlw()
        {
            base.anm_attackairlw();

            if (anim.CurrentKeyIndex > 4 && anim.CurrentKeyIndex < 20)
            if (anim.CurrentKeyIndex % 2 == 0)
                CreateHitboxAtTime(anim.CurrentKeyIndex, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 6f }, { "EndTime", 1 }, { "Y", 6f }, { "HitLag", 1 }, { "Damage", 3f } }, anim.CurrentKeyIndex);

            CreateHitboxAtTime(22, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 6f }, { "EndTime", 1 }, { "Angle", 40f },{ "BKB",20f}, { "KBMult",0.1f},{ "Y", 6f }, { "HitLag", 20 }, { "Damage", 3f } }, 30);

            EndAttack(28);
        }

        public override void anm_attackairf()
        {
            base.anm_attackairf();
        }

        public override void anm_run()
        {
            base.anm_run();
        }
    }
}
