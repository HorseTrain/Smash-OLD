using OpenTK;
using SimpleGameEngine.Graphics;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.Graphics.Structs;
using Smash.Game.Fighter;
using Smash.Game.Physics.Structs;
using Smash.Game.Scenes;
using Smash.GraphicWrangler;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics
{
    public class SimplePhysics
    {
        public static List<Line2D> SceneGeomatry { get; set; } = new List<Line2D>();

        public SimplePhysics(TransformNode transform,FighterParam peram)
        {
            Transform = transform;

            FallSpeed = peram.FallSpeed;
            TerminalVelocity = peram.TermenalVelocity;
        }

        public TransformNode Transform { get; set; }

        public Vector2 Velocity;
        public float FallSpeed { get; set; } = 0.081f;
        public float TerminalVelocity { get; set; } = 3;
        public bool Grounded { get; private set; }
        public bool DoGravity { get; set; }
        public bool LeftRightCollision { get; set; }
        public bool TopDownCollision { get; set; }
        public bool HitSide { get; set; }
        public bool HitTop { get; set; }
        public bool HitDown { get; set; }

        public float ECBWidth { get; set; } = 10;
        public float ECBHeight { get; set; } = 15;

        public bool GroundStateChange { get; private set; }
        bool lg;

        Quad ECB { get; set; }
        List<Line2D> ECBLineList { get; set; }

        public virtual void Update()
        {
            if (DoGravity)
            Gravity();

            DoGravity = true;
            
            Collision();

            Init();

            //ECB.Draw();
        }

        public virtual void Gravity()
        {
            Velocity.Y -= FallSpeed * ArenaScene.GLobalSpeed;

            if (Velocity.Y <= -TerminalVelocity)
            {
                Velocity.Y = -TerminalVelocity;
            }
        }

        public void Collision()
        {
            HitTop = false;
            HitSide = false;
            HuggingLedge = false;

            if (TopDownCollision)
            {
                GroundCollision();

                TopCollision();
            }

            if (LeftRightCollision)
            {
                LeftRightCollisionTest();
            }

            TopDownCollision = true;
            LeftRightCollision = true;
        }

        public void GroundCollision()
        {
            LineIntersection2D groundtest = GlobalIntersectionTest(new Line2D(Transform.LocalPosition.Xy + new Vector2(0, ECBHeight / 2),Transform.LocalPosition.Xy + new Vector2(0,Velocity.Y)));

            Grounded = false;

            if (groundtest.Valid)
            {
                if (Velocity.Y <= 0 && groundtest.Line0.Angle < 45)
                {
                    Grounded = true;
                    Velocity.Y = 0;
                    Transform.LocalPosition = new Vector3(groundtest.IntersectionPoint.X, groundtest.IntersectionPoint.Y, 0);

                    float slopehop = -groundtest.Line0.Normal.X * Velocity.X;

                    if (slopehop < 0)
                    Transform.LocalPosition += new Vector3(0,slopehop,0);

                    LineIntersection2D hugtest = GlobalIntersectionTest(new Line2D(Transform.LocalPosition.Xy + new Vector2(Velocity.X,1),Transform.LocalPosition.Xy + new Vector2(Velocity.X,-0.1f)));

                    HuggingLedge = !hugtest.Valid;
                }
            }

            GroundStateChange = lg != Grounded;

            if (GroundStateChange && Velocity.Y <= 0)
            {
                SnapToGround(1);
            }

            lg = Grounded;
        }

        public void TopCollision()
        {
            LineIntersection2D toptest = GlobalIntersectionTest(new Line2D(Transform.LocalPosition.Xy + new Vector2(0, ECBHeight / 2), Transform.LocalPosition.Xy + new Vector2(0, ECBHeight + Velocity.Y)));

            if (toptest.Valid)
            {
                if (Velocity.Y > 0 && toptest.Line0.Angle > 135 && Transform.LocalPosition.Y <= toptest.IntersectionPoint.Y - ECBHeight)
                {
                    Velocity.Y = 0;
                    Transform.LocalPosition = new Vector3(toptest.IntersectionPoint.X,toptest.IntersectionPoint.Y - ECBHeight,0);


                    HitTop = true;
                }
            }
        }

        public void SnapToGround(float tol = 0)
        {
            LineIntersection2D groundtest = GlobalIntersectionTest(new Line2D(Transform.LocalPosition.Xy + new Vector2(0, ECBHeight / 2), Transform.LocalPosition.Xy + new Vector2(0, -tol)));

            if (groundtest.Valid)
            {
                Transform.LocalPosition = new Vector3(groundtest.IntersectionPoint.X, groundtest.IntersectionPoint.Y, 0);
                Velocity.Y = 0;
                Grounded = true;
            }
        }

        public void LeftRightCollisionTest()
        {
            {
                List<LineIntersection2D> lefttests = GlobalAllIntersectionTest(new Line2D(Transform.LocalPosition.Xy + new Vector2(0, 0.1f), Transform.LocalPosition.Xy + new Vector2(-ECBWidth / 2, ECBHeight / 2f)));

                foreach (LineIntersection2D lefttest in lefttests)
                {
                    if (lefttest.Valid && lefttest.Line0.Angle > 45 && lefttest.Line0.Angle < 135)
                    {
                        Transform.LocalPosition = new Vector3(lefttest.IntersectionPoint.X + (ECBWidth / 2), Transform.LocalPosition.Y, 0);
                        HitSide = true;
                    }
                }
            }

            {
                LineIntersection2D righttest = GlobalIntersectionTest(new Line2D(Transform.LocalPosition.Xy + new Vector2(0, 0.1f), Transform.LocalPosition.Xy + new Vector2(ECBWidth / 2, ECBHeight / 2f)));

                if (righttest.Valid && righttest.Line0.Angle > 45 && righttest.Line0.Angle < 135)
                {
                    Transform.LocalPosition = new Vector3(righttest.IntersectionPoint.X - (ECBWidth / 2), Transform.LocalPosition.Y, 0);
                    HitSide = true;
                }
            }
        }

        public void MoveX(float speed,float lerp = 1)
        {
            Velocity.X += (speed - Velocity.X) / (lerp / (float)Window.MainWindow.DeltaTime);
        }

        public void MoveY(float speed, float lerp = 1)
        {
            Velocity.Y += (speed - Velocity.Y) / (lerp / (float)Window.MainWindow.DeltaTime);
        }

        public void Init()
        {
            Transform.LocalPosition += new Vector3(Velocity.X,Velocity.Y,0) * ArenaScene.GLobalSpeed;
        }

        public static LineIntersection2D GlobalIntersectionTest(Line2D line)
        {
            LineIntersection2D Out = new LineIntersection2D();

            float len = float.PositiveInfinity;

            foreach (Line2D test in SceneGeomatry)
            {
                LineIntersection2D tested = TestIntersection(test,line);

                if (tested.Valid)
                {
                    float l = tested.DistanceToPoint(line.Point0);

                    if (l < len)
                    {
                        Out = tested;
                        len = l;
                    }
                }
            }

            return Out;
        }

        public static List<LineIntersection2D> GlobalAllIntersectionTest(Line2D line)
        {
            List<LineIntersection2D> Out = new List<LineIntersection2D>();

            foreach (Line2D test in SceneGeomatry)
            {
                LineIntersection2D tested = TestIntersection(test, line);

                if (tested.Valid)
                {
                    Out.Add(tested);
                }
            }
            return Out;
        }

        public static LineIntersection2D TestIntersection(Line2D line0,Line2D line1)
        {
            LineIntersection2D Out = new LineIntersection2D();

            Vector3 ts = line0.LineSlope;

            Vector2 lo = line1.Point0;
            Vector2 ld = line1.Direction;

            float t = ((-ts.X * lo.X) - (ts.Y * lo.Y) + ts.Z) / ((ts.X * ld.X) + (ts.Y*ld.Y));

            Out.IntersectionPoint = lo + (ld * t);

            Out.Valid = line0.LineOnPoint(Out.IntersectionPoint) && line1.LineOnPoint(Out.IntersectionPoint);
            Out.Line0 = line0;
            Out.Line1 = line1;

            return Out;
        }

        public static QuadIntersection TestCollision(Quad r0, Quad r1,bool outline = true)
        {
            QuadIntersection Out = new QuadIntersection();

            List<Line2D> t0 = r0.LineList;
            List<Line2D> t1 = r1.LineList;

            foreach (Line2D line in t0)
            {
                foreach (Line2D line0 in t1)
                {
                    LineIntersection2D intersectiontest = TestIntersection(line, line0);

                    if (intersectiontest.Valid)
                    {
                        Out.Intersections.Add(intersectiontest);
                    }
                }
            }

            if (outline)
            {
                if (Out.Valid)
                {
                    r0.renderer.Color = new Vector4(0, 1, 0, 1);
                    r1.renderer.Color = new Vector4(0, 1, 0, 1);
                }
                else
                {
                    r0.renderer.Color = new Vector4(1, 0, 0, 1);
                    r1.renderer.Color = new Vector4(1, 0, 0, 1);
                }
            }

            return Out;
        }

        public static CircleLineIntersection TestCollision(Circle circle, Line2D line)
        {
            CircleLineIntersection Out = new CircleLineIntersection();

            Out.line = line;
            Out.circle = circle;

            if (CirclePointIntersection(circle, line.Point0))
            {
                Out.Valid = true;
            }
            else if (CirclePointIntersection(circle, line.Point1))
            {
                Out.Valid = true;
            }
            else
            {
                Line2D intersectiontest = new Line2D(circle.Position + (line.Normal * circle.R),circle.Position + (-line.Normal * circle.R));

                Out.Valid = TestIntersection(intersectiontest,line).Valid;
            }    

            if (Out.Valid)
            {
                Out.circle.renderer.Color = new Vector4(0,0,0,1);
            }
            else
            {
                Out.circle.renderer.Color = new Vector4(1, 0, 0, 1);
            }

            return Out;
        }

        public static CircleQuadIntersection TestCollision(Circle circle,Quad quad)
        {
            CircleQuadIntersection Out = new CircleQuadIntersection();

            Out.circle = circle;
            Out.quad = quad;

            List<Line2D> linetest = quad.LineList;

            foreach (Line2D line in linetest)
            {

            }

            return Out;
        }

        public static bool CirclePointIntersection(Circle circle,Vector2 point)
        {
            return ((point - circle.Position).Length < circle.R);
        }

        public static GeomatryRenderer2D SceneGeomatryRenderer { get; set; } 

        public static void DrawSceneGeomatry()
        {
            if (SceneGeomatryRenderer == null)
            {
                SceneGeomatryRenderer = new GeomatryRenderer2D();

                SceneGeomatryRenderer.BuildMesh(SceneGeomatry);
            }

            SceneGeomatryRenderer.Draw();
        }

        public bool HuggingLedge { get; private set; }

        public void HugLedge()
        {
            if (HuggingLedge)
            {
                Velocity.X = 0;
            }
        }

        public static List<Line2D> LinesFromPoints(Vector2[] Points,bool loop = false)
        {
            List<Line2D> Out = new List<Line2D>();

            for (int i = 0; i < Points.Length -1; i++)
            {
                Out.Add(new Line2D(Points[i],Points[i+1]));
            }

            if (loop)
            {
                Out.Add(new Line2D(Points[Points.Length - 1], Points[0]));
            }

            return Out;
        }
    }
}