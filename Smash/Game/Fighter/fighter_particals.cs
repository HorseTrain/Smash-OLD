using Smash.Game.Fighter.Particals;
using Smash.GraphicWrangler;
using OpenTK;
using System;
using Smash.Game.Physics.Shapes;

namespace Smash.Game.Fighter
{
    public partial class fighter
    {
        public ParticalRenderer Kill0 = new ParticalRenderer();
        public ParticalRenderer Kill1 = new ParticalRenderer();
        public ParticalRenderer DamageFlyP = new ParticalRenderer();
        public ParticalRenderer GroundParticals = new ParticalRenderer();

        public void CreateKillParticals()
        {
            for (int i = 0; i < 1024; i++)
            {
                CircleTravelPartical temp = new CircleTravelPartical();

                temp.Set(skeleton.RootNode.LocalPosition);

                Kill0.AddObject(temp);
            }

            for (int i = 0; i < 1024; i++)
            {
                MoveDirPartical temp = new MoveDirPartical();

               // Vector2 na = GetDirection(MathHelper.DegreesToRadians(Scene.RandomFloat(-20, 20)));

                Vector3 Normal = new Vector3(phy.Velocity.X,phy.Velocity.Y,0).Normalized();

                temp.Set(skeleton.RootNode.LocalPosition + (-new Vector3(-Normal.Y,Normal.X,0) * Scene.RandomFloat(-50,50)), -Normal);

                Kill1.AddObject(temp);

              
            }
        }

        public void UpdateParticals()
        {
            Kill0.Draw();
            Kill1.Draw();

            if (InDamageFly)
            {
                DamageFlyParticals();
            }
            else
            {
                LastDF = skeleton.RootNode.LocalPosition;
            }

            RunParticalHandler();

            DamageFlyP.Draw();
            GroundParticals.Draw();
        }

        Vector3 LastDF;

        float ctimer = 1;

        public void DamageFlyParticals()
        {
            ctimer -= FinalSpeed;

            if (ctimer < 0)
            {
                float Distance = (skeleton.RootNode.LocalPosition - LastDF).Length;

                Vector3 normal = (skeleton.RootNode.LocalPosition - LastDF).Normalized();

                for (int i = 0; i < Distance; i++)
                {
                    DamageFlyPartical temp = new DamageFlyPartical();

                    temp.SetUp(LastDF + (normal * i),this);

                    DamageFlyP.AddObject(temp);
                }

                LastDF = skeleton.RootNode.LocalPosition;

                ctimer = 1;
            }
        }

        public Vector3 LastRunPosition;

        float runpartdis = 0.8f;

        bool GenerateGroundParticals => (anim.CurrentAnimationName.Contains("dash") && anim.CurrentKey < 5) ||
            (((Math.Abs(skeleton.GetNode("ToeR").WorldPosition.Y - RootNode.LocalPosition.Y) < runpartdis) || (Math.Abs(skeleton.GetNode("ToeL").WorldPosition.Y - RootNode.LocalPosition.Y) < runpartdis)) && anim.CurrentAnimationName == "run") ||
            anim.CurrentAnimationName == "turnrun" ||
            (anim.CurrentAnimationName.Contains("runbrake") && Math.Abs(phy.Velocity.X) > 1)
            ;

        public void RunParticalHandler()
        {
            if (GenerateGroundParticals)
            {
                ctimer -= FinalSpeed;

                if (ctimer < 0)
                {
                    float Distance = (skeleton.RootNode.LocalPosition - LastRunPosition).Length;

                    Vector3 normal = (skeleton.RootNode.LocalPosition - LastRunPosition).Normalized();

                    for (int i = 0; i < 5; i++)
                    {
                        RunPartical temp = new RunPartical();

                        temp.Set(this);

                        GroundParticals.AddObject(temp);
                    }

                    LastRunPosition = RootNode.LocalPosition;

                    ctimer = 1;
                }
            }
            else
            {
                LastRunPosition = RootNode.LocalPosition;
            }
        }

        public void LandJumpParticals()
        {
            for (int i = 0; i < 10; i++)
            {
                JumpPartical temp = new JumpPartical();

                if (i - 5 != 0)
                {
                    temp.Set(RootNode.LocalPosition + new Vector3(i - 5, 1, 0), this);

                    GroundParticals.AddObject(temp);
                }
            }
        }
    }
}
