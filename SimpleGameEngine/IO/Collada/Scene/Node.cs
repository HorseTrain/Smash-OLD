using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Scene
{
    public class Node : XMLParsable
    {
        public string ID { get; set; } = null;
        public string Name { get; set; } = null;
        public string Sid { get; set; } = null;
        public string Type { get; set; } = null;
        public List<Node> ChildNodes { get; set; } = new List<Node>();
        public List<transform> Transforms { get; set; } = new List<transform>();
        public List<GeomatryInstance> GeomatryInstances { get; set; } = new List<GeomatryInstance>();
        public List<InstanceController> GeomatryInstanceControllers { get; set; } = new List<InstanceController>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.GetAttribute("id");
            Name = element.GetAttribute("name");
            Sid = element.GetAttribute("sid");
            Type = element.GetAttribute("type");

            foreach (XMLElement childnode in element.Children)
            {
                if (childnode.Name == "node")
                {
                    ChildNodes.Add(ParseXMLParsable<Node>(childnode));
                }
                else if (childnode.Name == "translate" || childnode.Name == "scale")
                {
                    Transforms.Add(ParseXMLParsable<vec3>(childnode));
                }
                else if (childnode.Name == "matrix")
                {
                    Transforms.Add(ParseXMLParsable<matrix4>(childnode));
                }
                else if (childnode.Name == "rotate")
                {
                    Transforms.Add(ParseXMLParsable<quaternion>(childnode));
                }
                else if (childnode.Name == "instance_geometry")
                {
                    GeomatryInstances.Add(ParseXMLParsable<GeomatryInstance>(childnode));
                }
                else if (childnode.Name == "instance_controller")
                {
                    GeomatryInstanceControllers.Add(ParseXMLParsable<InstanceController>(childnode));
                }
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("node");

            if (ID != null)
                Out.Attributes.Add("id",ID);

            if (Name != null)
                Out.Attributes.Add("name",Name);

            if (Sid != null)
                Out.Attributes.Add("sid",Sid);

            if (Type != null)
                Out.Attributes.Add("type",Type);

            foreach (transform transform in Transforms)
            {
                transform.ToElement().Parent = Out;
            }

            foreach (Node node in ChildNodes)
            {
                node.ToElement().Parent = Out;
            }

            foreach (GeomatryInstance instance in GeomatryInstances)
            {
                instance.ToElement().Parent = Out;
            }

            foreach (InstanceController controller in GeomatryInstanceControllers)
            {
                controller.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
