using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Physics.Shapes
{
    public class Capsule2D : Shape
    {
        Rectangle r0;
        Circle2D c0;
        Circle2D c1;

        public float h;
        public float w;

        public Circle2D TransformedC0
        {
            get
            {
                Matrix4 temp = Matrix4.CreateTranslation(new Vector3(0,h,0)) * Transform;

                return
                    new Circle2D(c0.R)
                    {
                        Position = temp.ExtractTranslation().Xy
                    };
            }
        }

        public Circle2D TransformedC1
        {
            get
            {
                Matrix4 temp = Transform;

                return
                    new Circle2D(c0.R)
                    {
                        Position = temp.ExtractTranslation().Xy
                    };
            }
        }

        public Rectangle TransformedRectangle
        {
            get
            {
                r0.Angle = Angle;
                r0.Position = Position;

                return r0;
            }
        }

        public Capsule2D(float width, float height)
        {
            height -= width;

            c0 = new Circle2D(width/2)
            {
                Position = new Vector2(width/2,height)
            };

            c1 = new Circle2D(width/2)
            {
                Position = new Vector2(width/2, 0)
            };
            
            r0 = new Rectangle(width,height,width/2,0);

            w = width/2;
            h = height;
        }

        public override void GLDraw()
        {
            TransformedC0.GLDraw();
            TransformedC1.GLDraw();
            TransformedRectangle.GLDraw();
        }

        public bool TestCollision()
        {
            return false;
        }

        public bool TestCollision(Capsule2D capsule2D)
        {
            if (TransformedC0.TestCollision(capsule2D.TransformedC0) || TransformedC0.TestCollision(capsule2D.TransformedC1) || TransformedC0.TestCollision(capsule2D.TransformedRectangle))
                return true;

            if (TransformedC1.TestCollision(capsule2D.TransformedC0) || TransformedC1.TestCollision(capsule2D.TransformedC1) || TransformedC1.TestCollision(capsule2D.TransformedRectangle))
                return true;

            if (TransformedRectangle.TestCollision(capsule2D.TransformedC0) || TransformedRectangle.TestCollision(capsule2D.TransformedC1) || TransformedRectangle.TestCollision(capsule2D.TransformedRectangle))
                return true;

            return false;
        }
    }
}
