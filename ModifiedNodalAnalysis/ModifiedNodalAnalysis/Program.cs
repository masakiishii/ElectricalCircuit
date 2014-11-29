using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                LoadScript loadscript = new LoadScript(args[0]);
                loadscript.parseCommandLine();
            } else
            {
                Console.WriteLine("Error!");  
            }
            Console.ReadLine();
        }
    }
}
