using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class GeomatrySource : XMLParsable
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<MeshSource> MeshSources { get; set; } = new List<MeshSource>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.Attributes["id"];
            Name = element.Attributes["name"];

            MeshSources = ParseXMLObjectArray<MeshSource>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("geometry");

            Out.Attributes.Add("id",ID);
            Out.Attributes.Add("name",Name);

            foreach (MeshSource mesh in MeshSources)
            {
                mesh.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
