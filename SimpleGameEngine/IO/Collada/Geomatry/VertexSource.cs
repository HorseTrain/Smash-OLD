using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class VertexSource : XMLParsable
    {
        public string semantic { get; set; }
        public string ID { get; set; }
        public FloatArray VertexData { get; set; } = new FloatArray();
        public VertexTechnique Technique { get; set; } = new VertexTechnique();

        public VertexSource()
        {

        }

        public VertexSource(string id)
        {
            id = ID;
        }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.Attributes["id"];

            VertexData = ParseXMLParsable<FloatArray>(element.Children[0]);

            Technique = ParseXMLParsable<VertexTechnique>(element.Children[1]);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("source");

            Out.Attributes.Add("id",ID);

            VertexData.ToElement().Parent = Out;
            Technique.ToElement().Parent = Out;

            return Out;
        }
    }
}
