using SimpleGameEngine.IO.XML;
using Smash.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game
{
    public class XMLParsable
    {
        public static XMLFile MasterPeram { get; set; } 

        public static T ParseObject<T>(XMLElement element) where T : XMLParsable,new()
        {
            T Out = new T();

            for (int i = 0; i < element.ChildCount; i++)
            {
                XMLElement value = element.GetChild(i);

                string name = value.Attributes["name"];
                string Data = value.Attributes["value"];

                var type = Out.GetType().GetProperty(name);

                switch (value.Name)
                {
                    case "int": type.SetValue(Out, int.Parse(Data)); break;
                    case "float": type.SetValue(Out, float.Parse(Data)); break;
                    case "string": type.SetValue(Out, Data); break;
                }
            }

            return Out;
        }
    }
}
