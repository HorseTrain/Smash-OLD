using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Scene
{
    public class GeomatryInstance : XMLParsable
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public GeomatryInstance()
        {

        }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Url = element.GetAttribute("url");
            Name = element.GetAttribute("name");
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("instance_geometry",null,true);

            Out.Attributes.Add("url",Url);
            Out.Attributes.Add("name",Name);

            return Out;
        }
    }
}
