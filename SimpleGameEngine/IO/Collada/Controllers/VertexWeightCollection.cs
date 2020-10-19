using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class VertexWeightCollection : XMLParsable
    {
        public int Count => VCount.Length;
        public List<WeightSemantic> Semantics { get; set; } = new List<WeightSemantic>();

        public int[] VCount { get; set; }
        public int[] V { get; set; }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            foreach (XMLElement child in element.Children)
            {
                if (child.Name == "input")
                {
                    Semantics.Add(ParseXMLParsable<WeightSemantic>(child));
                }

                if (child.Name == "vcount")
                {
                    VCount = new int[child.Data.Count];

                    for (int i = 0; i < Count; i++)
                    {
                        VCount[i] = int.Parse(child.Data[i]);
                    }
                }

                if (child.Name == "v")
                {
                    V = new int[child.Data.Count];

                    for (int i = 0; i < child.Data.Count; i++)
                    {
                        V[i] = int.Parse(child.Data[i]);
                    }
                }
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("vertex_weights");

            Out.Attributes.Add("count",Count.ToString());

            foreach (WeightSemantic semantic in Semantics)
            {
                semantic.ToElement().Parent = Out;
            }

            XMLElement vcount = new XMLElement("vcount",Out);
            XMLElement v = new XMLElement("v",Out);

            foreach (int i in VCount)
                vcount.Data.Add(i.ToString());

            foreach (int i in V)
                v.Data.Add(i.ToString());

            return Out;
        }
    }
}
