using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_ELEGIR_GENERAR_TOTALES : Form
    {
        string company = "";

        public GUI_ELEGIR_GENERAR_TOTALES()
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
        generalMethods callToGeneralMethods = new generalMethods();

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

        private void GUI_ELEGIR_GENERAR_TOTALES_Load(object sender, EventArgs e)
        {
            loadDefaultData();
        }

        private void loadDefaultData()
        {
            string path = CorePathOfFolderCompaniesSistemaPlanillas + company;
            string[] storageDepartments = Directory.GetDirectories(path);
            foreach (string department in storageDepartments)
            {
                string replaceString = department.Replace(CorePathOfFolderCompaniesSistemaPlanillas + company, "");
                replaceString = replaceString.Replace("\\", "");
                if (replaceString != coreExtraConfiguration)
                {
                    Invoke(new Action(() => checkedListBox4.Items.Add(replaceString, true)));
                }
            }

            for (int departmen = 0; departmen < checkedListBox4.Items.Count; departmen++)
            {
                path = CorePathOfFolderCompaniesSistemaPlanillas + company+ "\\"+ checkedListBox4.Items[departmen];
                string[] storageMonth = Directory.GetDirectories(path);
                foreach (string month in storageMonth)
                {
                    string replaceString = month.Replace(CorePathOfFolderCompaniesSistemaPlanillas + company+"\\"+ checkedListBox4.Items[departmen], "");
                    replaceString = replaceString.Replace("\\", "");
                    Invoke(new Action(() => checkedListBox1.Items.Add(replaceString, false)));
                }
                break;
            }
        }

        List<string> listDepartmens = new List<string>();
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            for (int departmen = 0; departmen < checkedListBox4.Items.Count; departmen++)
            {
                if (checkedListBox4.GetItemChecked(departmen) == true)
                {
                    for (int month= 0; month < checkedListBox1.Items.Count; month++)
                    {
                        if (checkedListBox1.GetItemChecked(month) == true)
                        {
                            listDepartmens.Add(checkedListBox4.Items[departmen].ToString()+ "\\"+ checkedListBox1.Items[month].ToString());
                        }
                    }
                }
            }
            this.Close();
        }

        public List<string> getListOfDepartments()
        {
            return listDepartmens;
        }
        
        public void PathToCompany(string companyReceived)
        {
            company = companyReceived;
            company = company.Replace(" ","_");
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
