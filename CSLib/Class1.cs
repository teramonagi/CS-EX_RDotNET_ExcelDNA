using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDna.Integration;
using RDotNet;

namespace CSLib
{
    public class CSLib
    {
        static REngine rengine = null;
        static CSLib()
        {
            // Set the folder in which R.dll locates.
            REngine.SetDllDirectory(@"C:\Program Files\R\R-2.13.0\bin\i386");
            rengine = REngine.CreateInstance("RDotNet", new[] { "-q" });
        }            
        [ExcelFunction(Description = "get random numbers obey to normal distribution")]
        public static double [] MyRnorm(int number)
        {
            return (rengine.EagerEvaluate("rnorm(" + number + ")").AsNumeric().ToArray<double>());
        }
    }
}
