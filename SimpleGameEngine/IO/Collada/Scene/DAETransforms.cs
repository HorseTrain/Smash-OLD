using OpenTK;
using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Scene
{
    public class transform : XMLParsable
    {
        public string Name { get; set; } = null;
        public string Sid { get; set; } = null;
    }

    public class vec3 : transform
    {
        public Vector3 vector;

        public static explicit operator Vector3(vec3 vec)
        {
            return vec.vector;
        }

        public vec3()
        {

        }

        public vec3(Vector3 vec,string name = "")
        {
            vector = vec;
            Name = name;
        }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            vector = new Vector3(float.Parse(element.Data[0]), float.Parse(element.Data[1]), float.Parse(element.Data[2]));

            Name = element.Name;

            Sid = element.GetAttribute("sid");
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement(Name);

            for (int i = 0; i < 3; i++)
            {
                Out.Data.Add(vector[i].ToString());
            }

            if (Sid != null)
                Out.Attributes.Add("sid",Sid);

            return Out;
        }
    }

    public class quaternion : transform
    {
        public Quaternion rotation;

        public quaternion()
        {

        }

        public quaternion(Quaternion quat,string name = "")
        {
            rotation = quat;
            Name = name;
        }

        public static explicit operator Quaternion(quaternion quat)
        {
            return quat.rotation;
        }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            rotation = new Quaternion(float.Parse(element.Data[0]), float.Parse(element.Data[1]), float.Parse(element.Data[2]), float.Parse(element.Data[3]));

            Name = element.Name;

            Sid = element.GetAttribute("sid");
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement(Name);

            Out.Data.Add(rotation.X.ToString());
            Out.Data.Add(rotation.Y.ToString());
            Out.Data.Add(rotation.Z.ToString());
            Out.Data.Add(rotation.W.ToString());

            if (Sid != null)
                Out.Attributes.Add("sid", Sid);

            return Out;
        }
    }

    public class matrix4 :transform
    {
        public Matrix4 transform;

        public static explicit operator Matrix4(matrix4 matrix)
        {
            return matrix.transform;
        }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Name = element.Name;

            Sid = element.GetAttribute("sid");

            int ri = 0;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    transform[x, y] = float.Parse(element.Data[ri]);

                    ri++;
                }
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement(Name);

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Out.Data.Add(transform[y,x].ToString().ToLower());
                }
            }

            if (Sid != null)
                Out.Attributes.Add("sid", Sid);

            return Out;
        }
    }
}
