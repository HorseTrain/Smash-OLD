using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class VertexInputSemantic : XMLParsable
    {
        public string Semantic { get; set; }
        public string Source { get; set; }
        public override void ParseFromXMLParsable(XMLElement element)
        {
            Semantic = element.Attributes["semantic"];
            Source = element.Attributes["source"];
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("input",null,true);

            Out.Attributes.Add("semantic", Semantic);
            Out.Attributes.Add("source",Source);

            return Out;
        }
    }
}
