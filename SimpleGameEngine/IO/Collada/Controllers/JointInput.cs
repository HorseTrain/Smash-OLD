using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class JointInput : XMLParsable
    {
        public string Semantic { get; set; }
        public string Source { get; set; }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Semantic = element.GetAttribute("semantic");
            Source = element.GetAttribute("source");
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("input",null,true);

            Out.Attributes.Add("semantic",Semantic);
            Out.Attributes.Add("source",Source);

            return Out;
        }
    }
}
