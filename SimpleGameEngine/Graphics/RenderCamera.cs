using OpenTK;
using SimpleGameEngine.Graphics.Assets;
using SimpleGameEngine.IO.Collada.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics
{
    public enum CameraType
    {
        Orthotgraphics,
        Perspective
    }
    public class RenderCamera
    {
        public static RenderCamera MainCamera { get; set; }
        public CameraType ViewType { get; set; } = CameraType.Perspective;
        public Vector3 CameraPosition;
        public float Pitch { get; set; } = 0;
        public float Yaw { get; set; } = 0;
        public Quaternion CameraRotation => Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(Pitch)) * Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(Yaw));
        public float CameraFOV { get; set; } = 30;
        public float CameraViewDistance { get; set; } = 10000;

        public Matrix4 CameraRotationMatrix => Matrix4.CreateFromQuaternion(CameraRotation);
        public Matrix4 CameraPositionMatrix => Matrix4.CreateTranslation(-CameraPosition + GetShakeOffset(0.1f,20));
        public Matrix4 CameraViewMatrix => CameraPositionMatrix * CameraRotationMatrix;

        public Vector3 CameraNormal => CameraRotationMatrix.Column2.Xyz;

        public RenderCamera()
        {
            MainCamera = this;
        }

        public Matrix4 CameraProjectionMatrix
        {
            get
            {
                switch (ViewType)
                {
                    case CameraType.Orthotgraphics: return Matrix4.CreateOrthographic(CameraFOV * Window.MainWindow.ScreenAspect, CameraFOV,1,CameraViewDistance);
                    case CameraType.Perspective: return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(CameraFOV) ,Window.MainWindow.ScreenAspect,1, CameraViewDistance);
                }

                return Matrix4.Identity;
            }
        }
        public Matrix4 CameraViewThrustum => CameraViewMatrix * CameraProjectionMatrix;

        public float shaketimer;
        public bool Shaking => shaketimer > 0;
        public void Shake(float length = 10)
        {
            shaketimer = 10;
        }

        public Vector3 GetShakeOffset(float mag,int res)
        {
            if (Shaking)
            {
                return new Vector3(Window.GlobalRNG.Next(-res,res)/(float)res, Window.GlobalRNG.Next(-res, res) / (float)res, Window.GlobalRNG.Next(-res, res) / (float)res) * mag;
            }

            return new Vector3();
        }
    }
}
