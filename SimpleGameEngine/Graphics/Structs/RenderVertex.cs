using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Structs
{
    public struct RenderVertex
    {
        public Vector3 VertexPosition;
        public Vector3 VertexNormal;
        public Vector3 VertexTangent;
        public Vector2 VertexUV;
        public Vector2 VertexUV1;
        public Vector4 VertexColor;
        public Vector4 VertexWeight;
        public Vector4I VertexWeightID;
    }
}
