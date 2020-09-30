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
            setDefaultFoldersInsideCompany();
        }

        SpecificAndCorePaths startThePaths = new SpecificAndCorePaths();
        List<string> pathsOfCoreFolders = new List<string>();
       
        private void StartPaths()
        {
            string[] arrowCreateFirstTimeGeneralFolders = { "FOLDERCOMPANIES", "CORECONFIGURATIONCOMPANIES"};
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Sistema Planillas Contabilidad";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\";
            startThePaths.CorePathOfFolderSistemaPlanillas = path;
            //other core path
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
                }
            }
        }

        private void evaluatePathAndCreateStage1()
        {
            pathsOfCoreFolders.Add(startThePaths.CorePathOfFolderSistemaPlanillas);
            pathsOfCoreFolders.Add(startThePaths.CorePathOfCompaniesFolderSistemaPlanillas);
            pathsOfCoreFolders.Add(startThePaths.CorePathOfConfigurationFolderSistemaPlanillas);
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
            string[] arrowCreateFirstTimeSpecificFolders = { "AvoidData", "CodesSits", "DaysOfMoths", "Formulas", "Sits", "Templates", "Pictures" };
            //position 2 is core configuration's Folder
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
                    case 6:
                        startThePaths.SpecificPathOfConfigurationFolderPictures = sendPath;
                        break;
                }
                if (!Directory.Exists(sendPath))
                {
                    Directory.CreateDirectory(sendPath);
                }
            }
        }

        TagsAndDefaultValues startSetTagsAndDefaults = new TagsAndDefaultValues();
        private void setTags()
        {
            string[] arrowOfTags = { "<startHeads>", "</endHeads>", "<startNewLine>", "</endNewline>","----", "DEPARTAMENTOS","<startDataGrid1>", "</endDataGrid1>", "<startDataGrid2>", "</endDataGrid2>", "<startDataGrid3>", "</endDataGrid3>", "<startDataGrid4>", "</endDataGrid4>", "<startFormula>", "</endFormula>","<startChargeFormula>", "</endChargeFormula>", "<startFormulasDebit>", "</endFormulasDebit>", "<startFormulasCredit>", "</endFormulasCredit>"};
            int sizeArray = arrowOfTags.Length;
            for (int numberTag = 0; numberTag < sizeArray; numberTag++)
            {
                switch (numberTag)
                {
                    case 0:
                        startSetTagsAndDefaults.isTagStartHead = arrowOfTags[numberTag];
                        break;
                    case 1:
                        startSetTagsAndDefaults.isTagEndHead = arrowOfTags[numberTag];
                        break;
                    case 2:
                        startSetTagsAndDefaults.isTagStartLine = arrowOfTags[numberTag];
                        break;
                    case 3:
                        startSetTagsAndDefaults.isTagEndLine = arrowOfTags[numberTag];
                        break;
                    case 4:
                        startSetTagsAndDefaults.tripleLine = arrowOfTags[numberTag];
                        break;
                    case 5:
                        startSetTagsAndDefaults.isDeparment= arrowOfTags[numberTag];
                        break;
                    case 6:
                        startSetTagsAndDefaults.tagStartDataGrid1 = arrowOfTags[numberTag];
                        break;
                    case 7:
                        startSetTagsAndDefaults.tagEndDataGrid1 = arrowOfTags[numberTag];
                        break;
                    case 8:
                        startSetTagsAndDefaults.tagStartDataGrid2 = arrowOfTags[numberTag];
                        break;
                    case 9:
                        startSetTagsAndDefaults.tagEndDataGrid2 = arrowOfTags[numberTag];
                        break;
                    case 10:
                        startSetTagsAndDefaults.tagStartDataGrid3 = arrowOfTags[numberTag];
                        break;
                    case 11:
                        startSetTagsAndDefaults.tagEndDataGrid3 = arrowOfTags[numberTag];
                        break;
                    case 12:
                        startSetTagsAndDefaults.tagStartDataGrid4 = arrowOfTags[numberTag];
                        break;
                    case 13:
                        startSetTagsAndDefaults.tagEndDataGrid4 = arrowOfTags[numberTag];
                        break;
                    case 14:
                        startSetTagsAndDefaults.tagStartFormula = arrowOfTags[numberTag];
                        break;
                    case 15:
                        startSetTagsAndDefaults.tagEndFormula = arrowOfTags[numberTag];
                        break;
                    case 16:
                        startSetTagsAndDefaults.tagStartChargeFormula = arrowOfTags[numberTag];
                        break;
                    case 17:
                        startSetTagsAndDefaults.tagEndChargeFormula = arrowOfTags[numberTag];
                        break;
                    case 18:
                        startSetTagsAndDefaults.tagStartDebitFormula= arrowOfTags[numberTag];
                        break;
                    case 19:
                        startSetTagsAndDefaults.tagEndDebitFormula = arrowOfTags[numberTag];
                        break;
                    case 20:
                        startSetTagsAndDefaults.tagStartCreditFormula = arrowOfTags[numberTag];
                        break;
                    case 21:
                        startSetTagsAndDefaults.tagEndCreditFormula = arrowOfTags[numberTag];
                        break;
                }
            }
        }

        FoldersInsideCompany startSetFoldersCompanyDefaults = new FoldersInsideCompany();
        private void setDefaultFoldersInsideCompany()
        {
            string[] arrowOfFolderInside = { "EXTRACONFIGURATIONS", "extraConfigurationsCoreFormulas", "exclusiveData", "extraConfigurationsSitsFormulas", "template"};
            int sizeArray = arrowOfFolderInside.Length;
            for (int numberFolder = 0; numberFolder < sizeArray; numberFolder++)
            {
                switch (numberFolder)
                {
                    case 0:
                        startSetFoldersCompanyDefaults.isCoreExtraConfigurations= arrowOfFolderInside[numberFolder];
                        break;
                    case 1:
                        startSetFoldersCompanyDefaults.isFormula = arrowOfFolderInside[numberFolder];
                        break;
                    case 2:
                        startSetFoldersCompanyDefaults.isExclusiveData = arrowOfFolderInside[numberFolder];
                        break;
                    case 3:
                        startSetFoldersCompanyDefaults.isSits = arrowOfFolderInside[numberFolder];
                        break;
                    case 4:
                        startSetFoldersCompanyDefaults.isTemplate = arrowOfFolderInside[numberFolder];
                        break;
                }
            }
        }

        private void buttonMultipleOptionsTemplate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_EDITAR_PLANTILLA callGuiEdit = new GUI_MENU_EDITAR_PLANTILLA();
            callGuiEdit.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callGuiEdit.ShowDialog();
            this.Close();
        }

        private void buttonMultipleOptionsCompany_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY callGuiDuplicateCopyEliminate = new GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY();
            callGuiDuplicateCopyEliminate.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callGuiDuplicateCopyEliminate.ShowDialog();
            this.Close();
        }

        private void buttonWorkWithCompany_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_ELEGIR__TRABAJAR_EMPRESA callingWorkCompany = new GUI_ELEGIR__TRABAJAR_EMPRESA();
            callingWorkCompany.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callingWorkCompany.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEditGlobalFormulas_Click(object sender, EventArgs e)
        {
            string storagePathAvoid = startThePaths.SpecificPathOfConfigurationFolderAvoidData + "avoid.txt";
            List<string> listOfHeads = new List<string>();
            if (File.Exists(storagePathAvoid))
            {
                string[] storageHeads = File.ReadAllLines(storagePathAvoid);
                foreach (string head in storageHeads)
                {
                    listOfHeads.Add(head);
                }
            }
            GUI_CREATE_FORMULA callingCreateFormula = new GUI_CREATE_FORMULA();
            callingCreateFormula.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callingCreateFormula.lisftOfHeads(listOfHeads);
            callingCreateFormula.menuGlobalOrLocal("GLOBAL");
            callingCreateFormula.ShowDialog();
        }

        private void buttonEditGlobalSits_Click(object sender, EventArgs e)
        {
            //List<string> sendNothing = new List<string>();
            List<string> listOfHeads = new List<string>();
            string storagePathAvoid = startThePaths.SpecificPathOfConfigurationFolderAvoidData + "avoid.txt";
            if (File.Exists(storagePathAvoid))
            {
                string[] storageHeads = File.ReadAllLines(storagePathAvoid);
                foreach (string head in storageHeads)
                {
                    listOfHeads.Add(head);
                }
            }
            GUI_SELECCIONAR_ASIENTOS callingCreateFormula = new GUI_SELECCIONAR_ASIENTOS();
            callingCreateFormula.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callingCreateFormula.lisfOFHeads(listOfHeads);
            //callingCreateFormula.PathToCompany(company, deparment, month);
            callingCreateFormula.menuGlobalOrLocal("GLOBAL");
            callingCreateFormula.ShowDialog();
        }

        private void buttonEditCodes_Click(object sender, EventArgs e)
        {
            GUI_CREAR_EDITAR_CODIGOS_DIASMES callingEditCode= new GUI_CREAR_EDITAR_CODIGOS_DIASMES();
            callingEditCode.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callingEditCode.menuCodeOrDay("CODE");
            callingEditCode.ShowDialog();
        }

        private void buttonDaysMonth_Click(object sender, EventArgs e)
        {
            GUI_CREAR_EDITAR_CODIGOS_DIASMES callingEditCode = new GUI_CREAR_EDITAR_CODIGOS_DIASMES();
            callingEditCode.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callingEditCode.menuCodeOrDay("DAYS");
            callingEditCode.ShowDialog();
        }

        private void buttonEditHeads_Click(object sender, EventArgs e)
        {
            GUI_CREAR_EDITAR_CODIGOS_DIASMES callingEditCode = new GUI_CREAR_EDITAR_CODIGOS_DIASMES();
            callingEditCode.MethodToReceivedAccesToObject(startThePaths, startSetTagsAndDefaults, startSetFoldersCompanyDefaults);
            callingEditCode.menuCodeOrDay("HEADS");
            callingEditCode.ShowDialog();
        }
    }
}
