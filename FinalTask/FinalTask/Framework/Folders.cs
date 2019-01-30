using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework
{
    public class Folders
    {


        public static string GetWorkingDirectory()
        {
            return @AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetSolutionFolder()
        {
            return @Path.Combine(GetWorkingDirectory(), "..\\..\\..\\");
        }

        public static string GetRootProjectFolder()
        {
            return @Path.Combine(GetWorkingDirectory(), "..\\..\\..\\..\\");
        }


    }
}
