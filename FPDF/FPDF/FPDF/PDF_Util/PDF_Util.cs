using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPDF.PDF_Util
{
    static class PDF_Util
    {

        public static string readPDF(string path)
        {

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else 
            {
                throw new Exception("The file doesn't exists!");
            }
        }

    }
}
