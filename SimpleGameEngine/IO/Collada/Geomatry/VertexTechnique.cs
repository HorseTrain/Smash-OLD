using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class VertexTechnique : XMLParsable //reference to accessor?
    {
        public List<VertexAccessor> VertexAccessors { get; set; } = new List<VertexAccessor>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            VertexAccessors = ParseXMLObjectArray<VertexAccessor>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("technique_common");

            foreach (VertexAccessor accessor in VertexAccessors)
            {
                accessor.ToElement().Parent = Out;
            }

            return Out;
        }
    }

    public class VertexAccessor : XMLParsable
    {
        public string Source { get; set; }
        public int Count { get; set; }
        public int Stride { get; set; }
        public List<VertexParem> Perams { get; set; } = new List<VertexParem>();
        public override void ParseFromXMLParsable(XMLElement element)
        {
            Source = element.Attributes["source"];
            Count = int.Parse(element.Attributes["count"]);
            Stride = int.Parse(element.Attributes["stride"]);

            Perams = ParseXMLObjectArray<VertexParem>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("accessor");

            Out.Attributes.Add("source",Source);
            Out.Attributes.Add("count",Count.ToString());
            Out.Attributes.Add("stride",Stride.ToString());

            foreach (VertexParem peram in Perams)
            {
                peram.ToElement().Parent = Out;
            }

            return Out;
        }
    }

    public class VertexParem : XMLParsable
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Name = element.Attributes["name"];
            Type = element.Attributes["type"];
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("param", null,true);

            Out.Attributes.Add("name",Name);
            Out.Attributes.Add("type",Type);   

            return Out;
        }
    }
}
