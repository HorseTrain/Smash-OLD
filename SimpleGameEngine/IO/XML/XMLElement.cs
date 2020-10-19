using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.XML
{
    public class XMLElement
    {
        protected XMLElement()
        {

        }

        public XMLElement(string name, XMLElement parent = null, bool single = false)
        {
            Name = name;
            Parent = parent;
            SingleBody = single;
        }

        public string Name { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        public string GetAttribute(string name)
        {
            if (Attributes.ContainsKey(name))
            {
                return Attributes[name];
            }
            else
            {
                return null;
            }
        }

        public List<string> Data { get; set; } = new List<string>();
        public bool SingleBody { get; set; }
        XMLElement parent { get; set; }

        public XMLElement Parent
        {
            get => parent;

            set
            {
                if (parent != null)
                    parent.Children.Remove(this);

                parent = value;

                if (parent != null)
                    parent.Children.Add(this);
            }
        }

        public List<XMLElement> Children { get; set; } = new List<XMLElement>();

        public XMLElement GetChild(int index)
        {
            if (index < Children.Count)
                return Children[index];
            else
                return null;
        }

        public int ChildCount => Children.Count;

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();

            temp.Append("<" + Name);

            AddAttributes(temp);

            if (SingleBody)
            {
                temp.Append("/>");
            }
            else
            {
                temp.Append(">");

                if (Data.Count == 0 && ChildCount != 0)
                    temp.Append("\n");

                for (int i = 0; i < Data.Count; i++)
                {
                    temp.Append(Data[i]);

                    if (i != Data.Count - 1)
                        temp.Append(' ');
                }

                for (int c = 0; c < ChildCount; c++)
                {
                    string test = GetChild(c).ToString();

                    string[] parts = test.Split('\n');

                    for (int i = 0; i < parts.Length; i++)
                    {
                        temp.Append("  " + parts[i]);

                        if (i != parts.Length - 1)
                            temp.Append("\n");
                    }

                    if (c != ChildCount - 1)
                        temp.Append("\n");
                }

                if (ChildCount != 0)
                    temp.Append("\n");

                temp.Append("</" + Name +">");
            }

            return temp.ToString();
        }

        void AddAttributes(StringBuilder builder)
        {
            string[] keys = Attributes.Keys.ToArray();

            if (keys.Length != 0)
            builder.Append(' ');

            for (int i = 0; i < keys.Length; i++)
            {
                builder.Append(keys[i] + "=" + "\"" + Attributes[keys[i]] + "\"");

                if (i != keys.Length - 1)
                    builder.Append(" ");
            }
        }

        public List<XMLElement> FindElement(string name)
        {
            List<XMLElement> Out = new List<XMLElement>();

            foreach (XMLElement element in Children)
            {
                if (element.Name == name)
                    Out.Add(element);
            }

            return Out;
        }
    }
}
