using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_VISTA_ASIENTOS : Form
    {
        public GUI_VISTA_ASIENTOS()
        {
            InitializeComponent();
        }

        string CorePathOfFolderSistemaPlanillas = "";
        string CorePathOfFolderCompaniesSistemaPlanillas = "";
        string CorePathOfCoreConfigurationFolderSistemaPlanillas = "";

        string SpecificPathOfFolderConfigurationAvoidData = "";
        string SpecificPathOfFolderConfigurationCodesSits = "";
        string SpecificPathOfFolderConfigurationDaysOfMoths = "";
        string SpecificPathOfFolderConfigurationFormulas = "";
        string SpecificPathOfFolderConfigurationSits = "";
        string SpecificPathOfFolderConfigurationTemplates = "";
        string SpecificPathOfFolderConfigurationPictures = "";

        string threeLine = "";
        string deparmentValue = "";

        string coreExtraConfiguration = "";
        string formula = "";
        string exclusiveData = "";
        string sits = "";
        string template = "";
        string tagEndHEad = "";
        SpecificAndCorePaths startThePaths;
        TagsAndDefaultValues startTheTagsAndDefaults;
        FoldersInsideCompany startFoldersInsideCompany;
        //generalMethods callToGeneralMethods = new generalMethods();

        public void MethodToReceivedAccesToObject(SpecificAndCorePaths startThePathsReceived, TagsAndDefaultValues startTheTagsAndDefaultsReceived, FoldersInsideCompany startFoldersInsideCompanyReceived)
        {
            //receiving object reference
            startThePaths = startThePathsReceived;
            startTheTagsAndDefaults = startTheTagsAndDefaultsReceived;
            startFoldersInsideCompany = startFoldersInsideCompanyReceived;
            //core paths
            CorePathOfFolderSistemaPlanillas = startThePaths.CorePathOfFolderSistemaPlanillas;
            CorePathOfFolderCompaniesSistemaPlanillas = startThePaths.CorePathOfCompaniesFolderSistemaPlanillas;
            CorePathOfCoreConfigurationFolderSistemaPlanillas = startThePaths.CorePathOfConfigurationFolderSistemaPlanillas;
            //specific paths
            SpecificPathOfFolderConfigurationAvoidData = startThePaths.SpecificPathOfConfigurationFolderAvoidData;
            SpecificPathOfFolderConfigurationCodesSits = startThePaths.SpecificPathOfConfigurationFolderCodesSits;
            SpecificPathOfFolderConfigurationDaysOfMoths = startThePaths.SpecificPathOfConfigurationFolderDaysOfMoths;
            SpecificPathOfFolderConfigurationFormulas = startThePaths.SpecificPathOfConfigurationFolderFormulas;
            SpecificPathOfFolderConfigurationSits = startThePaths.SpecificPathOfConfigurationFolderSits;
            SpecificPathOfFolderConfigurationTemplates = startThePaths.SpecificPathOfConfigurationFolderTemplates;
            SpecificPathOfFolderConfigurationPictures = startThePaths.SpecificPathOfConfigurationFolderPictures;
            //default values
            threeLine = startTheTagsAndDefaults.tripleLine;
            deparmentValue = startTheTagsAndDefaults.isDeparment;
            tagEndHEad = startTheTagsAndDefaults.isTagEndHead;
            //folders inside folders
            coreExtraConfiguration = startFoldersInsideCompany.isCoreExtraConfigurations;
            formula = startFoldersInsideCompany.isFormula;
            exclusiveData = startFoldersInsideCompany.isExclusiveData;
            sits = startFoldersInsideCompany.isSits;
            template = startFoldersInsideCompany.isTemplate;
        }

        private void GUI_VISTA_ASIENTOS_Load(object sender, EventArgs e)
        {
            loadDefaultData();
        }
        
        string debit = "DEBIT";
        string credit = "CREDIT";
        string orderLocalOrGlobal = "";

        private void loadDefaultData()
        {
            string[] storageHeadsAndFormulas;
            string[] storageID;
            string[] storageCodes;
            string pathOfHeadsAndFormulas = "";
            if (orderLocalOrGlobal == "LOCAL")
            {
                pathOfHeadsAndFormulas = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + sits + "\\" + "CORE-FORMULAS-SITS.txt";

            }
            else if (orderLocalOrGlobal == "GLOBAL")
            {
                pathOfHeadsAndFormulas = SpecificPathOfFolderConfigurationSits + "GLOBAL-FORMULAS-SITS.txt";
            }
            //MessageBox.Show(pathOfHeadsAndFormulas);

            if (File.Exists(pathOfHeadsAndFormulas))
            {
                storageHeadsAndFormulas = File.ReadAllLines(pathOfHeadsAndFormulas);
            }
            //MessageBox.Show(pathOfHeadsAndFormulas);
            string pathOfID = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + exclusiveData + "\\" + "exclusive.txt";
            if (File.Exists(pathOfID))
            {
                storageID = File.ReadAllLines(pathOfID);
            }
            //MessageBox.Show(pathOfID);
            string pathOfCodesSits = SpecificPathOfFolderConfigurationCodesSits + "codes.txt";
            if (File.Exists(pathOfCodesSits))
            {
                storageCodes = File.ReadAllLines(pathOfCodesSits);
            }
            //MessageBox.Show(pathOfCodesSits);
            generalMultiArrayMethods callToGetArrays = new generalMultiArrayMethods();
            callToGetArrays.MethodToReceivedAccesToObject(startTheTagsAndDefaults);
            List<string[,]> listArrays = callToGetArrays.methodToGetListOfArray(receivedListOfFiles);
            string[,] results = new string[listArrays[0].GetLength(0), listArrays[0].GetLength(1)];
            for (int item = 0; item < listArrays.Count; item++)
            {
                string[,] storageStudy = listArrays[item];
                for (int column = 0; column < storageStudy.GetLength(1); column++)
                {
                    results[0, column] = storageStudy[0, column];
                    double sum = 0;
                    try
                    {
                        for (int row = 1; row < storageStudy.GetLength(0); row++)
                        {
                            if(storageStudy[row, column].Contains("-"))
                            {
                                sum -= Convert.ToDouble(storageStudy[row, column]);
                            }
                            else
                            {
                                sum += Convert.ToDouble(storageStudy[row, column]);
                            }
                        }
                        if (listArrays.Count > 1)
                        {
                            for (int itemPhase2 = 1; itemPhase2 < listArrays.Count; itemPhase2++)
                            {
                                string[,] storageStudyPhase2 = listArrays[itemPhase2];
                                for (int columnPhase2 = 0; columnPhase2 < storageStudyPhase2.GetLength(1); columnPhase2++)
                                {
                                    if(storageStudy[0, column]==storageStudyPhase2[0, columnPhase2])
                                    {
                                        for (int rowPhase2 = 1; rowPhase2 < storageStudyPhase2.GetLength(0); rowPhase2++)
                                        {
                                            if (storageStudyPhase2[rowPhase2, columnPhase2].Contains("-"))
                                            {
                                                sum -= Convert.ToDouble(storageStudyPhase2[rowPhase2, columnPhase2]);
                                            }
                                            else
                                            {
                                                sum += Convert.ToDouble(storageStudyPhase2[rowPhase2, columnPhase2]);
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        results[1, column] = sum.ToString();
                    }
                    catch(Exception)
                    {
                        results[0, column] = "FALSE";
                    }
                }
                break;
            }

            string sumd = "";
            for (int row = 0; row < results.GetLength(0); row++)
            {
                for (int column = 0; column < results.GetLength(1); column++)
                {
                    sumd += results[row, column]+"<>";
                }
                sumd += "\n";
            }
            MessageBox.Show(sumd);
        }

        List<string> receivedListOfFiles = new List<string>();
        public void receiveArrayOfFiles(List<string> receivedList)
        {
            receivedListOfFiles = receivedList;
        }

        string company = "";
        string deparment = "";
        public void PathToCompany(string companyReceive, string deptReceive)
        {
            company = companyReceive;
            deparment = deptReceive;
        }

        public void orderGlobalOrLocal(string receivedOrder)
        {
            orderLocalOrGlobal = receivedOrder;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
