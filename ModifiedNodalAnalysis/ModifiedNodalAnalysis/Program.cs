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
            if (args.Length == 1)
            {
                Analyzer analyzer = new Analyzer();
                analyzer.analyze(args[0], false);
            }
            else if(args.Length == 2 && args[1].Equals("--sparse")) {
                Analyzer analyzer = new Analyzer();
                analyzer.analyze(args[0], true);
            }
            else {
                Console.WriteLine("Error!");  
            }
            Console.ReadLine();
        }
    }
}
