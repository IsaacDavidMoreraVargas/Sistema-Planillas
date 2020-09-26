using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sistema_Planillas_Contabilidad
{
    class generalMethodToWriteInFiles
    {

        public void writeInFiles(string pathToWrite,string lineToRead)
        {
            string[] storageSplitData = lineToRead.Split('?');
            FileStream fstream = new FileStream(pathToWrite, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fstream);
            foreach (string line in storageSplitData)
            {
                writer.WriteLine(line);
            }
            writer.Close();
        }
    }
}
