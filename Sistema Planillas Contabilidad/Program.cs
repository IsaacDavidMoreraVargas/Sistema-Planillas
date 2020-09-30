using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Sistema_Planillas_Contabilidad
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] arrowCreateFirstTimeGeneralFolders = { "FOLDERCOMPANIES", "CORECONFIGURATIONCOMPANIES" };
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\"+"Sistema Planillas Contabilidad";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\";
            //other core path
            for (int numberFolder = 0; numberFolder < arrowCreateFirstTimeGeneralFolders.Length; numberFolder++)
            {
                string sendPath = path + arrowCreateFirstTimeGeneralFolders[numberFolder] + "\\";
                switch (numberFolder)
                {
                    case 0:
                        if (!Directory.Exists(sendPath))
                        {
                            Directory.CreateDirectory(sendPath);
                        }
                        break;
                    case 1:
                        if (!Directory.Exists(sendPath))
                        {
                            Directory.CreateDirectory(sendPath);
                        }
                        break;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI_MENU_INICIO());
        }
    }
}
