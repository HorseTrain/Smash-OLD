using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.XML
{
    public enum TokenType
    {
        DataPoint,
        Indexer,
        String
    }

    public class XMLToken
    {
        public string Source { get; set; }
        public TokenType type { get; set; }
        public XMLToken(string source, TokenType type)
        {
            this.Source = source;
            this.type = type;
        }

        public XMLToken(char source, TokenType type)
        {
            this.Source = "";
            Source += source;
            this.type = type;
        }

        public override string ToString()
        {
            return "{"+ type + " " + Source + "}";
        }
    }

    public class XMLParser
    {
        public static XMLFile LoadFile(string Path)
        {
            string Data = File.ReadAllText(Path);

            List<XMLToken> Tokens = new List<XMLToken>();

            bool InString = false;

            string TempBuffer = "";

            void Clear()
            {
                if (TempBuffer != "")
                {
                    Tokens.Add(new XMLToken(TempBuffer,TokenType.DataPoint));
                }

                TempBuffer = "";
            }

            foreach (char c in Data)
            {
                if (!InString)
                {
                    if (c == '\"')
                    {
                        Clear();

                        InString = true;
                    }
                    else if (c == ' ' || c == '\n' || c == 13)
                    {
                        Clear();
                    }
                    else if (c == '<' || c == '>' || c == '/' || c == '=')
                    {
                        Clear();

                        Tokens.Add(new XMLToken(c, TokenType.Indexer));
                    }
                    else
                    {
                        TempBuffer += c;
                    }
                }
                else
                {
                    if (c == '\"')
                    {
                        Tokens.Add(new XMLToken(TempBuffer, TokenType.String));

                        TempBuffer = "";

                        InString = false;
                    }
                    else
                    {
                        TempBuffer += c;
                    }
                }
            }

            return LoadFile(Tokens);
        }

        public static XMLFile LoadFile(List<XMLToken> Tokens)
        {
            XMLFile Out = new XMLFile();

            XMLElement[] indexers = new XMLElement[1000];

            int parentindex = 0;

            int tindex = 0;

            foreach (XMLToken token in Tokens)
            {
                if (token.Source == "<" && token.type == TokenType.Indexer)
                {
                    if (Tokens[tindex + 1].Source == "/")
                    {
                        parentindex--;
                    }
                    else
                    {
                        if (parentindex == 0)
                        {
                            indexers[parentindex] = new XMLElement(Tokens[tindex + 1].Source);

                            Out.ParentElements.Add(indexers[parentindex]);
                        }
                        else
                            indexers[parentindex] = new XMLElement(Tokens[tindex + 1].Source,indexers[parentindex - 1]);

                        int i = tindex + 2;

                        for (; i < Tokens.Count; i++)
                        {
                            if (Tokens[i].Source == ">" && Tokens[i].type == TokenType.Indexer)
                            {
                                i++;

                                break;
                            }
                            else
                            {
                                if (Tokens[i].type == TokenType.DataPoint)
                                {
                                    indexers[parentindex].Attributes.Add(Tokens[i].Source, Tokens[i+2].Source);
                                }
                            }
                        }

                        for (;i < Tokens.Count; i++)
                        {
                            if (Tokens[i].type == TokenType.Indexer)
                            {
                                break;
                            }
                            else
                            {
                                indexers[parentindex].Data.Add(Tokens[i].Source);
                            }
                        }

                        parentindex++;
                    }
                }

                if (token.Source == "/" && token.type == TokenType.Indexer)
                {
                    if (Tokens[tindex + 1].Source == ">")
                    {
                        parentindex--;

                        indexers[parentindex].SingleBody = true;
                    }
                }

                tindex++;
            }

            return Out;
        }
    }
}
