using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SimpleGameEngine.Graphics.Assets
{
    public class MaterialAttribute
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object Data { get; set; }
    }

    public class RenderMaterial
    {
        public string Name { get; set; }
        public RenderShader RenderShader { get; set; }

        public List<MaterialAttribute> Attributes { get; set; } = new List<MaterialAttribute>();
        Dictionary<string, int> ShaderUniformLocations { get; set; } = new Dictionary<string, int>();
        Dictionary<string, int> ShaderBlockUniformLocations { get; set; } = new Dictionary<string, int>();
        public Texture[] Textures { get; set; } = new Texture[20];

        public int GetUniformLocation(string name)
        {
            if (RenderShader != null)
            {
                RenderShader.Use();

                if (!ShaderUniformLocations.ContainsKey(name))
                {
                    ShaderUniformLocations.Add(name, GL.GetUniformLocation(RenderShader.Handler, name));
                }

                return ShaderUniformLocations[name];
            }
            else
            {
                return -1;
            }
        }

        public int GetUniformBlockIndex(string name)
        {
            if (RenderShader != null)
            {
                RenderShader.Use();

                if (!ShaderBlockUniformLocations.ContainsKey(name))
                {
                    ShaderBlockUniformLocations.Add(name, GL.GetUniformBlockIndex(RenderShader.Handler, name));
                }

                return ShaderBlockUniformLocations[name];
            }
            else
            {
                return -1;
            }
        }

        public void UniformInt(string name,int value) => GL.Uniform1(GetUniformLocation(name), value);
        public void UniformFloat(string name,float value) => GL.Uniform1(GetUniformLocation(name), value);
        public void UniformVector2(string name, Vector2 value) => GL.Uniform2(GetUniformLocation(name),value);
        public void UniformVector3(string name, Vector3 value) => GL.Uniform3(GetUniformLocation(name), value);
        public void UniformVector4(string name, Vector4 value) => GL.Uniform4(GetUniformLocation(name), value);
        public void UniformMat4(string name, Matrix4 value,bool transpose = false) => GL.UniformMatrix4(GetUniformLocation(name),transpose, ref value);

        public virtual void UploadUniforms()
        {

        }

        public void UseTextures()
        {
            for (int i = 0; i < Textures.Length; i++)
            {
                UniformInt("Texture" + i, i);

                if (Textures[i] != null)
                {
                    Textures[i].Use(TextureUnit.Texture0 + i);
                }
            }
        }

        public void UseMaterial(int shaderindex = 0)
        {
            if (RenderShader != null)
            {
                UploadUniforms();

                UseTextures();

                RenderShader.Use();
            }     
            else
            {
                GL.UseProgram(0);
            }
        }
    }
}
