using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada.Controllers
{
    public class NameArray : XMLParsable
    {
        public string ID { get; set; }
        public string[] Data { get; set; }
        public int Count => Data.Length;
        public override void ParseFromXMLParsable(XMLElement element)
        {
            Data = element.Data.ToArray();
            ID = element.GetAttribute("id");
        }

        public ref string this[int index] =>ref Data[index];

        public override XMLElement ToElement()
        {
            XMLElement Out = new XMLElement("Name_array");

            Out.Data = Data.ToList();
            Out.Attributes.Add("id",ID);
            Out.Attributes.Add("count",Count.ToString());

            return Out;
        }
    }
}
