using SimpleGameEngine.IO.Collada.Controllers;
using SimpleGameEngine.IO.Collada.Geomatry;
using SimpleGameEngine.IO.Collada.Scene;
using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO.Collada
{
    public class ColladaFile : XMLParsable
    {
        public XMLElement ParentCollada { get; set; } = new XMLElement("COLLADA");
        public List<GeomatrySource> GeomatrySources { get; set; }
        public List<VisualScene> VisualScenes { get; set; }
        public List<Controller> Controllers { get; set; }
        public List<SceneInstance> SceneInstiances { get; set; }

        public static ColladaFile LoadColladaScene(XMLFile File)
        {
            ColladaFile Out = new ColladaFile();

            Out.ParentCollada = new XMLElement("COLLADA");
            Out.ParentCollada.Attributes.Add("xmlns", @"http://www.collada.org/2005/11/COLLADASchema");
            Out.ParentCollada.Attributes.Add("version", @"1.4.1");
            Out.ParentCollada.Attributes.Add("xmlns:xsi", @"http://www.w3.org/2001/XMLSchema-instance");

            foreach (XMLElement element in File.ParentElements[0].Children)
            {
                if (element.Name == "library_geometries")
                {
                    Out.GeomatrySources = ParseXMLObjectArray<GeomatrySource>(element);
                }

                if (element.Name == "library_visual_scenes")
                {     
                    Out.VisualScenes = ParseXMLObjectArray<VisualScene>(element);
                }

                if (element.Name == "library_controllers")
                {
                    Out.Controllers = ParseXMLObjectArray<Controller>(element);
                }

                if (element.Name == "scene")
                {
                    Out.SceneInstiances = ParseXMLObjectArray<SceneInstance>(element);
                }
            }

            return Out;
        }

        public XMLFile ExportToCollada()
        {
            XMLFile Out = new XMLFile();

            XMLElement library_geometries = new XMLElement("library_geometries",ParentCollada);
            XMLElement library_controllers = new XMLElement("library_controllers", ParentCollada);
            XMLElement library_visual_scenes = new XMLElement("library_visual_scenes", ParentCollada);
            XMLElement scene = new XMLElement("scene", ParentCollada);

            foreach (GeomatrySource source in GeomatrySources)
            {
                source.ToElement().Parent = library_geometries;
            }

            foreach (Controller controller in Controllers)
            {
                controller.ToElement().Parent = library_controllers;
            }

            foreach (VisualScene vscene in VisualScenes)
            {
                vscene.ToElement().Parent = library_visual_scenes;
            }

            foreach (SceneInstance instance in SceneInstiances)
            {
                instance.ToElement().Parent = scene;
            }

            Out.ParentElements.Add(ParentCollada);

            return Out;
        }
    }
}
