using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_MENU_INICIO : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_MENUS
    {
        public GUI_MENU_INICIO()
        {
            InitializeComponent();
        }

        private void GUI_MENU_INICIO_Load(object sender, EventArgs e)
        {
            StartPaths();
            evaluatePathAndCreateStage1();
            evaluatePathAndCreateStage2();
            setTags();
        }

        SpecificAndCorePaths startThePaths = new SpecificAndCorePaths();
        List<string> pathsOfCoreFolders = new List<string>();
       
        private void StartPaths()
        {
            string[] arrowCreateFirstTimeGeneralFolders = { "Companies", "configuration", "pictures" };
            string path = Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Debug", "\\");
            startThePaths.CorePathOfFolderSistemaPlanillas = path;
            int sizeArray = arrowCreateFirstTimeGeneralFolders.Length;
            for (int numberFolder = 0; numberFolder < sizeArray; numberFolder++)
            {
                string sendPath = path + arrowCreateFirstTimeGeneralFolders[numberFolder]+"\\";
                switch (numberFolder)
                {
                    case 0:
                        startThePaths.CorePathOfCompaniesFolderSistemaPlanillas = sendPath;
                        break;
                    case 1:
                        startThePaths.CorePathOfConfigurationFolderSistemaPlanillas = sendPath;
                        break;
                    case 2:
                        startThePaths.CorePathOfPicturesFolderSistemaPlanillas = sendPath;
                        break;
                }
            }
        }

        private void evaluatePathAndCreateStage1()
        {
            pathsOfCoreFolders.Add(startThePaths.CorePathOfFolderSistemaPlanillas);
            pathsOfCoreFolders.Add(startThePaths.CorePathOfCompaniesFolderSistemaPlanillas);
            pathsOfCoreFolders.Add(startThePaths.CorePathOfConfigurationFolderSistemaPlanillas);
            pathsOfCoreFolders.Add(startThePaths.CorePathOfPicturesFolderSistemaPlanillas);
            foreach (string path in pathsOfCoreFolders)
            {
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        private void evaluatePathAndCreateStage2()
        {
            string[] arrowCreateFirstTimeSpecificFolders = { "AvoidData", "CodesSits", "DaysOfMoths", "Formulas", "Sits", "Templates" };
            //position 2 is configuration's Folder
            string pathOfConfigurationFolderSistemaPlanillas = pathsOfCoreFolders[2];
            int sizeArray = arrowCreateFirstTimeSpecificFolders.Length;
            for (int numberFolder = 0; numberFolder < sizeArray; numberFolder++)
            {
                string sendPath = pathOfConfigurationFolderSistemaPlanillas + arrowCreateFirstTimeSpecificFolders[numberFolder] + "\\";
                switch (numberFolder)
                {
                    case 0:
                        startThePaths.SpecificPathOfConfigurationFolderAvoidData = sendPath;
                        break;
                    case 1:
                        startThePaths.SpecificPathOfConfigurationFolderCodesSits = sendPath;
                        break;
                    case 2:
                        startThePaths.SpecificPathOfConfigurationFolderDaysOfMoths = sendPath;
                        break;
                    case 3:
                        startThePaths.SpecificPathOfConfigurationFolderFormulas = sendPath;
                        break;
                    case 4:
                        startThePaths.SpecificPathOfConfigurationFolderSits = sendPath;
                        break;
                    case 5:
                        startThePaths.SpecificPathOfConfigurationFolderTemplates = sendPath;
                        break;
                }
                if (!Directory.Exists(sendPath))
                {
                    Directory.CreateDirectory(sendPath);
                }
            }
        }

        TagsAnd startSetTags = new TagsAnd();
        private void setTags()
        {
            string[] arrowOfTags = { "<startHeads>", "</endHeads>", "<startNewLine>", "</endNewline>" };
            int sizeArray = arrowOfTags.Length;
            for (int numberTag = 0; numberTag < sizeArray; numberTag++)
            {
                switch (numberTag)
                {
                    case 0:
                        startSetTags.isTagStartHead = arrowOfTags[numberTag];
                        break;
                    case 1:
                        startSetTags.isTagEndHead = arrowOfTags[numberTag];
                        break;
                    case 2:
                        startSetTags.isTagStartLine = arrowOfTags[numberTag];
                        break;
                    case 3:
                        startSetTags.isTagEndLine = arrowOfTags[numberTag];
                        break;
                }
            }
        }

        private void buttonMultipleOptionsTemplate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_EDITAR_PLANTILLA callGuiEdit = new GUI_MENU_EDITAR_PLANTILLA();
            callGuiEdit.ShowDialog();
            this.Show();
        }

        private void buttonMultipleOptionsCompany_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY callGuiDuplicateCopyEliminate = new GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY();
            callGuiDuplicateCopyEliminate.MethodToReceivedAccesToObject(startThePaths);
            callGuiDuplicateCopyEliminate.ShowDialog();
            this.Close();
        }

        private void buttonWorkWithCompany_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_ELEGIR__TRABAJAR_EMPRESA callingWorkCompany = new GUI_ELEGIR__TRABAJAR_EMPRESA();
            callingWorkCompany.ShowDialog();
            this.Show();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
