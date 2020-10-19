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

namespace Smash.Game.Fighter
{
    public partial class fighter : SceneObject //Main Fighter 
    {
        public List<float> ItemAffectSpeed { get; set; } = new List<float>();
        public int Gdir { get; set; } = 1;
        public SimplePhysics phy { get; set; }
        public FighterInput input { get; set; }
        public FighterParam Peram { get; set; } 
        public int FighterIndex { get; set; }
        public Ledge HeldLedge { get; set; }
        public bool HoldingLedge => HeldLedge != null;
        public XMLFile peramfile { get; set; }
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

        public override void Update()
        {
            if (!MaterialTesting)
            {
                if (!setup)
                    SetUp();

                input.Update();

                phy.Update();

                if (!InHitStun)
                {
                    FighterGeneral();
                }

                RunAnimationPerams();

                DamageMain();

                AttackMain();
            }

            DrawFighter();

            anim.AnimationChange = false;
        }

        bool setup = false;
        public void SetUp()
        {
            LoadPerams();
            Peram = new FighterParam();

            phy = new SimplePhysics(skeleton.RootNode,Peram);

            setup = true;

            input = new FighterInput(this);

            Jumps = Peram.JumpCount;

            foreach (Animator anim in Animators)
            {
                anim.fighterref = this;
            }
        }

        public void LoadPerams()
        {

        }
    }
}
