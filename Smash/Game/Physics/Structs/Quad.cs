using OpenTK;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics.Structs
{
    public class QuadIntersection
    {
        public Quad R0 { get; set; }
        public Quad R1 { get; set; }
        public List<LineIntersection2D> Intersections { get; set; } = new List<LineIntersection2D>();
        public bool Valid => Intersections.Count > 0;
    }

    public class QuadSceneIntersection
    {
        public List<Line2D> Intersections { get; set; } = new List<Line2D>();
        bool Valid => Intersections.Count != 0;
    }

    public class Quad
    {
        public GeomatryRenderer2D renderer { get; set; }

        float rotation;
        public float Rotation
        {
            get => rotation;

            set
            {
                Matrix4 rot = Matrix4.CreateFromQuaternion(Quaternion.FromAxisAngle(new Vector3(0,0,1),MathHelper.DegreesToRadians(rotation)));

                tLineXN = LineXN * rot;
                tLineXP = LineXP * rot;
                tLineYN = LineYN * rot;
                tLineYP = LineYP * rot;

                rotation = value;
            }
        }

        public Vector2 Position { get; set; }

        Line2D LineXN;
        Line2D LineXP;
        Line2D LineYN;
        Line2D LineYP;

        Line2D tLineXN;
        Line2D tLineXP;
        Line2D tLineYN;
        Line2D tLineYP;

        public List<Line2D> LineList => new List<Line2D>(new Line2D[] { tLineXN + Position, tLineXP + Position, tLineYN + Position, tLineYP + Position });

        public static Quad CreateRectangle(Vector2 offset,float width, float height,float rot,Vector2 pos) //Rectangle lmao
        {
            Quad Out = new Quad();

            Out.LineXN = new Line2D(new Vector2(0,0),new Vector2(width,0));
            Out.LineXP = new Line2D(new Vector2(width, 0), new Vector2(width, height));
            Out.LineYN = new Line2D(new Vector2(width,height), new Vector2(0, height));
            Out.LineYP = new Line2D(new Vector2(0, height), new Vector2(0, 0));

            offset *= -1;

            Out.LineXN += offset;
            Out.LineXP += offset;
            Out.LineYN += offset;
            Out.LineYP += offset;

            Out.Rotation = rot;
            Out.Position = pos;

            Out.renderer = new GeomatryRenderer2D();
            Out.renderer.BuildMesh(new List<Line2D>(new Line2D[] { Out.LineXN, Out.LineXP, Out.LineYN, Out.LineYP }));

            return Out;
        }

        public static Quad CreateDiamond(Vector2 offset, float width, float height, float rot, Vector2 pos)
        {
            Quad Out = new Quad();

            Matrix4 tran = Matrix4.CreateScale(new Vector3(width,height,1)/2);

            Out.LineXN = new Line2D(new Vector2(-0.5f,0.5f),new Vector2(0,1)) * tran;
            Out.LineXP = new Line2D(new Vector2(0,1),new Vector2(0.5f,0.5f)) * tran;

            Out.LineYN = new Line2D(new Vector2(0,0),new Vector2(-0.5f,0.5f)) * tran;
            Out.LineYP = new Line2D(new Vector2(0.5f,0.5f),new Vector2(0,0)) * tran;

            offset *= -1;

            Out.LineXN += offset;
            Out.LineXP += offset;
            Out.LineYN += offset;
            Out.LineYP += offset;

            Out.Rotation = rot;
            Out.Position = pos;

            Out.renderer = new GeomatryRenderer2D();
            Out.renderer.BuildMesh(new List<Line2D>(new Line2D[] { Out.LineXN, Out.LineXP, Out.LineYN, Out.LineYP }));

            return Out;
        }

        public static Quad FromPoints(Vector2 p0,Vector2 p1, Vector2 p2,Vector2 p3)
        {
            Quad Out = new Quad();

            Out.LineXN = new Line2D(p0,p1);
            Out.LineXP = new Line2D(p1, p2);

            Out.LineYN = new Line2D(p2, p3);
            Out.LineYP = new Line2D(p3, p0);

            Out.Rotation = 0;
            Out.Position = new Vector2(0,0);

            Out.renderer = new GeomatryRenderer2D();
            Out.renderer.BuildMesh(new List<Line2D>(new Line2D[] { Out.LineXN, Out.LineXP, Out.LineYN, Out.LineYP }));

            return Out;
        }

        public void Draw()
        {
            renderer.Rotation = Rotation;
            renderer.Position = Position;

            renderer.Draw();
        }
    }
}
