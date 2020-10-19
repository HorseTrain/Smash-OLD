using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Scene
{
    public class VisualScene : XMLParsable
    {
        public string ID { get; set; } = null;
        public string Name { get; set; } = null;
        public List<Node> Nodes { get; set; } = new List<Node>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.GetAttribute("id");
            Name = element.GetAttribute("name");

            Nodes = ParseXMLObjectArray<Node>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("visual_scene");

            if (ID != null)
                Out.Attributes.Add("id",ID);

            if (Name != null)
                Out.Attributes.Add("name", Name);

            foreach (Node node in Nodes)
            {
                node.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
