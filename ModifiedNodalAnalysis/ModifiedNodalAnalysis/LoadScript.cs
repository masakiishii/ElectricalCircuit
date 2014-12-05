using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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
            if (File.Exists(this.filename))
            {
                StreamReader reader = (new StreamReader(this.filename, Encoding.Default));
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
