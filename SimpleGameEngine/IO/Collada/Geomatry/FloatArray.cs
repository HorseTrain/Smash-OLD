using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class FloatArray : XMLParsable
    {
        public string ID { get; set; }
        public int Count => Data.Length;
        public float[] Data { get; set; }
        public ref float this[int index] => ref Data[index];

        public FloatArray()
        {

        }

        public FloatArray(List<float> Data)
        {
            this.Data = Data.ToArray();
        }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.Attributes["id"];
            Data = new float[element.Data.Count];

            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = float.Parse(element.Data[i]);
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("float_array");

            Out.Attributes.Add("id",ID);
            Out.Attributes.Add("count",Count.ToString());

            foreach (float f in Data)
            {
                Out.Data.Add(f.ToString().ToLower());
            }

            return Out;
        }
    }
}
