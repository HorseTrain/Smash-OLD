using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class ControllerTechnique : XMLParsable
    {
        public List<ControllerAccessor> Accessors = new List<ControllerAccessor>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Accessors = ParseXMLObjectArray<ControllerAccessor>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("technique_common");

            foreach (ControllerAccessor accessor in Accessors)
            {
                accessor.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
