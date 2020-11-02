using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game.Fighter;
using Smash.Game.Physics.Shapes;
using Smash.Game.Physics.Structs;
using Smash.Game.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Interaction
{
    public enum HitboxType
    {
        Attack,
        Grab
    }

    public class Hitbox : Circle2D
    {
        public static List<Hitbox> AllHitBoxes = new List<Hitbox>();
        static List<Hitbox> DestructionQue = new List<Hitbox>();

        public Dictionary<string, object> Data = new Dictionary<string, object>();

        public static bool DebugDrawHitBoxes = true;

        public List<fighter> HitQue = new List<fighter>();

        public float EndTime { get; set; }
        public fighter fRef { get; set; }
        public HitboxType Type;
        public int Layer;

        public Hitbox()
        {
            AllHitBoxes.Add(this);
        }

        public void SetUp(HitboxType Type = HitboxType.Attack, int layer = 0)
        {
            EndTime = GetObject<int>("EndTime");
            R = GetObject<float>("Size");
            this.Layer = layer;
            this.Type = Type;
        }

        public T GetObject<T>(string name)
        {
            if (Data.ContainsKey(name))
                return (T)Data[name];
            else
                return default;
        }

        public void Update()
        {
            Matrix4 temp = Matrix4.CreateTranslation(new Vector3(GetObject<float>("X"), GetObject<float>("Y"), GetObject<float>("Z"))) * fRef.skeleton.GetNode(GetObject<string>("Bone")).WorldTransform;

            Position = temp.ExtractTranslation().Xy;

            EndTime -= fRef.FinalSpeed;

            if (fRef.DestroyAllHitBoxes || EndTime < 0)
            {
                Destroy();
            }
            else
            {
                CollisionTest();
            }

            if (DebugDrawHitBoxes)
            {
                Draw();
            }
        }

        public void Destroy()
        {
            DestructionQue.Add(this);
        }

        public void CollisionTest()
        {
            foreach (fighter f in ((ArenaScene)Scene.CurrentScene).Fighters)
            {
                if (f != fRef)
                {
                    bool CanComplete = true;

                    if (Layer != -1)
                    {
                        if (fRef.FighterHitExclusion[Layer].Contains(f))
                            CanComplete = false;
                    }

                    if (CanComplete)
                    {
                        if (TestCollision(f.phy.CollisionCapsule))
                        {
                            if (!HitQue.Contains(f))
                            {
                                HitQue.Add(f);

                                f.Hit(this);

                                Console.WriteLine(Layer);

                                if (Layer != -1)
                                {
                                    fRef.FighterHitExclusion[Layer].Add(f);
                                }
                            }
                        }
                        else
                        {
                            if (HitQue.Contains(f))
                            {
                                //HitQue.Remove(f);
                            }
                        }
                    }
                }
            }
        }

        public static void UpdateAllHitBoxes()
        {
            foreach (Hitbox hitbox in AllHitBoxes)
            {
                hitbox.Update();
            }

            foreach (Hitbox hb in DestructionQue)
            {
                AllHitBoxes.Remove(hb);
            }

            DestructionQue = new List<Hitbox>();
        }
    }
}
