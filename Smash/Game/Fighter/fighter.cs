using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO.XML;
using Smash.Game.Input;
using Smash.Game.Physics;
using Smash.Game.Scenes;
using Smash.GraphicWrangler;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smash.IO;
using SimpleGameEngine.IO.Collada.Scene;
using SimpleGameEngine.Graphics;

namespace Smash.Game.Fighter
{
    public partial class fighter : SceneObject //Main Fighter 
    {
        public List<float> ItemAffectSpeed { get; set; } = new List<float>();
        public float Damage { get; set; } = 0;
        public int Gdir { get; set; } = 1;
        public SimplePhysics phy { get; set; }
        public FighterInput input { get; set; }
        public FighterParam Peram { get; set; } 
        public int FighterIndex { get; set; }
        public Ledge HeldLedge { get; set; }
        public bool HoldingLedge => HeldLedge != null;
        public XMLFile peramfile { get; set; }
        public bool Caught { get; set; }
        public TransformNode RootNode => skeleton.RootNode;
        public FighterScreenData FighterData { get; set; }
        public float Weight = 98;

        public bool AccountCamera;
        public float FinalSpeed
        {
            get
            {
                float Out = ArenaScene.GLobalSpeed * GeneralSpeed;

                foreach (float f in ItemAffectSpeed)
                {
                    Out *= f;
                }

                return Out;
            }
        }

        int cc = 1;

        public override void Update()
        {
            if (!MaterialTesting && !Dead)
            {
                if (!setup)
                    SetUp();

                input.Update();

                phy.Update();

                if (!InHitStun && !Caught)
                {
                    FighterGeneral();

                    FighterCollision();
                }

                RunAnimationPerams();

                DamageMain();

                AttackMain();

                if (!Dead)
                {
                    DrawFighter();
                }

                FighterData.Update();
            }

            anim.AnimationChange = false;

            UpdateParticals();

            AccountCamera = true;

            DeathHandeling();
        }

        public void DeathHandeling()
        {
            if (Dead)
            {
                RespawnTime -= FinalSpeed;

                skeleton.RootNode.LocalPosition = new OpenTK.Vector3(0, 100, 0);

                AccountCamera = false;
            }
        }

        public void FighterCollision()
        {
            ArenaScene arenaScene = (ArenaScene)Scene.CurrentScene;

            foreach (fighter f in arenaScene.Fighters)
            {
                if (f != this && f.setup)
                {
                    if (f.phy.CollisionCapsule.TestCollision(phy.CollisionCapsule))
                    {
                        if (f.phy.Transform.LocalPosition.X < phy.Transform.LocalPosition.X)
                        {
                            //phy.MoveX(0.1f,2);
                        }
                        else
                        {
                            //phy.MoveX(-0.1f, 2);
                        }
                    }
                }
            }
        }

        bool setup = false;
        public virtual void SetUp()
        {
            if (Peram == null)
            Peram = new FighterParam();

            phy = new SimplePhysics(skeleton.RootNode,Peram);

            phy.FighterRef = this;

            setup = true;

            input = new FighterInput(this);

            Jumps = Peram.JumpCount;

            foreach (Animator anim in Animators)
            {
                anim.fighterref = this;
            }

            phy.CollisionCapsule = new Physics.Shapes.Capsule2D(10,20);

            FighterData = new FighterScreenData(this);
        }

        public void LoadPerams()
        {

        }

        float CameraLock;

        float RespawnTime;

        public bool Dead => RespawnTime > 0;

        public void Kill()
        {
            CreateKillParticals();

            RespawnTime = 200;

            InDamageFly = false;
            skeleton.RootNode.LocalPosition = new OpenTK.Vector3(0,100,0);
            Damage = 0;
            phy.Velocity = new OpenTK.Vector2(0,0);
            InHitStun = false;
        }
    }
}
