using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class TriangleData : XMLParsable
    {
        public int Count { get; set; }
        public string Material { get; set; } = null;
        public List<TriangleInputSemantic> VertexTriangleSemantics { get; set; } = new List<TriangleInputSemantic>();
        public List<int[]> Sources { get; set; } = new List<int[]>();
        public override void ParseFromXMLParsable(XMLElement element)
        {
            Count = int.Parse(element.Attributes["count"]);

            if (element.Attributes.ContainsKey("material"))
            {
                Material = element.Attributes["material"];
            }

            foreach (XMLElement datapoint in element.Children)
            {
                if (datapoint.Name == "input")
                {
                    VertexTriangleSemantics.Add(ParseXMLParsable<TriangleInputSemantic>(datapoint));
                }
                else if (datapoint.Name == "p")
                {
                    Sources.Add(ReadSourceInts(datapoint));
                }
            }
        }

        public static int[] ReadSourceInts(XMLElement element)
        {
            int[] Out = new int[element.Data.Count];

            for (int i = 0; i < Out.Length; i++)
            {
                Out[i] = int.Parse(element.Data[i]);
            }

            return Out;
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("triangles");

            if (Material != null)
            {
                Out.Attributes.Add("material", Material);
            }

            Out.Attributes.Add("count",Count.ToString());

            foreach (TriangleInputSemantic semantic in VertexTriangleSemantics)
            {
                semantic.ToElement().Parent = Out;
            }

            foreach (int[] data in Sources)
            {
                XMLElement triangledata = new XMLElement("p",Out);

                foreach (int i in data)
                {
                    triangledata.Data.Add(i.ToString());
                }
            }

            return Out;
        }
    }
}
