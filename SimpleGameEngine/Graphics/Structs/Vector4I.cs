using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics.Structs
{
    public struct Vector4I
    {
        public int X, Y, Z, W;

        public override string ToString()
        {
            return "(" + X + "," + Y + "," + Z + "," + W + ")";
        }

        public unsafe ref int this[int index]
        {
            get
            {
                fixed (Vector4I* tmp = &this)
                {
                    return ref ((int*)tmp)[index];
                }
            }
        }
    }
}
