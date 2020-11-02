using SimpleGameEngine.Graphics.Structs;
using OpenTK.Graphics.OpenGL;
using System;
using System.Runtime.InteropServices;
using OpenTK;
using System.Collections.Generic;

namespace SimpleGameEngine.Graphics.Assets
{
    public unsafe class RenderMesh
    {
        public string Name { get; set; }
        public BeginMode RenderMode { get; set; } = BeginMode.Triangles;
        public ushort[] IndexData { get; set; }
        public RenderVertex[] VertexData { get; set; }
        public bool Uploaded { get; private set; }
        public int VAO { get; private set; } = -1;
        public int IBO { get; private set; } = -1;
        public int VBO { get; private set; } = -1;
        public void Upload()
        {
            if (!Uploaded)
            {
                VAO = GL.GenVertexArray();

                IBO = GL.GenBuffer();
                VBO = GL.GenBuffer();

                GL.BindVertexArray(VAO);

                GL.BindBuffer(BufferTarget.ElementArrayBuffer,IBO);
                GL.BufferData(BufferTarget.ElementArrayBuffer,IndexData.Length * sizeof(ushort),IndexData,BufferUsageHint.StaticDraw);

                GL.BindBuffer(BufferTarget.ArrayBuffer,VBO);
                GL.BufferData(BufferTarget.ArrayBuffer,VertexData.Length * sizeof(RenderVertex),VertexData,BufferUsageHint.StaticDraw);

                VertexAttribArray(0, 3, (int)VertexAttribPointerType.Float, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex),"VertexPosition"));
                VertexAttribArray(1, 3, (int)VertexAttribPointerType.Float, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex), "VertexNormal"));
                VertexAttribArray(2, 3, (int)VertexAttribPointerType.Float, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex), "VertexTangent"));

                VertexAttribArray(3, 2, (int)VertexAttribPointerType.Float, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex), "VertexUV"));
                VertexAttribArray(4, 2, (int)VertexAttribPointerType.Float, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex), "VertexUV1"));

                VertexAttribArray(5, 4, (int)VertexAttribPointerType.Float, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex), "VertexColor"));
                VertexAttribArray(6, 4, (int)VertexAttribPointerType.Float, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex), "VertexWeight"));
                VertexAttribArray(7, 4, (int)VertexAttribPointerType.Int, sizeof(RenderVertex), Marshal.OffsetOf(typeof(RenderVertex), "VertexWeightID"));
            }

            Uploaded = true;
        }

        public void Bind()
        {
            Upload();

            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);
        }

        public void GenericDraw()
        {
            Upload();

            Bind();

            GL.DrawElements(RenderMode,IndexData.Length,DrawElementsType.UnsignedShort,0);
        }

        public static void VertexAttribArray(int index, int size, int Type, int stride,IntPtr offset)
        {
            if (Type <= (int)VertexAttribPointerType.UnsignedInt)
            {
                GL.VertexAttribIPointer(index,size,(VertexAttribIntegerType)Type,stride,offset);
            }
            else
            {
                GL.VertexAttribPointer(index,size,(VertexAttribPointerType)Type,false,stride,offset);
            }

            GL.EnableVertexAttribArray(index);
        }
        
        ~RenderMesh()
        {
            if (Window.Active)
            {
                if (Uploaded)
                {
                    if (VAO != -1)
                    GL.DeleteVertexArray(VAO);

                    if (VBO != -1)
                    GL.DeleteBuffer(VBO);

                    if (IBO != -1)
                    GL.DeleteBuffer(IBO);
                }
            }
        }

        public static Dictionary<string, RenderMesh> GlobalMeshes = new Dictionary<string, RenderMesh>();

        public static RenderMesh Quad
        {
            get
            {
                if (!GlobalMeshes.ContainsKey("Quad"))
                {
                    RenderMesh Out = new RenderMesh();

                    Out.RenderMode = BeginMode.Quads;

                    Out.VertexData = new RenderVertex[]
                    {
                        new RenderVertex()
                        {
                            VertexPosition = new Vector3(0,0,0)
                        },

                        new RenderVertex()
                        {
                            VertexPosition = new Vector3(1,0,0)
                        },

                        new RenderVertex()
                        {
                            VertexPosition = new Vector3(1,1,0)
                        },

                        new RenderVertex()
                        {
                            VertexPosition = new Vector3(0,1,0)
                        }
                    };

                    Out.IndexData = new ushort[] { 0, 1, 2, 3 };

                    GlobalMeshes.Add("Quad", Out);
                }

                return GlobalMeshes["Quad"];
            }
        }

        public void CalculateVertexTangent()
        {
            for (int i = 0; i < IndexData.Length; i+= 3)
            {
                Vector3 tangent;
                Vector3 bitagent;

                SFGraphics.Utils.VectorUtils.GenerateTangentBitangent(
                    VertexData[IndexData[i]].VertexPosition, VertexData[IndexData[i + 1]].VertexPosition, VertexData[IndexData[i + 2]].VertexPosition,
                    VertexData[IndexData[i]].VertexUV1, VertexData[IndexData[i + 1]].VertexUV1, VertexData[IndexData[i + 2]].VertexUV1,
                    out tangent,
                    out bitagent
                    );

                VertexData[IndexData[i]].VertexTangent += tangent;
                VertexData[IndexData[i + 1]].VertexTangent += tangent;
                VertexData[IndexData[i + 2]].VertexTangent += tangent;
            }

            for (int i = 0; i < VertexData.Length; i++)
            {
                if (VertexData[i].VertexTangent.Length == 0)
                {
                    VertexData[i].VertexTangent = SFGraphics.Utils.VectorUtils.defaultTangent;
                }

                VertexData[i].VertexTangent.Normalize();
            }
        }

        public void CalculateNormals()
        {
            for (int i = 0; i < IndexData.Length; i += 3)
            {

            }
        }
    }
}

namespace SFGraphics.Utils
{
    /// <summary>
    /// Utility methods for normals, tangents, bitangents, and angle conversions
    /// </summary>
    public static class VectorUtils
    {
        /// <summary>
        /// The default value when the generated tangent would be a zero vector.
        /// </summary>
        public static Vector3 defaultTangent = new Vector3(1, 0, 0);

        /// <summary>
        /// The default value when the generated bitangent would be a zero vector.
        /// </summary>
        public static Vector3 defaultBitangent = new Vector3(0, 1, 0);

        /// <summary>
        /// Converts <paramref name="radians"/> to degrees.
        /// </summary>
        /// <param name="radians">The number of radians</param>
        /// <returns>The angle converted to degrees</returns>
        public static double GetDegrees(double radians)
        {
            return radians / Math.PI * 180.0;
        }

        /// <summary>
        /// Converts <paramref name="degrees"/> to radians.
        /// </summary>
        /// <param name="degrees">The number of degrees</param>
        /// <returns>The angle converted to radians</returns>
        public static double GetRadians(double degrees)
        {
            return degrees / 180.0 * Math.PI;
        }

        /// <summary>
        /// Uses the Gran-Schmidt method for returning a normalized copy 
        /// of <paramref name="vectorToOrthogonalize"/> that is orthogonal to <paramref name="source"/>.
        /// </summary>
        /// <param name="vectorToOrthogonalize">The vector to normalize</param>
        /// <param name="source">The vector to normalize against</param>
        /// <returns><paramref name="vectorToOrthogonalize"/> orthogonalized to <paramref name="source"/></returns>
        public static Vector3 Orthogonalize(Vector3 vectorToOrthogonalize, Vector3 source)
        {
            return Vector3.Normalize(vectorToOrthogonalize - source * Vector3.Dot(source, vectorToOrthogonalize));
        }

        /// <summary>
        /// Calculates <paramref name="tangent"/> and <paramref name="bitangent"/> 
        /// for a triangle face. 
        /// <para></para><para></para>
        /// Zero vectors are set to <see cref="defaultTangent"/> and <see cref="defaultBitangent"/>.
        /// </summary>
        /// <param name="v1">The position of the first vertex</param>
        /// <param name="v2">The position of the second vertex</param>
        /// <param name="v3">The position of the third vertex</param>
        /// <param name="uv1">The UV coordinates of the first vertex</param>
        /// <param name="uv2">The UV coordinates of the second vertex</param>
        /// <param name="uv3">The UV coordinates of the third vertex</param>
        /// <param name="tangent">The generated tangent vector</param>
        /// <param name="bitangent">The generated bitangent vector</param>
        public static void GenerateTangentBitangent(Vector3 v1, Vector3 v2, Vector3 v3,
                                                    Vector2 uv1, Vector2 uv2, Vector2 uv3,
                                                    out Vector3 tangent, out Vector3 bitangent)
        {
            Vector3 posA = v2 - v1;
            Vector3 posB = v3 - v1;

            Vector2 uvA = uv2 - uv1;
            Vector2 uvB = uv3 - uv1;

            float div = (uvA.X * uvB.Y - uvB.X * uvA.Y);

            // Fix +/- infinity from division by zero.
            float r = 1.0f;
            if (div != 0)
                r = 1.0f / div;

            tangent = CalculateTangent(posA, posB, uvA, uvB, r);
            bitangent = CalculateBitangent(posA, posB, uvA, uvB, r);

            // Set zero vectors to arbitrarily chosen orthogonal vectors.
            // This prevents unwanted black areas when rendering.
            if (tangent.Length == 0.0f)
                tangent = defaultTangent;
            if (bitangent.Length == 0.0f)
                bitangent = defaultBitangent;
        }

        /// <summary>
        /// Calculates the face normal of a triangle. The result is not normalized.
        /// A triangle facing the camera will have a positive normal when 
        /// the vertices are ordered counter-clockwise.
        /// </summary>
        /// <param name="v1">The position of the first vertex</param>
        /// <param name="v2">The position of the second vertex</param>
        /// <param name="v3">The position of the third vertex</param>
        /// <returns>The calculated face normal</returns>
        public static Vector3 CalculateNormal(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            Vector3 U = v2 - v1;
            Vector3 V = v3 - v1;

            // Don't normalize here, so surface area can be calculated. 
            return Vector3.Cross(U, V);
        }

        /// <summary>
        /// Calculates the W component for a 4 component tangent vector.
        /// The bitangent can be generated as <code>cross(N.xyz, T.xyz) * T.w</code>
        /// </summary>
        /// <param name="normal">The vertex normal</param>
        /// <param name="tangent"></param>
        /// <param name="bitangent"></param>
        /// <returns><code>1.0</code> if the bitangent should not be flipped or <code>-1.0</code> if the bitangent should be flipped</returns>
        public static float CalculateTangentW(Vector3 normal, Vector3 tangent, Vector3 bitangent)
        {
            // 0.0f should stil return 1.0f to avoid generating black bitangents.
            return Vector3.Dot(Vector3.Cross(tangent, bitangent), normal) >= 0.0f ? 1.0f : -1.0f;
        }

        private static Vector3 CalculateBitangent(Vector3 posA, Vector3 posB, Vector2 uvA, Vector2 uvB, float r)
        {
            Vector3 bitangent;
            float tX = uvA.X * posB.X - uvB.X * posA.X;
            float tY = uvA.X * posB.Y - uvB.X * posA.Y;
            float tZ = uvA.X * posB.Z - uvB.X * posA.Z;
            bitangent = new Vector3(tX, tY, tZ) * r;
            return bitangent;
        }

        private static Vector3 CalculateTangent(Vector3 posA, Vector3 posB, Vector2 uvA, Vector2 uvB, float r)
        {
            Vector3 tangent;
            float sX = uvB.Y * posA.X - uvA.Y * posB.X;
            float sY = uvB.Y * posA.Y - uvA.Y * posB.Y;
            float sZ = uvB.Y * posA.Z - uvA.Y * posB.Z;
            tangent = new Vector3(sX, sY, sZ) * r;
            return tangent;
        }
    }
}