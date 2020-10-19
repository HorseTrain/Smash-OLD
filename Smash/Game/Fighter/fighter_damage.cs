using OpenTK;
using SimpleGameEngine.Graphics;
using Smash.Game.Input;
using Smash.Game.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static float DamageFlyDrag = 10;
        public bool InHitStun { get; private set; }
        public bool InDamageFly { get; set; }
        public Vector2 LaunchPosition { get; private set; }
        public float LaunchDistance { get; private set; }
        public float LaunchHeight { get; private set; }
        public float WantedLaunchDistance { get; private set; }
        float lp { get; set; }

        public virtual void DamageMain()
        {
            if (input.KS.GetKeyPressed(OpenTK.Input.Key.Space) && FighterIndex == 0)
            {
                Launch(FighterRNG.Next(1,80),100);
            }

            if (InDamageFly)
            {
                DamageFlySlow();
            }
        }
        
        public LaunchMajor launchMajor { get; set; }

        public void Launch(float angle, float distance)
        {
            Vector2 vel = GetDirection(MathHelper.DegreesToRadians(angle));
            vel.X *= Gdir;

            int Dir = FighterInput.GetDir(vel.X);

            if (angle == 0)
                angle += 0.001f;

            if (Math.Abs(vel.X) > 0.4f)
            {
                if (Gdir == -Dir)
                {
                    anim.CrossFade("damageflyn", 0, true);
                }
                else
                {
                    switch (FighterRNG.Next(0, 2))
                    {
                        case 0: anim.CrossFade("damageflyroll", 0, true); break;
                        case 1: anim.CrossFade("damageflymeteor", 0, true); break;
                    }
                }
            }
            else
            {
                switch (FighterRNG.Next(0, 2))
                {
                    case 0: anim.CrossFade("damageflytop",0,true); break;
                    case 1: anim.CrossFade("damageflymeteor", 0, true); break;
                }              
            }

            if (Math.Abs(vel.X) > Math.Abs(vel.Y))
                launchMajor = LaunchMajor.MajorX;
            else
                launchMajor = LaunchMajor.MajorY;

            LaunchPosition = skeleton.RootNode.LocalPosition.Xy;

            WantedLaunchDistance = distance;

            Vector2 direction = GetDirection(MathHelper.DegreesToRadians(angle)) * distance;
            direction.X *= 2 * Gdir;

            LaunchDistance = direction.X;
            LaunchHeight = direction.Y;
          
            lp = 0;

            InDamageFly = true;
            InHitStun = true;
        }

        public Vector2 GetDirection(float angle)
        {
            return new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
        }

        public void DamageFlySlow()
        {
            lp += ((LaunchDistance/2) - lp) / (DamageFlyDrag / (float)Window.MainWindow.DeltaTime);

            Vector2 DesiredPosition = new Vector3(LaunchPosition.X + lp, LaunchPosition.Y + SmashMath.TrajectoryParabola(lp, LaunchDistance, LaunchHeight), 0).Xy;

            phy.Velocity = DesiredPosition - skeleton.RootNode.LocalPosition.Xy;

            phy.DoGravity = false;

            if (lp / (LaunchDistance / 2) > 1 - (1/(DamageFlyDrag)))
            {
                InDamageFly = false;
                InHitStun = false;

                switch (anim.CurrentAnimationName)
                {
                    case "damageflytop": anim.CrossFade("damagefall",100); break;
                    case "damageflyn": anim.CrossFade("damagefall",100); break;
                    case "damageflyroll": anim.CrossFade("damageflyrollend",100); break;
                    case "damageflymeteor": anim.CrossFade("damagefall",100); break;
                }
            }
            else
            {
                switch (anim.CurrentAnimationName)
                {
                    case "damageflyroll": DamageFlyTurn(); break;
                    case "damageflymeteor": DamageFlyTurn(); break;
                }
            }
        }

        public void DamageFlyTurn(float offset = 0)
        {
            float angle = (float)Math.Acos(Vector2.Dot(Vector2.UnitY,phy.Velocity / phy.Velocity.Length));

            skeleton.GetNode("Rot").LocalRotation = Quaternion.FromAxisAngle(new Vector3(1,0,0),angle * FighterInput.GetDir(phy.Velocity.X) * Gdir);

            anim.OverrideNode("Rot");
        }
    }
}
