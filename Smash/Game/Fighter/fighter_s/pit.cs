using Smash.Game.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.fighter_s
{
    public class pit : fighter
    {
        public override void SetUp()
        {
            Peram = new FighterParam();

            Peram.TurnMode = (int)TurnMode.TurnWithRotation;
            Peram.JumpCount = 5;
            Peram.ShortJumpHeight = 3f;
            Peram.JumpHeight = 5f;

            base.SetUp();
        }

        public override void anm_attackairn()
        {
            base.anm_attackairn();

            for (int i = 0; i < 7; i ++)
            {
                CreateHitboxAtTime(3 + (i*2),new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 10f },{ "Z",7f}, { "HitLag", 3 }, { "Damage", 0.7f } },i);
            }

            CreateHitboxAtTime(24, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 10f }, { "Z", 7f }, { "HitLag", 20 },{ "BKB",20f},{ "Angle",60f}, { "KBMult", 0.8f }, { "Damage", 5f } }, 25);

            EndAttack(35);
        }

        public override void anm_attack11()
        {
            base.anm_attack11();

            CreateHitboxAtTime(5, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 8f }, { "Z", 15f }, { "HitLag", 3 }, { "Damage", 0.7f } }, 0);

            ComboAttack(8,"attack12");
        }

        public override void anm_attack12()
        {
            base.anm_attack12();

            CreateHitboxAtTime(4, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 8f }, { "Z", 15f }, { "HitLag", 3 }, { "Damage", 0.7f } }, 0);

            ComboAttack(5,"attack100start");
        }

        public override void anm_attack100()
        {
            base.anm_attack100();

            if (anim.CurrentKeyIndex % 2 == 0)
            {
                CreateHitboxAtTime(anim.CurrentKeyIndex, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 8f }, { "Z", 15f }, { "HitLag", 2 }, { "Damage", 0.7f } }, 0);
            }
        }

        public override void anm_attackend()
        {
            base.anm_attackend();

            CreateHitboxAtTime(3, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 20 }, { "Y", 8f }, { "Z", 15f }, { "HitLag", 10 }, { "BKB", 20f },{ "Angle",65f}, { "KBMult", 0.5f }, { "Damage", 0.7f } }, 0);

            EndAttack(30);
        }

        public override void anm_attacklw3()
        {
            base.anm_attacklw3();

            CreateHitboxAtTime(6, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 3 }, { "Y", 8f }, { "Z", 15f }, { "HitLag", 10 }, { "BKB", 15f }, { "Angle", 10f }, { "KBMult", 0.8f }, { "Damage", 0.7f } }, 0);

            EndAttack(15);
        }

        public override void anm_attacklw4()
        {
            base.anm_attacklw4();

            CreateHitboxAtTime(5, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 3 }, { "Y", 8f }, { "Z", 15f }, { "HitLag", 15 }, { "BKB", 20f }, { "Angle", 70f }, { "KBMult", 2f }, { "Damage", 5f } }, 0);

            CreateHitboxAtTime(16, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 3 }, { "Y", 8f }, { "Z", -15f }, { "HitLag", 15 }, { "BKB", 20f }, { "Angle", -70f }, { "KBMult", 2f }, { "Damage", 5f } }, 0);
        }

        public override void anm_attackairf()
        {
            base.anm_attackairf();

            for (int i = 0; i < 8; i++)
            {
                CreateHitboxAtTime(11 + (i * 2), new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 7f }, { "Z", 15f }, { "HitLag", 2 }, { "Damage", 0.7f } }, i);
            }

            CreateHitboxAtTime(27, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 10f }, { "Z", 7f }, { "HitLag", 20 }, { "BKB", 5f }, { "Angle", 60f }, { "KBMult", 1.3f }, { "Damage", 5f } }, 25);
        }

        public override void anm_attackhi3()
        {
            base.anm_attackhi3();

            CreateHitboxAtTime(5, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 6f }, { "EndTime", 1 }, { "Y", 12f }, { "Z", 10f },{ "BKB",20f}, { "HitLag", 3 }, { "Damage", 3f } }, 0);

            CreateHitboxAtTime(14, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 6f }, { "EndTime", 1 }, { "Y", 25f }, { "Z", 10f },{ "Angle",0f}, { "HitLag", 10 },{ "BKB",10f},{ "KBMult",0.5f}, { "Damage", 0.7f } }, 0);

            EndAttack(20);
        }

        public override void anm_attackairhi()
        {
            base.anm_attackairhi();

            for (int i = 0; i < 4; i++)
            {
                CreateHitboxAtTime(12 + (i *3), new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 15f }, { "Z", 0f }, { "HitLag", 2 }, { "Damage", 0.7f } }, 0);
            }

            CreateHitboxAtTime(24, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Y", 15f }, { "Z", 0f },{ "HitLag",20},{ "Angle",20f},{ "BKB",30f},{"KBMult",1.5f}, { "Damage", 8f } }, 0);
        }

        public override void anm_attackairb()
        {
            base.anm_attackairb();

            CreateHitboxAtTime(10, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 3 }, { "Y", 5f }, { "Z", -13f }, { "HitLag", 20 }, { "Angle", -60f }, { "BKB", 10f }, { "KBMult", 2.3f }, { "Damage", 7f } }, 0);
        }

        public override void anm_attackairlw()
        {
            base.anm_attackairlw();

            CreateHitboxAtTime(9, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 3 }, { "Y", 0f }, { "Z", 0f }, { "HitLag", 20 }, { "Angle", 180f }, { "BKB", 5f }, { "KBMult", 1f }, { "Damage", 7f } }, 0);
        }

        public override void anm_attacks4s()
        {
            base.anm_attacks4s();

            CreateHitboxAtTime(9, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 3 }, { "Y", 5f }, { "Z", 10f}, { "HitLag", 10 }, { "Damage", 3f } }, 0);

            CreateHitboxAtTime(20, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 3 }, { "Y", 5f }, { "Z", 10f }, { "HitLag", 20 },{ "BKB",5f},{ "KBMult",2.5f},{ "Angle",70f}, { "Damage", 3f } }, 0);
        }

        public override void anm_attackhi4()
        {
            base.anm_attackhi4();

            CreateHitboxAtTime(5, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 },{ "Angle",-20f},{ "BKB",25f}, { "Y", 5f }, { "Z", 10f }, { "HitLag", 5 }, { "Damage", 3f } }, 0);
            CreateHitboxAtTime(5, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 1 }, { "Angle", 20f }, { "BKB", 25f }, { "Y", 5f }, { "Z", -10f }, { "HitLag", 5 }, { "Damage", 3f } }, 1);

            CreateHitboxAtTime(9, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 10f }, { "EndTime", 1 },{ "BKB",10f}, { "Y", 30f }, { "Z", 0f }, { "HitLag", 5 }, { "Damage", 3f } },2);
            CreateHitboxAtTime(17, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 10f }, { "EndTime", 1 }, { "BKB", 20f },{ "Angle",10f},{ "KBMult",1.5f}, { "Y", 30f }, { "Z", 0f }, { "HitLag", 20 }, { "Damage", 3f } }, 3);

            EndAttack(30);
        }

        public override void anm_attacks3s()
        {
            base.anm_attacks3s();

            CreateHitboxAtTime(9, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 10 },{ "Angle",70f},{ "KBMult",0.8f},{ "BKB",10f}, { "Y", 5f }, { "Z", 10f }, { "HitLag", 5 }, { "Damage", 3f } }, 0);
        }

        public override void anm_attackdash()
        {
            base.anm_attackdash();

            CreateHitboxAtTime(6, new Dictionary<string, object>() { { "Bone", "Trans" }, { "Size", 8f }, { "EndTime", 10 }, { "Angle", 50f }, { "KBMult", 0.8f }, { "BKB", 80f }, { "Y", 5f }, { "Z", 10f }, { "HitLag", 5 }, { "Damage", 3f } }, 0);
        }

        public override void DetectJump()
        {
            base.DetectJump();

            if (JumpedB)
            {
                anim.CrossFade("jumpaerialf");

                InitSlowTurn(10);
            }
        }      

        public override void anm_run()
        {
            base.anm_run();
        }
    }
}
