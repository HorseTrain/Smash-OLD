using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class Controller : XMLParsable
    {
        public string ID { get; set; }
        public List<Skin> Skins { get; set; } = new List<Skin>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.GetAttribute("id");

            Skins = ParseXMLObjectArray<Skin>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("controller");

            Out.Attributes.Add("id",ID);

            foreach (Skin skin in Skins)
            {
                skin.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
