﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedNodalAnalysis
{
    class Analyzer
    {
        public Analyzer()
        {

        }
        public void analyze(string file)
        {
            /***  Kernel for Modified Nodal Analysis  ***/

            LoadScript loadscript  = new LoadScript(file);
            List<string[]> rawlist = loadscript.parseCommandLine();

            MatrixBuilder matrixbuilder = new MatrixBuilder();
            matrixbuilder.build(rawlist);
        }
    }
}