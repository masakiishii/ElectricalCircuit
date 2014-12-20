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
        private char[] delimitor;
        public LoadScript(string filename)
        {
            this.filename  = filename;
            this.delimitor = new char[] {' '};
        }
        public List<string[]> parseCommandLine()
        {
            string line   = string.Empty;
            string result = string.Empty;
            List<string[]> elementlist = new List<string[]>();
            if (File.Exists(this.filename))
            {
                StreamReader reader = new StreamReader(this.filename, Encoding.Default);
                while(reader.Peek() >= 0)
                {
                    line = reader.ReadLine();
                    if(!line.Equals(".end")) {
                        elementlist.Add(line.Split(this.delimitor));
                    }
                }
                reader.Close();
            }
            return elementlist;
        }
    }
}
