using Smash.Game.Input;
using System.Collections.Generic;
using Smash.IO;
using System.IO;
using OpenTK;
using System;
using MoonSharp.Interpreter;
using OpenTK.Input;
using Smash.GraphicWrangler;
using Smash.Game.Interaction;

namespace Smash.Game.Fighter
{
    [MoonSharpUserData]
    public partial class fighter : SceneObject
    {
        public FighterInput Input { get; set; }
        public string Name { get; set; }

        bool setup = false;

        public int TurnMode = 1;

        public void SetUp()
        {
            if (!setup)
            {
                Input = new FighterInput(this);

                LoadScripts();

                phy = new Physics.SimplePhysics(this);

                setup = true;

                Animators[1].CrossFade("defaulteyelid");
            }
        }

        string GetSource(string name)
        {
            if (FileLoader.FileExists(@"custom\Scripts\" + Name + "\\" + name))
            {
                return FileLoader.ReadWholeFile(@"custom\Scripts\" + Name + "\\" + name);
            }

            return FileLoader.ReadWholeFile(@"custom\Scripts\fighter_main\" + name); ;
        }

        public void LoadScripts()
        {
            AnimationScripts = new Dictionary<string, ScriptObject>();

            string[] Files = FileLoader.GetFiles(@"custom\Scripts\fighter_main\Animation\");

            string FighterPeram = GetSource(@"fighter_parem.lua");
            string FighterGeneral = GetSource(@"fighter_general.lua") + "\n";            

            foreach (string file in Files)
            {
                string name = Path.GetFileName(file).Split('.')[0];

                string source = FileLoader.ReadWholeFile(file);

                AnimationScripts.Add(name,new ScriptObject(FighterPeram +"\n"+ FighterGeneral + "if (anim.CurrentAnimationName == \"" + name + "\") then\n" + source + "\nend"));
            }

            if (FileLoader.DirectoryExists(@"custom\Scripts\"+Name+@"\Animation\"))
            {
                Files = FileLoader.GetFiles(@"custom\Scripts\" + Name + @"\Animation\");

                foreach (string file in Files)
                {
                    string name = Path.GetFileName(file).Split('.')[0];

                    string source = FileLoader.ReadWholeFile(file);

                    if (AnimationScripts.ContainsKey(name))
                        AnimationScripts.Remove(name);

                    AnimationScripts.Add(name, new ScriptObject(FighterPeram + "\n" + FighterGeneral + "if (anim.CurrentAnimationName == \"" + name + "\") then\n" + source + "\nend"));
                }
            }
        }

        public Dictionary<string, ScriptObject> AnimationScripts { get; set; } 

        public override void Update()
        {
            SetUp();

            if (Input.KS.GetKeyPressed(Key.F1))
            {
                //LoadScripts();

                Gdir = 1;

                RootNode.LocalPosition = new Vector3();
                phy.Velocity = new Vector2(0);

                anim.CrossFade("wait1");
            }

            Input.Update();

            if (AnimationScripts.ContainsKey(anim.CurrentAnimationName))
            {
                AnimationScripts[anim.CurrentAnimationName].SetGlobal("fighter",this);

                AnimationScripts[anim.CurrentAnimationName].Run();
            }

            DamageMain();

            phy.Update();

            TurnCharecter();

            foreach (Animator a in Animators)
            {
                a.Update();
            }

            Draw();            
        }

        public void TurnCharecter()
        {
            skeleton.RootNode.LocalRotation = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(90));

            switch (TurnMode)
            {
                case 0: skeleton.RootNode.LocalRotation = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(90 * Gdir)); break;
                case 1: skeleton.RootNode.LocalScale = new Vector3(1,1,Gdir); break;
            }
        }

        public override void OnAnimationChange(Animator animator)
        {
            base.OnAnimationChange(animator);

            if (animator == Animators[0])
            {
                InAttack = false;

                HitboxQue = new Dictionary<Vector2, Interaction.Hitbox>();

                foreach (Hitbox hbox in MyHitboxes)
                    hbox.Destroy();

                MyHitboxes = new List<Hitbox>();
            }
        }
    }
}
