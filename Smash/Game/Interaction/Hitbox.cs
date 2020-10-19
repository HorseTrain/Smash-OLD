using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game.Fighter;
using Smash.Game.Physics.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Interaction
{
    public class Hitbox
    {
        public static List<Hitbox> AllHitBoxes { get; set; } = new List<Hitbox>();
        static List<Hitbox> termhitboxes { get; set; } = new List<Hitbox>();
        public CircleRenderer renderer { get; set; } = new CircleRenderer();

        public fighter fref;
        public TransformNode transform;

        public Vector2 Position { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

        float ExistanceTimer { get; set; } = 0;

        public T GetData<T>(string name) where T : unmanaged
        {
            if (Data.ContainsKey(name))
                return (T)Data[name];
            else
                return new T();
        }

        public static void UpdateAllHitboxes()
        {
            foreach (Hitbox hbox in AllHitBoxes)
            {
                hbox.UpdateHitbox();
            }

            foreach (Hitbox t in termhitboxes)
            {
                AllHitBoxes.Remove(t);
            }

            termhitboxes = new List<Hitbox>();
        }

        public void UpdateHitbox()
        {
            if (ExistanceTimer >= GetData<int>("ExistanceTimer") || fref.DestroyAllHitBoxes)
            {
                Destroy();
            }

            Fin();
        }

        public void Fin()
        {
            renderer.R = GetData<float>("Size");

            Position = (Matrix4.CreateTranslation(new Vector3(GetData<float>("X"), GetData<float>("Y"), GetData<float>("Z"))) * transform.WorldTransform).ExtractTranslation().Xy;

            ExistanceTimer += (float)Window.MainWindow.DeltaTime;

            renderer.Position = Position;
            renderer.Draw();
        }

        public void Destroy()
        {
            termhitboxes.Add(this);
        }

        public Hitbox()
        {
            AllHitBoxes.Add(this);
        }
    }
}
