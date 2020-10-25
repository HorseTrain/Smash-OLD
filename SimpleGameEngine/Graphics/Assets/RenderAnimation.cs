using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Assets
{
    public enum TrackType
    {
        Transform,
        Visibility,
        UNK
    }
    public class AnimationNode
    {
        public string Name { get; set; }
        public TrackType Type { get; set; }
        public int FrameCount { get; set; }
        public object Data { get; set; }
        public T GetKey<T>(int index) where T: unmanaged
        {
            return ((T[])Data)[index];
        }
        
        public Tuple<T,T> GetCurrentNextKey<T>(int index) where T : unmanaged
        {
            if (index >= 0)
            {
                if (index + 1 < FrameCount)
                {
                    return new Tuple<T, T>(GetKey<T>(index), GetKey<T>(index + 1));
                }
                else
                {
                    return new Tuple<T, T>(GetKey<T>(index), GetKey<T>(FrameCount - 1));
                }
            }
            else
            {
                return new Tuple<T, T>(new T(),new T());
            }
        }
    }
    public struct AnimationTransform
    {
        public Vector3 Scale;
        public Quaternion Rotation;
        public Vector3 Position;
        public float Cscale;

        public override string ToString()
        {
            return Scale + "\n" + Rotation + "\n" + Position + "\n";
        }
    }
    public class RenderAnimation
    {
        public string Name { get; set; }
        public int FrameCount { get; set; }
        public List<AnimationNode> Nodes { get; set; } = new List<AnimationNode>();
        public Dictionary<string,AnimationNode> NodeKeys { get; set; }
        public void BuildNodeKeys()
        {
            NodeKeys = new Dictionary<string, AnimationNode>();

            foreach (AnimationNode node in Nodes)
            {
                if (!NodeKeys.ContainsKey(node.Name))
                    NodeKeys.Add(node.Name,node);
            }
        }
    }
}
