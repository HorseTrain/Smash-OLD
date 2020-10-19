using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Scene
{
    public class SceneInstance : XMLParsable
    {
        public string Url { get; set; }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Url = element.GetAttribute("url");
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("instance_visual_scene",null,true);

            Out.Attributes.Add("url",Url);

            return Out;
        }
    }
}
