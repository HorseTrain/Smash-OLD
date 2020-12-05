using SimpleGameEngine.IO.XML;
using SmashLabs.IO;
using SmashLabs.IO.Parsables.Animation;
using SmashLabs.IO.Parsables.Material;
using SmashLabs.IO.Parsables.Mesh;
using SmashLabs.IO.Parsables.Model;
using SmashLabs.IO.Parsables.Skeleton;
using SmashLabs.Structs;
using SmashLabs.Tools.Accessors;
using SmashLabs.Tools.Accessors.Animation;
using SmashLabs.Tools.Exporter;
using SmashLabs.Tools.Exporters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter
{
    struct FileHeader
    {
        public long Magic;

        public unsafe FileHeader(string magic)
        {
            Magic = 0;

            byte[] temp = new byte[magic.Length];

            for (int i = 0; i < magic.Length; i++)
            {
                temp[i] = (byte)magic[i];
            }

            fixed (byte* t = temp)
            {
                Magic = *(long*)t;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] Args)
        {
            if (Args != null)
            {
                if (Args.Length == 0)
                {
                    BatchExportShaders(@"D:\Programming\Projects\Assets\fighter\Shaders\", @"D:\Programming\SmashAssets\custom\");

                    BatchExportShaders(@"D:\Programming\Projects\Assets\fighter\Shaders\", @"C:\Users\Raymond\source\repos\Smash\Smash\bin\Debug\Assets\custom\");
                }
                else
                {
                    BatchExportFile(Args[0],Args[1]);
                }
            }

            // BatchExportCubeMaps(@"D:\Programming\Projects\Assets\fighter\Maps\", @"D:\Programming\SmashAssets\custom\CubeMaps\");

            //Console.WriteLine("smh");

           // BatchExportFile(@"D:\Programming\WorkingAcos\CrossArc\bin\Debug\root\", @"D:\Programming\WorkingAcos\CrossArc\bin\Debug\Temp.txt", @"D:\Programming\SmashAssets\");

            /*
            Console.WriteLine(Args.Length);

            switch (Args[0])
            {
                case "Coppy": BatchExportFile(Args[1] + "\\",Args[2],Args[3] + "\\"); break;
            }
            */
        }

        public static void BatchExportCubeMaps(string Path,string Out)
        {
            string[] maps = Directory.GetFiles(Path);

            foreach (string map in maps)
            {
                if (map.EndsWith(".png") || map.EndsWith(".jpg"))
                {
                    Bitmap Map = new Bitmap(map);

                    int size = Map.Width / 6;

                    for (int i = 0; i < 6; i++)
                    {
                        Bitmap Face = new Bitmap(Map.Height, size);

                        for (int x = 0; x < Face.Width; x++)
                        {
                            for (int y = 0; y < Face.Height; y++)
                            {
                                Face.SetPixel(x,y,Map.GetPixel(x + (i * size),y));
                            }
                        }

                        Directory.CreateDirectory(Out);

                        //Face.Save(Out + System.IO.Path.GetFileName(map) + ".png");

                        File.WriteAllBytes(Out + System.IO.Path.GetFileName(map) + "." + i + ".ctext", ExportTexture(Face).FinalBuffer());

                        //Face.Save(Out + System.IO.Path.GetFileName(map) + "." + i + ".png");
                    }
                }
            }
        }

        public static void BatchExportFile(string dir,string Out)
        {
            if (!Out.EndsWith("\\"))
                Out += "\\";

            Folder temp = new Folder(dir);

            foreach (string folder in Folder.outs)
            {
                string[] files = Directory.GetFiles(folder);

                foreach (string file in files)
                {
                    string odir = Out + SplitString(dir.Length,file);

                    Directory.CreateDirectory(Path.GetDirectoryName(odir));

                    if (file.EndsWith(".nutexb"))
                    {
                        ExportTexture(NUTEXTB.TextureLoader.LoadNUTEXTB(file)).Export(odir);
                    }
                    else if (file.EndsWith(".nuanmb"))
                    {
                        ExportAnimation((MINA)IParsable.FromFile(file)).Export(odir);
                    }
                    else
                    {
                        if (File.Exists(odir))
                            File.Delete(odir);

                        File.Copy(file, odir);
                    }
                }
            }
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

        public static void BatchExportShaders(string folder,string Out)
        {
            string[] dirs = Directory.GetDirectories(folder);

            ExportableBufferCollection shadercollection = new ExportableBufferCollection();

            ByteBuffer Header = shadercollection.AddBuffer();
            ByteBuffer paths = shadercollection.AddBuffer();
            ByteBuffer strings = shadercollection.AddBuffer();

            Header.AddObject(new FileHeader("CSHADCOL"));

            paths.AddObject(dirs.Length);

            foreach (string dir in dirs)
            {
                string[] shaderparts = Directory.GetFiles(dir);

                ExportableBufferCollection shaders = new ExportableBufferCollection();

                ByteBuffer pointers = shaders.AddBuffer();
                ByteBuffer stringbuffer = shaders.AddBuffer();

                pointers.AddObject(shaderparts.Length);

                shadercollection.AddStringWithPointer(Path.GetFileName(dir) + ".shad",paths,strings,false);

                foreach (string shader in shaderparts)
                {
                    int type = int.Parse(Path.GetFileName(shader).Split('.')[0]);

                    shaders.AddStringWithPointer(File.ReadAllText(shader),pointers,stringbuffer,false);
                    pointers.AddObject(type);
                }

                Directory.CreateDirectory(Out);

                File.WriteAllBytes(Out + Path.GetFileName(dir) + ".shad",shaders.FinalBuffer());
            }

            File.WriteAllBytes("shadercollection.fs",shadercollection.FinalBuffer());
        }

        /*
        public static ExportableBufferCollection ExportSkeleton(LEKS skeleton)
        {
            ExportableBufferCollection Out = new ExportableBufferCollection();

            ByteBuffer Header = Out.AddBuffer();

            ByteBuffer PointerBuffer = Out.AddBuffer();

            ByteBuffer DataBuffer = Out.AddBuffer();

            Header.AddObject(new FileHeader("CCSKEL"));

            Out.AddArrayPointer(Header,DataBuffer,skeleton.BoneEntries.Length);
            Out.AddPointer(Header,PointerBuffer);

            foreach (BoneEntry entry in skeleton.BoneEntries)
            {
                DataBuffer.AddObject(entry.LocalTransform);
            }

            foreach (BoneEntry entry in skeleton.BoneEntries)
            {
                PointerBuffer.AddObject(entry.Index);
                PointerBuffer.AddObject(entry.ParentIndex);
                Out.AddStringWithPointer(entry.Name,PointerBuffer,DataBuffer,false);
            }

            return Out;
        }

        public static ExportableBufferCollection ExportMesh(HSEM meshfile, LEKS skeleton)
        {
            ExportableBufferCollection Out = new ExportableBufferCollection();

            VertexAccesor accesor = new VertexAccesor(meshfile);
            RigAccessor raccesor = new RigAccessor(meshfile);

            ByteBuffer Header = Out.AddBuffer();

            ByteBuffer MeshObjectPointers = Out.AddBuffer();

            ByteBuffer MeshData = Out.AddBuffer();

            ByteBuffer StringBuffer = Out.AddBuffer();

            Header.AddObject(new FileHeader("CMESH"));

            Out.AddArrayPointer(Header,MeshObjectPointers,meshfile.Objects.Length);

            foreach (MeshObject Object in meshfile.Objects)
            {
                Out.AddStringWithPointer(Object.Name,MeshObjectPointers,StringBuffer,false);
                Out.AddStringWithPointer(Object.ParentBoneName, MeshObjectPointers, StringBuffer, false);

                Out.AddArrayPointer(MeshObjectPointers,MeshData,Object.MeshData.IndexCount);
                MeshData.AddArray(accesor.ReadIndiciesShort(Object));

                bool rigged = false;

                Out.AddArrayPointer(MeshObjectPointers, MeshData, Object.MeshData.VertexCount);
                MeshData.AddArray(ExtendedSmashVertex.ReadFullVerticies(accesor,raccesor,skeleton,Object,out rigged));

                MeshData.AddObject(rigged);
            }

            return Out;
        }
        */



        enum TrackType
        {
            Transform,
            Visibility
        }

        public static ExportableBufferCollection ExportAnimation(MINA animation)
        {
            ExportableBufferCollection Out = new ExportableBufferCollection();

            ByteBuffer Header = Out.AddBuffer();

            ByteBuffer NodeBuffer = Out.AddBuffer();

            ByteBuffer TrackBuffer = Out.AddBuffer();

            ByteBuffer AnimtionBuffer = Out.AddBuffer();

            Header.AddObject(new FileHeader("CANIM"));

            Header.AddObject(animation.FrameCount);

            AnimationTrackAccessor accesor = new AnimationTrackAccessor(animation);

            int tcount = 0;

            foreach (AnimationGroup group in animation.Animations)
            {
                foreach (AnimationNode node in group.Nodes)
                {
                    tcount++;

                    Out.AddStringWithPointer(node.Name,NodeBuffer, AnimtionBuffer, false);

                    Out.AddArrayPointer(NodeBuffer, TrackBuffer,node.Tracks.Length);

                    foreach (AnimationTrack track in node.Tracks)
                    {
                        TrackBuffer.AddObject((short)track.FrameCount);

                        if (track.Name == "Transform")
                        {
                            TrackBuffer.AddObject(0);
                        }    
                        else if (track.Name == "Visibility")
                        {
                            TrackBuffer.AddObject(1);
                        }
                        else
                        {
                            TrackBuffer.AddObject(2);
                        }

                        Out.AddPointer(TrackBuffer, AnimtionBuffer);

                        object[] Data = accesor.ReadTrack(track);

                        foreach (object d in Data)
                        {
                            switch (track.Name)
                            {
                                case "Transform": AnimtionBuffer.AddObject((AnimationTransform)d); break;
                                case "Visibility": AnimtionBuffer.AddObject((bool)d); break;
                            }
                        }
                    }
                }
            }

            Header.AddObject(tcount);

            return Out;
        }

        /*
        public static ExportableBufferCollection ExportMaterial(LTAM material)
        {
            ExportableBufferCollection Out = new ExportableBufferCollection();

            return Out;
        }

        */

        public static ExportableBufferCollection ExportTexture(string file)
        {
            ExportableBufferCollection Out = new ExportableBufferCollection();

            ByteBuffer header = Out.AddBuffer();

            ByteBuffer data = Out.AddBuffer();

            header.AddObject(new FileHeader("CTEXT"));

            NUTEXTB.TextureLoader.LoadNUTEXTB(file).Save("temp.png");

            data.AddRange(File.ReadAllBytes("temp.png"));

            return Out;
        }

        public static ExportableBufferCollection ExportTexture(Bitmap map)
        {
            ExportableBufferCollection Out = new ExportableBufferCollection();

            ByteBuffer header = Out.AddBuffer();

            ByteBuffer data = Out.AddBuffer();

            header.AddObject(new FileHeader("CTEXT"));

            map.Save("temp.png");

            data.AddRange(File.ReadAllBytes("temp.png"));

            return Out;
        }

        /*
        public static ExportableBufferCollection ExportModel(LDOM model)
        {
            ExportableBufferCollection Out = new ExportableBufferCollection();

            ByteBuffer Header = Out.AddBuffer();

            ByteBuffer PointerBuffer = Out.AddBuffer();

            ByteBuffer StringBuffer = Out.AddBuffer();

            Out.AddArrayPointer(Header,PointerBuffer,model.Entries.Length);

            Out.AddStringWithPointer(model.SkeletonFileName,Header,StringBuffer,false);
            Out.AddStringWithPointer(model.MaterialFileNames[0], Header, StringBuffer, false);
            Out.AddStringWithPointer(model.MeshCollectionFileName, Header, StringBuffer, false);

            foreach (ModelEntry entry in model.Entries)
            {
                Out.AddStringWithPointer(entry.Name,PointerBuffer,StringBuffer,false);
                Out.AddStringWithPointer(entry.MaterialName, PointerBuffer, StringBuffer, false);
            }

            return Out;
        }
        */

        public class Folder
        {
            public static List<string> outs = new List<string>();

            public Folder(string name)
            {
                string[] files = Directory.GetDirectories(name);

                foreach (string file in files)
                {
                    new Folder(file);
                }

                outs.Add(name);
            }
        }
    }
}
