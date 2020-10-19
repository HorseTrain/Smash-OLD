using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Scene
{
    public class InstanceController : XMLParsable
    {
        public string Url { get; set; }

        public List<SkeletonReference> SkeletonReferences { get; set; } = new List<SkeletonReference>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Url = element.GetAttribute("url");

            foreach (XMLElement child in element.Children)
            {
                if (child.Name == "skeleton")
                {
                    SkeletonReferences.Add(ParseXMLParsable<SkeletonReference>(child));
                }
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("instance_controller");

            Out.Attributes.Add("url",Url);

            foreach (SkeletonReference r in SkeletonReferences)
            {
                r.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
