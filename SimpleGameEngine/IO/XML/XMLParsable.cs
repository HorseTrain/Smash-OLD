using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.XML
{
    public class XMLParsable
    {
        public virtual XMLElement ToElement()
        {
            return null;
        }

        public virtual void ParseFromXMLParsable(XMLElement element)
        {

        }

        public static T ParseXMLParsable<T>(XMLElement element) where T: XMLParsable,new()
        {
            T Out = new T();

            Out.ParseFromXMLParsable(element);

            return Out;
        }

        public static List<T> ParseXMLObjectArray<T>(XMLElement element) where T: XMLParsable,new()
        {
            List<T> Out = new List<T>();

            foreach(XMLElement source in element.Children)
            {
                Out.Add(ParseXMLParsable<T>(source));
            }

            return Out;
        }
    }
}
