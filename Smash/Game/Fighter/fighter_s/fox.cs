using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.fighter_s
{
    public class fox : fighter
    {
        public override void SetUp()
        {
            Peram = new FighterParam();

            Peram.TurnMode = (int)TurnMode.TurnWithRotation;
            Peram.FallSpeed = 0.1f;
            Peram.TermenalVelocity = 2;

            base.SetUp();
        }

        public override void anm_attack11()
        {
            base.anm_attack11();

            ComboAttack(5,"attack12");

            CreateHitboxAtTime(1,new Dictionary<string, object>() { { "Bone","Trans"},{"Y",9.3f },{ "Z",7.0f},{ "Size",4f},{ "EndTime",6},{ "HitLag",3} },0);
        }

        public override void anm_attack12()
        {
            base.anm_attack12();

            CreateHitboxAtTime(2, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7f }, { "Z", 13.0f }, { "Size", 4f }, { "EndTime", 6 }, { "HitLag", 3 } }, 0);

            ComboAttack(5, "attack100start");
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
        }

        public override void anm_attackend()
        {
            base.anm_attackend();

            CreateHitboxAtTime(3, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7f }, { "Z", 13.0f }, { "Size", 4f }, { "EndTime", 1 }, { "HitLag", 20 },{"BKB",30f},{ "Angle",60f} }, 0);
        }

        public override void anm_attacklw3()
        {
            base.anm_attacklw3();

            CreateHitboxAtTime(6, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y",2f},{ "Z",6f},{ "Size", 5f }, { "EndTime", 5 }, { "HitLag", 10 }, { "BKB", 20f }, { "Angle", 10f } }, 0);
        }

        public override void anm_attackhi3()
        {
            base.anm_attackhi3();

            CreateHitboxAtTime(1, new Dictionary<string, object>() { { "Bone", "ToeR" }, { "Size", 5f }, { "EndTime", 5 }, { "HitLag", 5 }, { "BKB", 20f }, { "Angle", 0f } }, 0);

            EndAttack(20);
        }

        public override void anm_attacks3s()
        {
            base.anm_attacks3s();

            CreateHitboxAtTime(5, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7.5f }, { "Z", 8f }, { "Size", 4.5f }, { "EndTime", 3 }, { "HitLag", 5 }, { "BKB", 10f }, { "Angle", 60f } }, 0);

            EndAttack(9);
        }

        public override void anm_attackairn()
        {
            base.anm_attackairn();

            EndAttack(41);
        }

        public override void anm_attackairf()
        {
            base.anm_attackairf();

            for (int i = 6; i < 26; i += 5)
            CreateHitboxAtTime(i, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7f }, { "Z", 10.0f }, { "Size", 5f }, { "EndTime", 1 }, { "HitLag", 2 } }, 0);

            CreateHitboxAtTime(27, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7f }, { "Z", 10.0f }, { "Size", 5f }, { "EndTime", 1 }, { "HitLag", 10 },{ "Angle",60f},{ "BKB", 20f} }, 0);

            EndAttack(45);
        }
        public override void anm_attackairb()
        {
            base.anm_attackairb();

            CreateHitboxAtTime(8, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 7f }, { "Z", -10f }, { "Size", 5f }, { "EndTime", 1 }, { "HitLag",10 },{ "Angle",-60f},{ "BKB", 20f} }, 0);

            EndAttack(18);
        }

        public override void anm_attackdash()
        {
            base.anm_attackdash();

            CreateHitboxAtTime(6, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 4f }, { "Z", 4f }, { "Size", 6f }, { "EndTime", 8 }, { "HitLag", 3 },{ "Angle",40f},{ "BKB", 30f} }, 0);
        }


        public override void anm_attackairlw()
        {
            base.anm_attackairlw();

            if (anim.CurrentKeyIndex >= 4 && anim.CurrentKeyIndex % 4 == 0 && anim.CurrentKeyIndex < 28)
            CreateHitboxAtTime(anim.CurrentKeyIndex, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Y", 10f }, { "Size", 10f }, { "EndTime", 1 }, { "HitLag", 1 } }, 0);

            EndAttack(28);
        }

        public override void anm_attackairhi()
        {
            base.anm_attackairhi();

            EndAttack(25);
        }
    }
}
