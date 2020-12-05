using OpenTK;
using OpenTK.Graphics.OpenGL;
using SimpleGameEngine.IO.Collada.Scene;
using SimpleGameEngine.IO.XML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Assets
{
    public class TransformNode
    {
        public RenderSkeleton BindedSkeleton { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public int ParenIndex { get; set; }
        public Vector3 LocalPosition { get; set; } 
        public Quaternion LocalRotation { get; set; } = Quaternion.Identity;
        public Vector3 LocalScale { get; set; } = new Vector3(1);
        public Vector3 WantedPosition { get; set; }

        public Matrix4 LocalTransform
        {
            get => TRS(LocalPosition, LocalRotation, LocalScale);

            set
            {
                LocalPosition = value.ExtractTranslation();
                LocalRotation = value.ExtractRotation();
                LocalScale = value.ExtractScale();
            }
        }

        public static Matrix4 TRS(Vector3 translation,Quaternion rotation,Vector3 scale)
        {
            return Matrix4.CreateScale(scale) * Matrix4.CreateFromQuaternion(rotation) * Matrix4.CreateTranslation(translation);
        }

        TransformNode parent;
        public TransformNode Parent
        {
            get => parent;

            set
            {
                if (parent != null)
                {
                    parent.Children.Remove(this);
                }

                parent = value;

                parent.Children.Add(this);
            }
        }
        List<TransformNode> Children { get; set; } = new List<TransformNode>();
        public int ChildCount => Children.Count;
        public TransformNode GetChild(int index)
        {
            return Children[index];
        }

        public Matrix4 WorldTransform //Slow lmao 
        {
            get
            {
                if (parent == null)
                {
                    return LocalTransform;
                }
                else
                {
                    return MultMatrix(LocalTransform, Parent.WorldTransform);
                }
            }
        }

        public static long MatrixCalculationFrame { get; set; }
        public static long MatrixCalculationsPerFrame { get; set; }
        public long LastCalculationFrame { get; set; }
        Matrix4 wptemp { get; set; }

        public Matrix4 MultMatrix(Matrix4 mat1, Matrix4 mat2)
        {
            if (LastCalculationFrame != MatrixCalculationFrame)
            {
                wptemp = mat1 * mat2;

                LastCalculationFrame = MatrixCalculationFrame;
            }

            return wptemp;
        }

        public void SetNodeTransform(AnimationTransform transform)
        {
            LocalPosition = transform.Position;
            LocalRotation = transform.Rotation;
            LocalScale = transform.Scale;
        }

        public AnimationTransform GetAnimationNode()
        {
            return new AnimationTransform()
            {
                Position = LocalPosition,
                Rotation = LocalRotation,
                Scale = LocalScale
            };
        }

        public Vector3 WorldPosition => WorldTransform.ExtractTranslation();
    }

    public unsafe class RenderSkeleton : XMLParsable
    {
        public UniformBufferObject UniformBuffer { get; set; } = new UniformBufferObject("SkeletonBuffer", 300 * sizeof(Matrix4));
        public TransformNode RootNode { get; set; }
        public TransformNode[] Nodes { get; set; }
        Matrix4[] Identities { get; set; }
        public Matrix4[] InverseWorldTransforms { get; set; }
        public Matrix4[] WorldTransformCache { get; set; }
        Dictionary<string, TransformNode> NodeKeys { get; set; }
        public CullFaceMode CullMode { get; set; }
        public RenderSkeleton()
        {

        }

        public void SetIdentities()
        {
            Identities = new Matrix4[Nodes.Length];

            for (int i = 0; i < Identities.Length; i++)
            {
                Identities[i] = Nodes[i].LocalTransform;
            }
        }

        public void BuildKeys()
        {
            NodeKeys = new Dictionary<string, TransformNode>();

            foreach (TransformNode node in Nodes)
            {
                NodeKeys.Add(node.Name,node);

                node.BindedSkeleton = this;
            }
        }

        public TransformNode GetNode(string name)
        {
            if (NodeKeys == null)
            {
                BuildKeys();
            }

            if (name != null)
            if (NodeKeys.ContainsKey(name))
            {
                return NodeKeys[name];
            }

            return null;
        }

        public void Update()
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                WorldTransformCache[i] = Nodes[i].WorldTransform;

                ((Matrix4*)UniformBuffer.Location)[i] = InverseWorldTransforms[i] * WorldTransformCache[i];
            }

            UniformBuffer.UpdateBuffer();

            GetCullMode();
        }

        public void BindToMaterial(RenderMaterial material)
        {
            UniformBuffer.BindToMaterial(material);
        }

        public void GetCullMode()
        {
            Vector3 scale = RootNode.LocalScale;

            int mode = 1;

            for (int i = 0; i < 3; i++)
            {
                if (scale[i] < 0)
                {
                    mode *= -1;
                }
            }

            if (mode == -1)
                CullMode = CullFaceMode.Front;
            else
                CullMode = CullFaceMode.Back;
        }

        public ref TransformNode this[int index] => ref Nodes[index];

        public static void GlobalUpdate()
        {
            TransformNode.MatrixCalculationFrame++;
        }

        public void IdentitySkeleton()
        {
            if (Identities != null)
            {
                for (int i = 0; i < Identities.Length; i++)
                    Nodes[i].LocalTransform = Identities[i];
            }
        }

        public Matrix4 GetMatrixIdentity(string name)
        {
            return Identities[GetNode(name).Index];
        }
    }
}
