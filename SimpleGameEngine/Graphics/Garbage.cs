using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameEngine.Graphics
{
    public class Garbage
    {
        public static List<Garbage> GarbageCollection = new List<Garbage>();

        public static void CollectTrash()
        {
            foreach (Garbage garbage in GarbageCollection)
            {
                garbage.Dispose();
            }

            GarbageCollection = new List<Garbage>();
        }

        public Garbage()
        {
            GarbageCollection.Add(this);
        }

        public virtual void Dispose()
        {

        }
    }
}
