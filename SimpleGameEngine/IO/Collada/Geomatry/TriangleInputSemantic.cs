using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class TriangleInputSemantic : XMLParsable
    {
        public string Semantic { get; set; }
        public string Source { get; set; }
        public int Offset { get; set; }
        public int Set { get; set; } = -1;//Will cause problems?
        public bool ContainsSet => Set != -1;
        public override void ParseFromXMLParsable(XMLElement element)
        {
            Semantic = element.Attributes["semantic"];
            Source = element.Attributes["source"];
            Offset = int.Parse(element.Attributes["offset"]);

            if (element.Attributes.ContainsKey("set"))
            {
                Set = int.Parse(element.Attributes["set"]);
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("input",null,true);

            Out.Attributes.Add("semantic", Semantic);
            Out.Attributes.Add("source",Source);
            Out.Attributes.Add("offset", Offset.ToString());

            if (ContainsSet)
                Out.Attributes.Add("set",Set.ToString());
     
            return Out;
        }
    }
}
