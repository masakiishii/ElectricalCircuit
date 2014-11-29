using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class LoadScript
    {
        private string filename;
        public LoadScript(string filename)
        {
            this.filename = filename;
        }
        public void parseCommandLine()
        {
            string line   = string.Empty;
            string result = string.Empty;
            if (System.IO.File.Exists(this.filename))
            {
                System.IO.StreamReader reader = (new System.IO.StreamReader(this.filename, System.Text.Encoding.Default));
                while(reader.Peek() >= 0)
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                }
                reader.Close();
            }
        }
    }
}
