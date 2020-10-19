using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Scene
{
    public class SkeletonReference : XMLParsable 
    {
        public List<string> Skeletons { get; set; } = new List<string>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Skeletons = element.Data;
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("skeleton");

            Out.Data = Skeletons;

            return Out;
        }
    }
}
