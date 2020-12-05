using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game
{
    public class ScriptObject
    {
        public string Source;
        public Script Script;
        DynValue temp = new DynValue();

        public void SetGlobal(string name, object Object)
        {
            Script.Globals[name] = Object;
        }

        public ScriptObject(string source)
        {
            Source = source;
            Script = new Script();

            temp = Script.LoadString(source);
        }

        public void Run()
        {
            try
            {
                Script.Call(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        ~ScriptObject()
        {

        }
    }
}
