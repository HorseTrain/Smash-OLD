using SimpleGameEngine.IO.Collada.Scene;
using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class Skin : XMLParsable
    {
        public string Source { get; set; }
        public List<matrix4> BindMatricies { get; set; } = new List<matrix4>();
        public List<DataSource> Sources { get; set; } = new List<DataSource>();
        public List<JointCollection> JointCollections { get; set; } = new List<JointCollection>();
        public List<VertexWeightCollection> WeightData { get; set; } = new List<VertexWeightCollection>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Source = element.GetAttribute("source");

            foreach (XMLElement child in element.Children)
            {
                if (child.Name == "bind_shape_matrix")
                {
                    BindMatricies.Add(ParseXMLParsable<matrix4>(child));
                }
               
                if (child.Name == "source")
                {
                    Sources.Add(ParseXMLParsable<DataSource>(child));
                }

                if (child.Name == "joints")
                {
                    JointCollections.Add(ParseXMLParsable<JointCollection>(child));
                }

                if (child.Name == "vertex_weights")
                {
                    WeightData.Add(ParseXMLParsable<VertexWeightCollection>(child));
                }
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("skin");

            Out.Attributes.Add("source",Source);

            foreach (matrix4 mat in BindMatricies)
            {
                mat.ToElement().Parent = Out;
            }

            foreach (DataSource source in Sources)
            {
                source.ToElement().Parent = Out;
            }

            foreach (JointCollection joint in JointCollections)
            {
                joint.ToElement().Parent = Out;
            }

            foreach (VertexWeightCollection weight in WeightData)
            {
                weight.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
