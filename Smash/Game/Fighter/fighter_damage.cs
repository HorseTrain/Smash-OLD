using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.IO.Collada.Scene;
using Smash.Game.Input;
using Smash.Game.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public enum LaunchMajor
    {
        MajorX,
        MajorY
    }

    public partial class fighter 
    {
        public static float DamageFlyDrag = 5;
        public bool InHitStun { get; private set; }
        public bool InDamageFly { get; set; }
        public Vector2 LaunchPosition { get; private set; }
        public float LaunchDistance { get; private set; }
        public float LaunchHeight { get; private set; }
        public float WantedLaunchDistance { get; private set; }
        public LaunchMajor launchMajor { get; set; }
        public Vector2 FlightPathPlugIn;
        float lp { get; set; }
        public int LaunchDir;

        public float HitLag { get; set; }
        public bool InHitLag => HitLag > 0;

        bool Grabbed = false;

        public Hitbox hit;
        Vector2 Point;

        public fighter CFighter;

        public static float GetDamageDistance(float Base)
        {
            return Base;
        }

        public static float FixAngle(float a)
        {
            if (a == 0)
                return 0.001f;

            return a;
        }

        public void Hit(Hitbox hit)
        {
            this.hit = hit;

            if (hit.Type == HitboxType.Attack)
            {
                HitLag = hit.GetObject<int>("HitLag");

                if (HitLag == 0)
                    HitLag = 1;

                Point = skeleton.RootNode.LocalPosition.Xy;

                if (phy.Grounded)
                {
                    anim.CrossFade("damagen" + FighterRNG.Next(1, 4));
                }
                else
                {
                    anim.CrossFade("damageair" + FighterRNG.Next(1, 4));
                }

                hit.fRef.GeneralSpeed = 0;
            }
            else
            {
                Grabbed = true;

                CFighter = hit.fRef;
            }
        }

        public virtual void DamageMain()
        {
            if (InHitLag)
            {
                HitLag -= FinalSpeed;

                Vector3 temp = new Vector3(Point + new Vector2(FighterRNG.Next(-10,10)/10.0f, FighterRNG.Next(-10, 10) / 10.0f));

                phy.Transform.LocalPosition = new Vector3(temp.X,phy.Transform.LocalPosition.Y, 0);

                if (!phy.Grounded)
                    phy.Transform.LocalPosition = new Vector3(phy.Transform.LocalPosition.X,temp.Y,0);

                anim.CurrentKey = 2;

                InHitStun = true;

                if (HitLag < 0)
                {
                    skeleton.RootNode.LocalPosition = new Vector3(Point);

                    float distance = GetDamageDistance(hit.GetObject<float>("KB"));

                    if (distance < 5)
                    {
                        InHitStun = false;

                        Vector2 attract = hit.Position - phy.Transform.LocalPosition.Xy;

                        phy.Velocity.Y = 0;

                        phy.MoveX(attract.X, 2);

                        if (!hit.fRef.phy.Grounded)
                        phy.MoveY(attract.Y, 2);
                    }
                    else
                    {
                        Launch(hit.GetObject<float>("Angle"), distance);
                    }

                    hit.fRef.GeneralSpeed = 1;
                }
            }

            if (InDamageFly)
            {
                DamageFlySlow();
            }
        }

        public void Launch(float angle, float distance)
        {
            if (angle == 0)
                angle += 0.001f;

            Vector2 vel = GetDirection(MathHelper.DegreesToRadians(angle));
            vel.X *= hit.fRef.Gdir;

            if (Math.Abs(vel.X) > 0.5f)
            {
                int ranim = FighterRNG.Next(0, 2);

                switch (ranim)
                {
                    case 0: anim.CrossFade("damageflyn"); break;
                    case 1: anim.CrossFade("damageflyroll"); break;
                }
            }
            else
            {
                if (vel.Y > 0)
                {
                    anim.CrossFade("damageflytop");
                }
            }

            InDamageFly = true;

            if (Math.Abs(FlightPathPlugIn.X) > Math.Abs(FlightPathPlugIn.Y))
                launchMajor = LaunchMajor.MajorX;
            else
                launchMajor = LaunchMajor.MajorY;

            vel *= (distance / DamageFlyDrag);

            phy.Velocity = vel;
        }

        public Vector2 GetDirection(float angle)
        {
            return new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }

        public static float FlightPathPosition(float i,Vector2 FlightPathPlugIn)
        {
            return (float)Math.Sin((1/FlightPathPlugIn.X) * (.5f) * (i * Math.PI)) * FlightPathPlugIn.Y;
        }

        public Vector3 GetLaunchPosition(float i)
        {
            return (new Vector3(LaunchPosition) + new Vector3(i * LaunchDir, FlightPathPosition(i, FlightPathPlugIn), 0));
        }

        public bool DoneDamageFly => (launchMajor == LaunchMajor.MajorX && Math.Abs(phy.Velocity.X) < 0.5f) || (launchMajor == LaunchMajor.MajorY && Math.Abs(phy.Velocity.Y) < 0.5f);

        public void DamageFlySlow()
        {
            phy.DoGravity = false;

            phy.Velocity += (Vector2.Zero - phy.Velocity) / (DamageFlyDrag / FinalSpeed);

            switch (anim.CurrentAnimationName)
            {
                case "damageflyroll": DamageFlyTurn(phy.Velocity); break;
                case "damageflyn": anim.PauseInAnimation(15); break;
            }

            if (DoneDamageFly)
            {
                if (anim.CurrentAnimationName == "damageflyroll")
                {
                    anim.CrossFade("damageflyrollend",20);
                }

                InDamageFly = false;
                InHitStun = false;
            }
        }

        public void DamageFlyTurn(Vector2 dis, float offset = 0)
        {
            float angle = (float)Math.Acos(Vector2.Dot(Vector2.UnitY,dis.Normalized())) + MathHelper.RadiansToDegrees(offset);

            skeleton.GetNode("Rot").LocalRotation = Quaternion.FromAxisAngle(new Vector3(1,0,0),angle * FighterInput.GetDir(dis.X) * Gdir);

            anim.OverrideNode("Rot");
        }
    }
}
