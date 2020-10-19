using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class VertexPointer : XMLParsable //?
    {
        public string ID { get; set; }
        public List<VertexInputSemantic> Semantics { get; set; } = new List<VertexInputSemantic>();
        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.Attributes["id"];

            Semantics = ParseXMLObjectArray<VertexInputSemantic>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("vertices");

            Out.Attributes.Add("id",ID);

            foreach (VertexInputSemantic semantic in Semantics)
            {
                semantic.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
