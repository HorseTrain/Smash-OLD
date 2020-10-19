using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.XML
{
    public class XMLFile
    {
        public List<XMLElement> ParentElements { get; set; } = new List<XMLElement>();

        public void Export(string path)
        {
            StringBuilder Out = new StringBuilder();

            foreach (XMLElement element in ParentElements)
            {
                Out.Append(element.ToString());
            }

            File.WriteAllText(path,Out.ToString());
        }

        public XMLFile LoadFile(byte[] Data)
        {
            XMLFile Out = new XMLFile();

            return Out;
        }

        public List<XMLElement> FindElement(string name)
        {
            List<XMLElement> Out = new List<XMLElement>();

            foreach (XMLElement element in ParentElements)
            {
                if (element.Name == name)
                    Out.Add(element);
            }

            return Out;
        }
    }
}
