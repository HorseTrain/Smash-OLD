using OpenTK;
using SimpleGameEngine.Graphics;
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
        public bool InDamageFly;
        public float DamageFlyDrag = 5;

        public Dictionary<Vector2, Hitbox> HitboxQue { get; set; } = new Dictionary<Vector2, Hitbox>();

        public float HitLag;
        public bool InHitLag => HitLag > 0;

        public float GetDistance(float BKB, float Mult)
        {
            return BKB + (Damage * Mult);
        }

        public void DamageMain()
        {
            if (InHitLag)
            {
                InHitStun = true;

                GeneralSpeed = 0;
                hit.Object.GeneralSpeed = 0;

                HitLag -= Window.MainWindow.GlobalDeltaTime;

                InDamageFly = false;

                if (!InHitLag)
                {
                    GeneralSpeed = 1;
                    hit.Object.GeneralSpeed = 1;

                    Vector2 velocity = (hit.Position.Xy - RootNode.LocalPosition.Xy) / 10;

                    float distance = GetDistance(hit.GetFloat("bkb"), hit.GetFloat("kbm"));

                    if (distance < 5)
                    {
                        phy.Velocity.X = velocity.X;

                        if (!hit.Object.phy.Grounded)
                        {
                            phy.Velocity.Y = velocity.Y;
                        }
                    }
                    else
                    {
                        Launch(hit.GetFloat("angle"), distance);
                    }
                }
            }

            if (InDamageFly)
            {
                DamageFly();
            }
        }

        public void Launch(float angle, float distance)
        {
            Vector2 vel = GetAngleVector(angle);

            vel.X *= hit.Object.Gdir;

            if (GetAngle(vel,Vector2.UnitY) < 10)
            {
                int rand = GetRandomInt(0,3);

                switch (rand)
                {
                    case 0: anim.CrossFade("damageflytop"); break;
                    case 1: anim.CrossFade("damageflyhi"); break;
                    case 2: anim.CrossFade("damageflyroll"); break;
                }
            }
            else
            {
                int rand = GetRandomInt(0, 2);

                switch (rand)
                {
                    case 0: anim.CrossFade("damageflyn"); break;
                    case 1: anim.CrossFade("damageflyroll"); break;
                }
            }

            phy.Velocity = (vel * distance) / DamageFlyDrag;

            Console.WriteLine(phy.Velocity);

            InDamageFly = true;
        }

        public bool DamageFlyEnd
        {
            get
            { 
                bool Out = phy.Velocity.Length < (1f / (DamageFlyDrag * 0.2f));

                if (Out)
                {
                    InDamageFly = false;
                }

                return Out;
            }
        }

        public void DamageFly()
        {
            InHitStun = true;

            phy.DoGravity = false;

            phy.Velocity += (Vector2.Zero - phy.Velocity) / (DamageFlyDrag / FinalSpeed);

            switch (anim.CurrentAnimationName)
            {
                case "damageflyn": anim.PauseInAnimation(15); break;
                case "damageflytop": anim.PauseInAnimation(10); break;
                case "damageflyhi": anim.PauseInAnimation(10); break;
                case "damageflyroll": if (DamageFlyEnd) anim.CrossFade("damageflyrollend",100); break;
            }

            if (DamageFlyEnd)
            {

            }
        }

        public Vector2 GetAngleVector(float angle)
        {
            angle = MathHelper.DegreesToRadians(angle);

            return new Vector2((float)Math.Sin(angle),(float)Math.Cos(angle));
        }

        public float GetAngle(Vector2 v0, Vector2 v1)
        {
            return (float)MathHelper.RadiansToDegrees(Math.Acos(Vector2.Dot(v0,v1)));
        }

        public void CreateHitBox(int frame, Dictionary<string,object> Data,int ID = 0,int Layer = -1)
        {
            if (anim.CurrentKeyIndex == frame)
            {
                if (!HitboxQue.ContainsKey(new Vector2(frame,ID)))
                {
                    if (Layer == -1)
                        Layer = ID;

                    HitboxQue.Add(new Vector2(frame,ID),CreateHitbox(Data,Layer));
                }
            }
        }

        public Hitbox CreateHitbox(Dictionary<string, object> Data,int layer)
        {
            return new Hitbox()
            {
                Object = this,
                Data = Data,
                Layer = layer
            };
        }

        public Hitbox hit;

        public void Hit(Hitbox hitbox)
        {
            this.hit = hitbox;

            HitLag = hitbox.GetInt("hitlag");

            if (HitLag == 0)
                HitLag = 1;

            if (phy.Grounded)
            {
                anim.CrossFade("damagen" + GetRandomInt(1,4));
            }
            else
            {
                anim.CrossFade("damageair" + GetRandomInt(1, 4));
            }
        }
    }
}
