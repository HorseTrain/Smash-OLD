using Smash.Game.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public partial class fighter
    {
        Dictionary<int,Hitbox[]> ExistingQue = new Dictionary<int, Hitbox[]>();
        public bool DestroyAllHitBoxes { get; set; }

        public void AttackMain()
        {
            if (anim.AnimationChange)
            {
                ExistingQue = new Dictionary<int, Hitbox[]>();
            }

            DestroyAllHitBoxes = anim.AnimationChange;
        }

        public void CreateHitboxAtTime(int frame,string bone,Dictionary<string,object> Data,int ID)
        {
            if (anim.CurrentKeyIndex == frame)
            {
                CreateHitbox(bone,Data,ID);
            }
        }

        public Hitbox CreateHitbox(string Bone,Dictionary<string,object> Data,int ID)
        {
            int frame = anim.CurrentKeyIndex;

            if (!ExistingQue.ContainsKey(frame))
            {
                ExistingQue.Add(frame,new Hitbox[20]);
            }

            if (ExistingQue[frame][ID] == null)
            {
                Hitbox Out = new Hitbox();

                Out.Data = Data;

                Out.fref = this;
                Out.transform = skeleton.GetNode(Bone);

                ExistingQue[frame][ID] = Out;
            }

            return ExistingQue[frame][ID];
        }
    }
}
