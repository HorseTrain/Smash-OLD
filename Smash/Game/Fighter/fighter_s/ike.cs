using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter.fighter_s
{
    public class ike : fighter
    {
        public override void SetUp()
        {
            Peram = new FighterParam();

            Peram.TurnMode = 1;

            base.SetUp();
        }

        public override void anm_attackairn()
        {
            base.anm_attackairn();

        }

        public override void anm_attackairhi()
        {
            base.anm_attackairhi();


        }

        public override void anm_attackairlw()
        {
            base.anm_attackairlw();

        }

        public override void anm_attackairb()
        {
            base.anm_attackairb();

            EndAttack(30);
        }

        public override void anm_attackairf()
        {
            base.anm_attackairf();


            EndAttack(30);
        }

        public override void anm_attackhi3()
        {
            base.anm_attackhi3();

            EndAttack(20);
        }

        public override void anm_attacks4s()
        {
            base.anm_attacks4s();

        }

        public override void anm_attackhi4()
        {
            base.anm_attackhi4();
        }

        public override void anm_attacklw3()
        {
            base.anm_attacklw3();

            EndAttack(10);
        }

        public override void anm_attackdash()
        {
            base.anm_attackdash();
        }

        public override void anm_attacks3s()
        {
            base.anm_attacks3s();
        }

        public void AttackSword(int Frame, int Endtime,float BaseKnockBack, float Damage, float Angle,float KnockbackMultiplier,int HitLag)
        {
            CreateHitboxAtTime(Frame, new Dictionary<string, object>() { { "EndTime", Endtime }, { "Angle",Angle} ,{ "BKB", BaseKnockBack }, { "Damage", Damage }, { "KBMult", KnockbackMultiplier }, { "Bone", "Sword" },{ "Y",12f},{ "Size",3f},{ "HitLag",HitLag} }, 0, Interaction.HitboxType.Attack, 0);
            CreateHitboxAtTime(Frame, new Dictionary<string, object>() { { "EndTime", Endtime }, { "Angle", Angle }, { "BKB",BaseKnockBack }, { "Damage", Damage }, { "KBMult", KnockbackMultiplier },{ "Bone" , "Sword" }, { "Y", 5f }, { "Size", 3f }, { "HitLag", HitLag } }, 1, Interaction.HitboxType.Attack, 0);
        }
    }
}
