using SimpleGameEngine.IO.Collada.Geomatry;
using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class DataSource : XMLParsable
    {
        public string ID { get; set; }

        public NameArray NameArray { get; set; } = null;
        public FloatArray FloatArray { get; set; } = null;

        public ControllerTechnique Technique { get; set; } = new ControllerTechnique();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            ID = element.GetAttribute("id");

            foreach (XMLElement child in element.Children)
            {
                if (child.Name == "Name_array")
                {
                    NameArray = ParseXMLParsable<NameArray>(child);
                }

                if (child.Name == "technique_common")
                {
                    Technique = ParseXMLParsable<ControllerTechnique>(child);
                }

                if (child.Name == "float_array")
                {
                    FloatArray = ParseXMLParsable<FloatArray>(child);
                }
            }
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("source");

            Out.Attributes.Add("id",ID);

            if (NameArray != null)
            {
                NameArray.ToElement().Parent = Out;
            }

            if (FloatArray != null)
            {
                FloatArray.ToElement().Parent = Out;
            }

            Technique.ToElement().Parent = Out;

            return Out;
        }
    }
}
