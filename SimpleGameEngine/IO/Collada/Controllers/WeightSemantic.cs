using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class WeightSemantic : XMLParsable
    {
        public string Semantic { get; set; }
        public string Source { get; set; }
        public int Offset { get; set; }
        public override void ParseFromXMLParsable(XMLElement element)
        {
            Semantic = element.GetAttribute("semantic");
            Source = element.GetAttribute("source");
            Offset = int.Parse(element.GetAttribute("offset"));
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("input",null,true);

            Out.Attributes.Add("semantic", Semantic);
            Out.Attributes.Add("source",Source);
            Out.Attributes.Add("offset",Offset.ToString());

            return Out;
        }
    }
}
