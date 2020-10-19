using OpenTK;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.Graphics.Structs;
using SimpleGameEngine.IO.Collada;
using SimpleGameEngine.IO.Collada.Controllers;
using SimpleGameEngine.IO.Collada.Geomatry;
using SimpleGameEngine.IO.Collada.Scene;
using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.IO
{
    public static class Exporters
    {
        public static ColladaFile BuildCollada(RenderSkeleton skeleton,List<RenderMesh> geomatries)
        {
            ColladaFile Out = new ColladaFile();

            Out.GeomatrySources = new List<GeomatrySource>();
            Out.VisualScenes = new List<VisualScene>();
            Out.SceneInstiances = new List<SceneInstance>();
            Out.Controllers = new List<Controller>();

            Out.ParentCollada.Attributes.Add("xmlns", @"http://www.collada.org/2005/11/COLLADASchema");
            Out.ParentCollada.Attributes.Add("version", @"1.4.1");
            Out.ParentCollada.Attributes.Add("xmlns:xsi", @"http://www.w3.org/2001/XMLSchema-instance");

            {
                VisualScene Main = new VisualScene();

                Main.ID = "main_scene";
                Main.Name = "main_scene";

                Node armeturenode = new Node();

                {
                    armeturenode.ID = "Armature";
                    armeturenode.Name = "Armature";
                    armeturenode.Type = "NODE";

                    matrix4 t = new matrix4();
                    t.Name = "matrix";
                    t.transform = Matrix4.Identity;
                    t.Sid = "transform";

                    armeturenode.Transforms.Add(t);

                    armeturenode.ChildNodes.Add(FromTransformNode(skeleton.Nodes[0]));

                    Main.Nodes.Add(armeturenode);
                }

                {
                    Node nodes = new Node();

                    nodes.ID = "Meshes";
                    nodes.Name = "Meshes";
                    nodes.Type = "NDOE";

                    HashSet<string> names = new HashSet<string>();

                    foreach (RenderMesh mesh in geomatries)
                    {
                        if (names.Contains(mesh.Name))
                            mesh.Name += "_1";

                        names.Add(mesh.Name);

                        Out.GeomatrySources.Add(CreateSource(mesh, Out.Controllers,skeleton));

                        InstanceController controller = new InstanceController();

                        controller.Url = "#geom-" + mesh.Name + "-skin1";

                        SkeletonReference reff = new SkeletonReference();

                        reff.Skeletons.Add("#" + armeturenode.ChildNodes[0].ID);

                        controller.SkeletonReferences.Add(reff);

                        nodes.GeomatryInstanceControllers.Add(controller);
                    }

                    Main.Nodes.Add(nodes);
                }

                Out.VisualScenes.Add(Main);

                SceneInstance instance = new SceneInstance();

                instance.Url = "#" + Main.ID;

                Out.SceneInstiances.Add(instance);
            }

            return Out;
        }
        
        public static GeomatrySource CreateSource(RenderMesh mesh,List<Controller> controllers,RenderSkeleton skeleton)
        {
            GeomatrySource Out = new GeomatrySource();

            Out.Name = mesh.Name;
            Out.ID = "geom-" + mesh.Name;

            MeshSource ms = new MeshSource();

            {
                Controller controller = new Controller();

                List<float> VertexPositions = new List<float>();
                List<float> VertexNormals = new List<float>();
                List<float> VertexUV0 = new List<float>();
                List<float> VertexUV1 = new List<float>();
                List<float> VertexColor = new List<float>();

                int l = 0;

                Dictionary<float, int> Weights = new Dictionary<float, int>();

                List<int> AffectionCount = new List<int>();
                List<int> WeightPointer = new List<int>();

                controller.ID = "geom-" + mesh.Name + "-skin1";

                foreach (RenderVertex vertex in mesh.VertexData)
                {
                    int acount = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            VertexPositions.Add(vertex.VertexPosition[i]);
                            VertexNormals.Add(vertex.VertexNormal[i]);
                            VertexColor.Add(vertex.VertexColor[i]);
                        }

                        if (i < 2)
                        {
                            VertexUV0.Add(vertex.VertexUV[i]);
                            VertexUV1.Add(vertex.VertexUV1[i]);
                        }

                        if (vertex.VertexWeight[i] != 0)
                        {
                            if (!Weights.ContainsKey(vertex.VertexWeight[i]))
                            {
                                Weights.Add(vertex.VertexWeight[i], l);
                                l++;
                            }

                            acount++;

                            WeightPointer.Add(vertex.VertexWeightID[i]);
                            WeightPointer.Add(Weights[vertex.VertexWeight[i]]);
                        }
                    }

                    AffectionCount.Add(acount);
                }

                Skin skin = new Skin();

                skin.Source = "#geom-" + mesh.Name;

                matrix4 bm = new matrix4();

                bm.transform = Matrix4.Identity;
                bm.Name = "bind_shape_matrix";

                skin.BindMatricies.Add(bm);

                DataSource JointSource = new DataSource();

                {
                    JointSource.ID = controller.ID + "-joints";

                    NameArray array = new NameArray();

                    {
                        List<string> na = new List<string>();

                        for (int i = 0; i < skeleton.Nodes.Length; i++)
                            na.Add("joint" + i);


                        array.Data = na.ToArray();

                        array.ID = controller.ID + "-joints-array";

                        JointSource.NameArray = array;
                    }

                    {
                        ControllerTechnique technique = new ControllerTechnique();

                        ControllerAccessor accessor = new ControllerAccessor();

                        accessor.Source = "#" + array.ID;

                        accessor.Count = skeleton.Nodes.Length;
                        accessor.Stride = 1;

                        ControllerAccessorParam peram = new ControllerAccessorParam();

                        peram.Name = "JOINT";
                        peram.Type = "name";

                        accessor.Params.Add(peram);

                        technique.Accessors.Add(accessor);

                        JointSource.Technique = technique;
                    }

                    skin.Sources.Add(JointSource);
                }

                DataSource BindSource = new DataSource();

                {
                    BindSource.ID = controller.ID + "-bind_poses";

                    FloatArray data = new FloatArray();

                    data.ID = BindSource.ID + "-array";

                    List<float> bp = new List<float>();

                    foreach (Matrix4 mat in skeleton.InverseWorldTransforms)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                bp.Add(mat[y,x]);
                            }
                        }
                    }

                    data.Data = bp.ToArray();

                    BindSource.FloatArray = data;

                    ControllerTechnique technique = new ControllerTechnique();

                    ControllerAccessor accessor = new ControllerAccessor();

                    accessor.Source = "#" + data.ID;
                    accessor.Count = skeleton.Nodes.Length;
                    accessor.Stride = 16;

                    ControllerAccessorParam param = new ControllerAccessorParam();

                    param.Name = "TRANSFORM";
                    param.Type = "float4x4";

                    accessor.Params.Add(param);

                    technique.Accessors.Add(accessor);

                    BindSource.Technique = technique;

                    skin.Sources.Add(BindSource);
                }

                DataSource WeightSource = new DataSource();
                {
                    WeightSource.ID = controller.ID + "-weights";

                    FloatArray data = new FloatArray();

                    data.Data = Weights.Keys.ToArray();

                    WeightSource.FloatArray = data;

                    data.ID = WeightSource.ID + "-array";

                    ControllerTechnique technique = new ControllerTechnique();

                    ControllerAccessor accessor = new ControllerAccessor();

                    accessor.Source = "#" + data.ID;
                    accessor.Count = data.Count;
                    accessor.Stride = 1;

                    ControllerAccessorParam param = new ControllerAccessorParam();

                    param.Name = "WEIGHT";
                    param.Type = "float";

                    accessor.Params.Add(param);

                    technique.Accessors.Add(accessor);

                    WeightSource.Technique = technique;

                    skin.Sources.Add(WeightSource);
                }

                {
                    JointCollection j0 = new JointCollection();

                    JointInput input = new JointInput();
                    JointInput input1 = new JointInput();

                    input.Semantic = "JOINT";
                    input.Source = "#" + JointSource.ID;

                    input1.Semantic = "INV_BIND_MATRIX";
                    input1.Source = "#" + BindSource.ID;

                    j0.Inputs.Add(input);
                    j0.Inputs.Add(input1);
                    skin.JointCollections.Add(j0);
                }

                {
                    VertexWeightCollection collection = new VertexWeightCollection();

                    WeightSemantic semantic0 = new WeightSemantic();
                    WeightSemantic semantic1 = new WeightSemantic();

                    semantic0.Semantic = "JOINT";
                    semantic0.Source = "#" + JointSource.ID;
                    semantic0.Offset = 0;

                    semantic1.Semantic = "WEIGHT";
                    semantic1.Source = "#" + WeightSource.ID;
                    semantic1.Offset = 1;

                    collection.Semantics.Add(semantic0);
                    collection.Semantics.Add(semantic1);

                    collection.VCount = AffectionCount.ToArray();
                    collection.V = WeightPointer.ToArray();


                    skin.WeightData.Add(collection);
                }

                controller.Skins.Add(skin);

                controllers.Add(controller);

                ms.VertexSources.Add(SourceFromArray("geom-" + mesh.Name + "-positions",VertexPositions,3,"X Y Z","VERTEX"));
                ms.VertexSources.Add(SourceFromArray("geom-" + mesh.Name + "-normals", VertexNormals, 3, "X Y Z","NORMAL"));
                ms.VertexSources.Add(SourceFromArray("geom-" + mesh.Name + "-map0", VertexUV1, 2, "S T", "TEXCOORD"));
                //ms.VertexSources.Add(SourceFromArray("geom-" + mesh.Name + "-color", VertexColor, 3, "R G B", "COLOR"));
            }

            {
                VertexPointer vpointer = new VertexPointer();

                vpointer.ID = "geom-" + mesh.Name + "-vertices";

                VertexInputSemantic semantic = new VertexInputSemantic();

                semantic.Semantic = "POSITION";
                semantic.Source = "#geom-" + mesh.Name + "-positions";

                vpointer.Semantics.Add(semantic);

                ms.VertexPointers.Add(vpointer);
            }

            {
                TriangleData tri = new TriangleData();

                tri.Count = mesh.IndexData.Length / 3;

                List<int> tris = new List<int>();

                foreach (ushort u in mesh.IndexData)
                {
                    tris.Add(u);
                    tris.Add(u);
                    tris.Add(u);
                }

                tri.Sources.Add(tris.ToArray());

                int i = 0;

                foreach (VertexSource source in ms.VertexSources)
                {
                    TriangleInputSemantic tsemantic = new TriangleInputSemantic();

                    tsemantic.Source = "#" + source.ID;
                    tsemantic.Semantic = source.semantic;

                    tri.VertexTriangleSemantics.Add(tsemantic);

                    tsemantic.Offset = i;

                    if (source.semantic == "TEXCOORD")
                        tsemantic.Set = 0;

                    i++;
                }

                ms.TriangleData.Add(tri);
            }
            

            Out.MeshSources.Add(ms);

            return Out;
        }

        public static VertexSource SourceFromArray(string name,List<float> data, int stride,string paramnames,string semantic)
        {
            VertexSource Out = new VertexSource();

            Out.semantic = semantic;

            Out.ID = name;

            Out.VertexData = new FloatArray(data);

            Out.VertexData.ID = Out.ID + "-array";

            VertexAccessor parems = new VertexAccessor();

            parems.Source = "#" + Out.VertexData.ID;
            parems.Count = data.Count / stride;
            parems.Stride = stride;

            for (int i = 0; i < stride; i++)
            {
                VertexParem parem = new VertexParem();

                parem.Name = paramnames.Split(' ')[i];
                parem.Type = "float";

                parems.Perams.Add(parem);
            }

            VertexTechnique vertexTechnique = new VertexTechnique();

            vertexTechnique.VertexAccessors.Add(parems);

            Out.Technique = vertexTechnique;

            return Out;
        }

        public static Node FromTransformNode(TransformNode node)
        {
            Node Out = new Node();

            for (int i = 0; i < node.ChildCount;i++)
            {
                Out.ChildNodes.Add(FromTransformNode(node.GetChild(i)));
            }

            Out.ID = "node-" + node.Name;
            Out.Name = node.Name;
            Out.Sid = "joint" + node.Index;
            Out.Type = "JOINT";

            matrix4 transform = new matrix4();

            transform.Name = "matrix";
            transform.Sid = "transform";
            transform.transform = node.LocalTransform;

            Out.Transforms.Add(transform);

            return Out;
        }
    }
}
