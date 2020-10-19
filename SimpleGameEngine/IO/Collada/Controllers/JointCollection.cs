using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class JointCollection : XMLParsable
    {
        public List<JointInput> Inputs = new List<JointInput>();

        public override void ParseFromXMLParsable(XMLElement element)
        {
            Inputs = ParseXMLObjectArray<JointInput>(element);
        }

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("joints");

            foreach (JointInput input in Inputs)
            {
                input.ToElement().Parent = Out;
            }

            return Out;
        }
    }
}
