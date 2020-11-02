using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.Graphics.Structs;
using SimpleGameEngine.IO.Collada;
using Smash.Game;
using Smash.GraphicWrangler;
using SmashLabs.IO;
using SmashLabs.IO.Parsables.Material;
using SmashLabs.IO.Parsables.Mesh;
using SmashLabs.IO.Parsables.Model;
using SmashLabs.IO.Parsables.Skeleton;
using SmashLabs.Structs;
using SmashLabs.Tools;
using SmashLabs.Tools.Accessors;
using SmashLabs.Tools.Exporter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.IO
{
    public static class Parsers
    {
        public static RenderSkeleton ParseSkeleton(byte[] buffer)
        {
            RenderSkeleton Out = new RenderSkeleton();

            BufferReader reader = new BufferReader(buffer);

            return Out;
        }

        public static void LoadAllShaders()
        {
            BufferReader shadercollection = new BufferReader(File.ReadAllBytes("shadercollection.fs"));

            shadercollection.Seek(8);

            int count = shadercollection.ReadInt();

            for (int i = 0; i < count; i++)
            {
                string name = shadercollection.ReadStringOffset();

                RenderShader Out = LoadShader(FileLoader.ReadFileBytes("custom\\" + name));

                Out.Source = "custom\\" + name;

                RenderShader.AllShaders.Add(name.Split('.')[0], Out);
            }
        }

        public static RenderShader LoadShader(byte[] data)
        {
            RenderShader Out = new RenderShader();

            BufferReader reader = new BufferReader(data);

            int count = reader.ReadInt();

            for (int i = 0; i < count; i++)
            {
                ShaderSource temp = new ShaderSource();

                temp.Source = reader.ReadStringOffset();
                temp.Type = (ShaderType)reader.ReadInt();

                Out.Sources.Add(temp);
            }

            return Out;
        }

        public static void ReloadShaders()
        {
            throw new NotImplementedException();

            string[] Sources = RenderShader.AllShaders.Keys.ToArray();

            foreach (string source in Sources)
            {
                byte[] Data = FileLoader.ReadFileBytes(RenderShader.AllShaders[source].Source);

                RenderShader shad = LoadShader(Data);

                RenderShader.AllShaders[source].Sources = shad.Sources;

                RenderShader.AllShaders[source].CompileSources();
            }
        }

        public static RenderModel LoadModel(string root)
        {
            try
            {
                RenderModel Out = new RenderModel();

                LDOM model = (LDOM)IParsable.FromFile(FileLoader.GetPath(root + "\\model.numdlb"));
                LEKS skel = (LEKS)IParsable.FromFile(FileLoader.GetPath(root + "\\model.nusktb"));
                HSEM mesh = (HSEM)IParsable.FromFile(FileLoader.GetPath(root + "\\model.numshb"));
                LTAM matl = (LTAM)IParsable.FromFile(FileLoader.GetPath(root + "\\model.numatb"));

                Out.Skeleton = LoadSkeleton(skel);

                Out.MaterialKeys = LoadMaterials(matl, LoadTextures(root));

                Out.Meshes = ParseMeshCollection(model, skel, mesh, Out.MaterialKeys);

                foreach (SkinnedMeshRenderer rmesh in Out.Meshes)
                {
                    rmesh.BindedSkeleton = Out.Skeleton;

                    rmesh.Mesh.Name = rmesh.Name;

                    rmesh.Mesh.CalculateVertexTangent();
                }

                Out.BuildRenderKeys();

                return Out;
            }
            catch
            {
                return null;
            }
        }

        public static List<SkinnedMeshRenderer> ParseMeshCollection(LDOM model, LEKS skel,HSEM mesh,Dictionary<string,SmashMaterial> mats)
        {
            List<SkinnedMeshRenderer> Out = new List<SkinnedMeshRenderer>();

            VertexAccesor accesor = new VertexAccesor(mesh);
            RigAccessor rigAccessor = new RigAccessor(mesh);

            for (int i = 0; i < model.Entries.Length; i++)
            {
                SkinnedMeshRenderer outmesh = new SkinnedMeshRenderer();

                outmesh.Name = model.Entries[i].Name;

                outmesh.Mesh = new RenderMesh();

                outmesh.Mesh.IndexData = accesor.ReadIndiciesShort(mesh.Objects[i]);

                ExtendedSmashVertex[] vertexdata = ExtendedSmashVertex.ReadFullVerticies(accesor,rigAccessor,skel,mesh.Objects[i],out outmesh.Rigged);

                outmesh.ParentBoneName = mesh.Objects[i].ParentBoneName;

                outmesh.Mesh.VertexData = new RenderVertex[vertexdata.Length];

                for (int v = 0; v < vertexdata.Length; v++)
                {
                    outmesh.Mesh.VertexData[v] = Convert<RenderVertex, ExtendedSmashVertex>(vertexdata[v]);
                }

                outmesh.Material = mats[model.Entries[i].MaterialName];

                Out.Add(outmesh);
            }

            return Out;
        }

        public static RenderSkeleton LoadSkeleton(LEKS skeleton)
        {
            RenderSkeleton Out = new RenderSkeleton();

            Out.RootNode = new TransformNode();

            Out.Nodes = new TransformNode[skeleton.EntryCount];

            Out.InverseWorldTransforms = new OpenTK.Matrix4[skeleton.EntryCount];
            Out.WorldTransformCache = new OpenTK.Matrix4[skeleton.EntryCount];

            for (int i = 0; i < skeleton.EntryCount; i++)
            {
                Out.Nodes[i] = new TransformNode();

                Out.Nodes[i].Name = skeleton.BoneEntries[i].Name;
                Out.Nodes[i].LocalTransform = Convert<OpenTK.Matrix4, SmashLabs.Structs.Matrix4>(skeleton.BoneEntries[i].LocalTransform);
                Out.InverseWorldTransforms[i] = Convert<OpenTK.Matrix4, SmashLabs.Structs.Matrix4>(skeleton.BoneEntries[i].InverseWorldTransform);
                Out.Nodes[i].Index = skeleton.BoneEntries[i].Index;
                Out.Nodes[i].ParenIndex = skeleton.BoneEntries[i].ParentIndex;
            }

            foreach (TransformNode node in Out.Nodes)
            {
                if (node.ParenIndex != -1)
                {
                    node.Parent = Out.Nodes[node.ParenIndex];
                }
                else
                {
                    node.Parent = Out.RootNode;
                }
            }

            Out.SetIdentities();

            return Out;
        }

        public static Dictionary<string,RenderTexture2D> LoadTextures(string path)
        {
            Dictionary<string, RenderTexture2D> Out = new Dictionary<string, RenderTexture2D>();

            string[] files = FileLoader.GetFiles(path);

            foreach (string file in files)
            {
                if (file.Contains(".nutexb"))
                {
                    string name = Path.GetFileName(file.Split('.')[0]);

                    Out.Add(name,LoadTexture(FileLoader.ReadFileBytes(file)));
                }
            }

            return Out;
        }

        public static RenderTexture2D LoadTexture(byte[] Data)
        {
            RenderTexture2D Out = new RenderTexture2D(BitmapFromBuffer(Data));

            return Out;
        }

        public unsafe static RenderTexture2D LoadRawTexture(byte[] Data)
        {
            fixed (byte* data = Data)
            {
                UnmanagedMemoryStream str = new UnmanagedMemoryStream(data, Data.Length);

                Bitmap Out = new Bitmap(str);

                return new RenderTexture2D(Out);
            }
        }

        public unsafe static Bitmap BitmapFromBuffer(byte[] Data)
        { 
            fixed (byte* data = Data)
            {
                UnmanagedMemoryStream str = new UnmanagedMemoryStream(&data[8],Data.Length - 8);

                Bitmap Out = new Bitmap(str);

                return Out;
            }
        }

        public static RenderTexture3D CubemapFromName(string name)
        {
            List<Bitmap> Data = new List<Bitmap>();

            for (int i = 0; i < 6; i++)
            {
                Data.Add(BitmapFromBuffer(FileLoader.ReadFileBytes(@"custom\CubeMaps\" + name + ".png." + i + ".ctext")));
            }

            return new RenderTexture3D(Data);
        }

        public static Dictionary<string, SmashMaterial> LoadMaterials(LTAM material,Dictionary<string, RenderTexture2D> texturepak)
        {
            Dictionary<string, SmashMaterial> Out = new Dictionary<string, SmashMaterial>();

            foreach (MaterialEntry entry in material.Entries)
            {
                SmashMaterial outmat = new SmashMaterial();

                if (Scene.Skybox != null)
                {
                    outmat.Textures[14] = Scene.Skybox.TextureData;
                }

                foreach (SmashLabs.IO.Parsables.Material.MaterialAttribute attribute in entry.Attributes)
                {
                    if (!attribute.paramID.ToString().Contains("Texture"))
                    {
                        SimpleGameEngine.Graphics.Assets.MaterialAttribute outmatatt = new SimpleGameEngine.Graphics.Assets.MaterialAttribute();

                        outmatatt.Name = attribute.paramID.ToString();
                        outmatatt.Type = attribute.DataType.ToString();
                        outmatatt.Data = attribute.DataObject;

                        outmat.Attributes.Add(outmatatt);
                    }
                    else
                    {
                        if (texturepak.ContainsKey((string)attribute.DataObject))
                        {
                            outmat.Textures[attribute.paramID - SmashLabs.IO.Parsables.Material.Enums.ParamID.Texture0] = texturepak[(string)attribute.DataObject];
                        }
                    }
                }

                Out.Add(entry.Label,outmat);
            }

            return Out;
        }

        public static unsafe T Convert<T,I>(I data) where T: unmanaged where I: unmanaged
        {
            if (sizeof(T) != sizeof(I))
                throw new Exception("Size must be the same.");

            return *(T*)&data;
        }

        public static Animator LoadAnimationCollection(string root)
        {
            string[] files = FileLoader.GetFiles(FileLoader.RootPath + root);

            Animator Out = new Animator();

            foreach (string anim in files)
            {
                if (anim.Contains(".nuanmb"))
                {
                    RenderAnimation animation = LoadAnimation(FileLoader.ReadFileBytes(anim));

                    string name = SplitString(3,Path.GetFileName(anim)).Split('.')[0];

                    if (Out.Animations.ContainsKey(name))
                        name += "_1";
                    
                    Out.Animations.Add(name,animation);
                }
            }

            return Out;
        }

        public static Animator CoppyAnimator(Animator anim)
        {
            Animator Out = new Animator();

            Out.fighterref = anim.fighterref;

            Out.Animations = anim.Animations;

            return Out;
        }

        public static RenderAnimation LoadAnimation(byte[] data)
        {
            BufferReader reader = new BufferReader(data);

            RenderAnimation Out = new RenderAnimation();

            reader.Seek(8);

            Out.FrameCount = reader.ReadInt();

            int nodecount = reader.ReadInt();

            for (int i = 0; i < nodecount; i++)
            {
                string name = reader.ReadStringOffset();

                BufferArrayPointer pointer = reader.ReadArrayPointer();

                for (int n = 0; n < pointer.ElementCount; n++)
                {
                    AnimationNode node = new AnimationNode();

                    node.Name = name;

                    node.FrameCount = reader.ReadShort();
                    node.Type = (TrackType)reader.ReadInt();

                    long offset = reader.ReadOffset();
                    long last = reader.BufferLocation;

                    reader.Seek(offset);

                    switch (node.Type)
                    {
                        case TrackType.Transform: node.Data = reader.ReadObject<AnimationTransform>(node.FrameCount); break;
                        case TrackType.Visibility: node.Data = reader.ReadObject<bool>(node.FrameCount); break;
                    }

                    reader.Seek(last);

                    Out.Nodes.Add(node);
                }

                pointer.End();
            }

            Out.BuildNodeKeys();

            return Out;
        }

        public static string SplitString(int index, string source)
        {
            string Out = "";

            for (int i = index; i < source.Length; i++)
            {
                Out += source[i];
            }

            return Out;
        }

        public static RenderModel LoadCollada(ColladaFile file)
        {
            RenderModel Out = new RenderModel();

            return Out;
        }


        static Dictionary<string, RenderFont> FontBuffer = new Dictionary<string, RenderFont>();
        public static RenderFont LoadFont(string fontfolder)
        {
            if (!FontBuffer.ContainsKey(fontfolder))
            {
                FontBuffer.Add(fontfolder, new RenderFont(LoadRawTexture(FileLoader.ReadFileBytes(fontfolder + "\\font.png")), FileLoader.ReadWholeFile(fontfolder + "\\font.fnt")));
            }

            return FontBuffer[fontfolder];
        }
    }
}
