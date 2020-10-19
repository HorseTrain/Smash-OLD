using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Geomatry
{
    public class MeshSource : XMLParsable
    {
        public List<VertexSource> VertexSources { get; set; } = new List<VertexSource>();
        public List<VertexPointer> VertexPointers { get; set; } = new List<VertexPointer>();
        public List<TriangleData> TriangleData { get; set; } = new List<TriangleData>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            foreach (XMLElement source in element.Children)
            {
                if (source.Name == "source")
                {
                    VertexSources.Add(ParseXMLParsable<VertexSource>(source));
                }
                else if (source.Name == "vertices")
                {
                    VertexPointers.Add(ParseXMLParsable<VertexPointer>(source));
                }
                else if (source.Name == "triangles")
                {
                    TriangleData.Add(ParseXMLParsable<TriangleData>(source));
                }
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("mesh");

            foreach (VertexSource source in VertexSources)
            {
                source.ToElement().Parent = Out;
            }

            foreach (VertexPointer pointer in VertexPointers)
            {
                pointer.ToElement().Parent = Out;
            }

            foreach (TriangleData triangledata in TriangleData)
            {
                triangledata.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
