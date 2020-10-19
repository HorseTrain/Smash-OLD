using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class ControllerAccessor : XMLParsable
    {
        public string Source { get; set; }
        public int Count { get; set; }
        public int Stride { get; set; }
        public List<ControllerAccessorParam> Params { get; set; } = new List<ControllerAccessorParam>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Source = element.GetAttribute("source");
            Count = int.Parse(element.GetAttribute("count"));
            Stride = int.Parse(element.GetAttribute("stride"));

            Params = ParseXMLObjectArray<ControllerAccessorParam>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("accessor");

            Out.Attributes.Add("source",Source);
            Out.Attributes.Add("count",Count.ToString());
            Out.Attributes.Add("stride",Stride.ToString());

            foreach (ControllerAccessorParam param in Params)
            {
                param.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
