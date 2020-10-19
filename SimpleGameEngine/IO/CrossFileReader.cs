using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SimpleGameEngine.IO
{
    public unsafe struct FileHeader
    {
        public long Magic;
        public short BufferCount;
        public short unk0;
        public short unk1;
    }

    public unsafe struct DataPointer
    {
        public byte* Location;
        public int Offset;
        public int Size;
    }

    public unsafe class CrossFileReader
    {
        public FileHeader header { get; private set; }
        public byte[] Buffer { get; set; }
        public byte* Location
        {
            get
            {
                fixed (byte* temp = Buffer)
                {
                    return temp;
                }
            }
        }
        public int BufferLocation { get; private set; }
        public T ReadObjectOffset<T>(int offset) where T : unmanaged
        {
            int temp = BufferLocation;

            Seek(offset);

            T Out = ReadObject<T>();
            
            Seek(temp);

            return Out;
        }
        public T[] ReadObjectOffset<T>(int offset,int size) where T : unmanaged
        {
            int temp = BufferLocation;

            Seek(offset);

            T[] Out = ReadObject<T>(size);

            Seek(temp);

            return Out;
        }

        public T ReadObject<T>() where T : unmanaged
        {
            T Out = *(T*)(&Location[BufferLocation]);

            BufferLocation += sizeof(T);

            return Out;
        }
        public T[] ReadObject<T>(int count) where T : unmanaged
        {
            T[] Out = new T[count];

            for (int i = 0; i < Out.Length; i++)
            {
                Out[i] = ReadObject<T>();
            }

            return Out;
        }
        public void Seek(int offset)
        {
            BufferLocation = offset;
        }
        public void Advance(int size)
        {
            Seek(BufferLocation + size);
        }

        public CrossFileReader(byte[] Buffer)
        {
            this.Buffer = Buffer;

            header = ReadObject<FileHeader>();
        }

        public DataPointer[] ReadPointers(int offset)
        {
            Seek(offset);

            FileHeader header = ReadObject<FileHeader>();

            DataPointer[] Out = new DataPointer[header.BufferCount];

            for (int i = 0; i < Out.Length; i++)
            {
                int size = ReadObject<int>();

                Out[i].Offset = BufferLocation;
                Out[i].Location = &Location[BufferLocation];
                Out[i].Size = size;

                Advance(size);
            }

            return Out;
        }

        public string ReadString(int offset)
        {
            int temp = BufferLocation;

            string Out = "";

            Seek(offset);

            while (true)
            {
                byte b = ReadObject<byte>();

                if (b == 0)
                    break;

                Out += (char)b;
            }

            Seek(temp);

            return Out;
        }

        public static T* GetArrayPointer<T>(T[] data) where T : unmanaged
        {
            fixed (T* temp = data)
            {
                return temp;
            }
        }
    }
}