using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class ControllerAccessorParam : XMLParsable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public override void ParseFromXMLParsable(XMLElement element)
        {
            Name = element.GetAttribute("name");
            Type = element.GetAttribute("type");
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("param",null,true);

            Out.Attributes.Add("name",Name);
            Out.Attributes.Add("type", Type);

            return Out;
        }
    }
}
