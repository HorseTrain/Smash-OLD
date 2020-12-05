using OpenTK;
using OpenTK.Graphics.OpenGL;
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

    public class Hitbox 
    {
        public Circle2D Renderer = new Circle2D();

        public Dictionary<string, object> Data = new Dictionary<string, object>();

        public Matrix4 LocalTransform => Matrix4.CreateScale(GetFloat("size")) * Matrix4.CreateTranslation(GetFloat("x"), GetFloat("y"), GetFloat("z"));
        public Vector3 Position => (LocalTransform * Object.skeleton.GetNode(GetString("bone")).WorldTransform).ExtractTranslation();

        public int Layer;

        public Hitbox()
        {
            hitboxque.Add(this);
        }

        float endtime = 0;

        SceneObject Obj;
        public SceneObject Object { get => Obj; set { Obj = value; Obj.MyHitboxes.Add(this); } }

        public int GetInt(string name)
        {
            if (Data.ContainsKey(name))
                return (int)(double)Data[name];
            else
                return 0;
        }

        public float GetFloat(string name)
        {
            if (Data.ContainsKey(name))
                return (float)(double)Data[name];
            else
                return 0;
        }

        public string GetString(string name)
        {
            if (Data.ContainsKey(name))
                return (string)Data[name];
            else
                return "";
        }

        public void Update()
        {
            if (!Data.ContainsKey("bone"))
                Data.Add("bone","Trans");

            endtime += Object.FinalSpeed * Object.anim.AnimationSpeed;

            Renderer.R = GetFloat("size");

            Renderer.Position = Position.Xy;

            if (endtime >= GetInt("endtime"))
            {
                Destroy();
            }
            else
            {
                TestFighterCollision();

                Renderer.Draw();
            }
        }

        public void Destroy()
        {
            destructionque.Add(this);
        }

        List<fighter> HitQue = new List<fighter>();

        public void TestFighterCollision()
        {
            foreach (fighter fter in ((ArenaScene)Scene.CurrentScene).Fighters)
            {
                if (fter != Object)
                {
                    if (!HitQue.Contains(fter))
                    {
                        if (Renderer.TestCollision(fter.phy.CollisionCapsule))
                        {
                            fter.Hit(this);
                        }

                        HitQue.Add(fter);
                    }
                }
            }
        }

        static List<Hitbox> hitboxque = new List<Hitbox>();
        static List<Hitbox> destructionque = new List<Hitbox>();
        public static void UpdateAllHitBoxes()
        {
            foreach (Hitbox hitbox in hitboxque)
            {
                hitbox.Update();
            }

            foreach (Hitbox hitbox in destructionque)
            {
                hitboxque.Remove(hitbox);
            }

            destructionque = new List<Hitbox>();
        }
    }
}
