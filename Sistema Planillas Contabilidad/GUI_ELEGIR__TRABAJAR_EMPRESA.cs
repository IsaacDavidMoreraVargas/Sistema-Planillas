using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_ELEGIR__TRABAJAR_EMPRESA : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_MENUS
    {
        string companyOntime = "";
        string deparmentOntime = "";
        string monthOnTime = "";
        string nameTemplate = "";
        string option1 = "LOCAL";
        string option2 = "MEDIO";
        string option3 = "GLOBAL";
        bool booleanCompany = false;
        bool booleanDeparment = false;
        bool booleanMonth = false;

        int indexViewCompany = 0;
        int indexViewDeparment = 0;
        int indexViewMont = 0;

        public GUI_ELEGIR__TRABAJAR_EMPRESA()
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

        private void GUI_ELEGIR__TRABAJAR_EMPRESA_Load(object sender, EventArgs e)
        {
            startChargeData();
        }

        private void startChargeData()
        {
            comboBox1.Text = threeLine;
            comboBox1.Items.Add(option1);
            comboBox1.Items.Add(option2);
            comboBox1.Items.Add(option3);

            buttonGenerateSits.Visible = false;
            buttonStart.Visible = false;
            listViewCompany.View = View.Details;
            listViewCompany.Columns[0].Width = listViewCompany.Width;
            listViewCompany.Columns[0].Text = "EMPRESAS";
            listViewDeparment.View = View.Details;
            listViewDeparment.Columns[0].Width = listViewDeparment.Width;
            listViewDeparment.Columns[0].Text = "DEPARTAMENTOS";
            listViewMonth.View = View.Details;
            listViewMonth.Columns[0].Width = listViewMonth.Width;
            listViewMonth.Columns[0].Text = "MESES";

            string[] storageNameCompanies = Directory.GetDirectories(CorePathOfFolderCompaniesSistemaPlanillas);
            if (storageNameCompanies.Length > 0)
            {
                foreach (string empresa in storageNameCompanies)
                {
                    string changeString = empresa;
                    changeString = changeString.Replace(CorePathOfFolderCompaniesSistemaPlanillas, "");
                    changeString = changeString.Replace("\\", "");
                    changeString = changeString.Replace("_", " ");
                    listViewCompany.Items.Add(changeString);
                }
            }
            else
            {
                MessageBox.Show("NO EXISTEN EMPRESAS");
            }
                
        }

        
        private void listViewCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyOntime = "";
            deparmentOntime = "";
            monthOnTime = "";
            listViewDeparment.Items.Clear();
            listViewMonth.Items.Clear();
            listViewMonth.Visible = false;
            listViewDeparment.Visible = false;

            if (listViewCompany.FocusedItem == null)
            {
                MessageBox.Show("SELECCIONA UNA COMPAÑIA VALIDA");
                booleanCompany = false;
            }
            else
            {
                indexViewCompany = listViewCompany.FocusedItem.Index;

                if (listViewCompany.Items[indexViewCompany].Text == "" || listViewCompany.Items[indexViewCompany].Text.Contains("EMPRESAS"))
                {
                    MessageBox.Show("SELECCIONA UNA COMPAÑIA VALIDA");
                    booleanCompany = false;
                }
                else
                {
                    booleanCompany = true;
                    listViewDeparment.Visible = true;
                    string nameCompany = listViewCompany.Items[indexViewCompany].Text;
                    nameCompany = nameCompany.Replace(" ", "_");
                    companyOntime = nameCompany;

                    string pathOfDeparments= CorePathOfFolderCompaniesSistemaPlanillas + nameCompany;
                    string[] storageDepartments = Directory.GetDirectories(pathOfDeparments);
                    foreach (string deparment in storageDepartments)
                    {
                        string changeString = deparment;
                        changeString = changeString.Replace(pathOfDeparments, "");
                        changeString = changeString.Replace("\\", "");
                        changeString = changeString.Replace("_", " ");
                        if (changeString !=coreExtraConfiguration)
                        {
                            listViewDeparment.Items.Add(changeString);
                        }
                    }
                }
            }

        }

        
        private void listViewDeparment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDeparment.FocusedItem == null)
            {
                MessageBox.Show("SELECCIONA UN DEPARTAMENTO VALIDO");
                booleanDeparment = false;
            }
            else
            {
                string[] months = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };

                indexViewDeparment = listViewDeparment.FocusedItem.Index;

                if (listViewDeparment.Items[indexViewDeparment].Text == "" || listViewDeparment.Items[indexViewDeparment].Text.Contains("DEPARTAMENTOS"))
                {
                    MessageBox.Show("SELECCIONA UN DEPARTAMENTO VALIDO");
                    booleanDeparment = false;
                }
                else
                {
                    listViewMonth.Items.Clear();
                    booleanDeparment = true;
                    listViewMonth.Visible = true;
                    string department = listViewDeparment.Items[indexViewDeparment].Text;
                    department = department.Replace(" ", "_");
                    deparmentOntime = department;
                    string pathOfMonth = CorePathOfFolderCompaniesSistemaPlanillas + companyOntime + "\\" + department;
                    string[] storageMonths = Directory.GetDirectories(pathOfMonth);
                    string addingMonth = "";
                    foreach (string month in storageMonths)
                    {
                        string changeString = month;
                        changeString = changeString.Replace(pathOfMonth, "");
                        changeString = changeString.Replace("\\", "");
                        changeString = changeString.Replace("_", " ");
                        addingMonth += changeString + "\n";
                    }
                    addingMonth = addingMonth.TrimEnd('\n');
                    storageMonths = addingMonth.Split('\n');
                    storageMonths = callToGeneralMethods.orderingMonth(storageMonths, months);
                    foreach (string month in storageMonths)
                    {
                        listViewMonth.Items.Add(month);
                    }
                }
            }
        }

        
        private void listViewMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMonth.FocusedItem == null)
            {
                MessageBox.Show("ERROR AL ELEGIR");
            }
            else
            {
                indexViewMont = listViewMonth.FocusedItem.Index;

                if (listViewMonth.Items[indexViewMont].Text == "" || listViewMonth.Items[indexViewMont].Text.Contains("MESES"))
                {
                    MessageBox.Show("SELECCIONA UN MES VALIDO");
                }
                else
                {
                    booleanMonth = true;
                    string month = listViewMonth.Items[indexViewMont].Text;
                    month = month.Replace(" ", "_");
                    monthOnTime = month;
                    buttonStart.Visible = true;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (listViewCompany.Visible == true && listViewDeparment.Visible == true && listViewMonth.Visible == true)
            {
                string sendPath = CorePathOfFolderCompaniesSistemaPlanillas + companyOntime + "\\" + deparmentOntime + "\\" + monthOnTime;// + "\\" + weekOntime + "\\" + fileOnTime;
                booleanCompany = false;
                booleanDeparment = false;
                booleanMonth = false;
                GUI_WORK_COMPANY callingStartWorkCompany = new GUI_WORK_COMPANY();
                callingStartWorkCompany.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
                callingStartWorkCompany.PathToCompany(companyOntime,deparmentOntime, monthOnTime,sendPath);
                callingStartWorkCompany.ShowDialog();
            }
            else 
            {
                buttonStart.Visible = false;
                string MessageFalse = "NO HA SELECCIONADO TODOS LOS DATOS NECESARIOS\nFALTA:";
                if (booleanCompany == false) 
                {
                    MessageFalse += "\n-NOMBRE COMPAÑIA";
                    booleanCompany = false;
                }
                if (booleanDeparment == false)
                {
                    MessageFalse += "\n-DEPARTAMENTO";
                    booleanDeparment = false;
                }
                if (booleanMonth == false)
                {
                    MessageFalse += "\n-MES";
                    booleanMonth = false;
                }
                MessageBox.Show(MessageFalse);
            }
            
        }

        private void buttonGenerateSits_Click(object sender, EventArgs e)
        {
            if (booleanCompany == false)
            {
                MessageBox.Show("NO ES POSIBLE, SELECCIONA UNA EMPRESA");
            }else if(comboBox1.Text==threeLine)
            {
                MessageBox.Show("NO ES POSIBLE, SELECCIONA UNA UBICACION ARRIBA PRIMERO");
            }
            else
            {
                GUI_ELEGIR_GENERAR_TOTALES callGenerateSits = new GUI_ELEGIR_GENERAR_TOTALES();
                callGenerateSits.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
                callGenerateSits.PathToCompany(companyOntime);
                callGenerateSits.ordeOrSitOrImport("SIT");
                callGenerateSits.ShowDialog();
                List<string> listDepartments = callGenerateSits.getListOfDepartments();
                callGenerateSits.Close();
                if (listDepartments != null && listDepartments.Count > 0)
                {
                    List<string> listFiles = new List<string>();
                    List<string> listFormulas = new List<string>();
                    string pathCompare = CorePathOfFolderCompaniesSistemaPlanillas + companyOntime;
                    string[] storageComparePhase1 = Directory.GetDirectories(pathCompare);
                    foreach (string path in storageComparePhase1)
                    {
                        string[] storageComparePhase2 = Directory.GetDirectories(path);
                        foreach (string pathPhase2 in storageComparePhase2)
                        {
                            foreach (string compare in listDepartments)
                            {
                                if (pathPhase2.Contains(compare))
                                {
                                    string[] storageFiles = Directory.GetFiles(pathPhase2);
                                    foreach (string file in storageFiles)
                                    {
                                        if (file.Contains("SUMA-TOTALES.txt"))
                                        {
                                            listFiles.Add(file);
                                        }
                                        else if (file.Contains("CORE-FORMULAS-SITS.txt"))
                                        {
                                            listFormulas.Add(file);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }

                    if (comboBox1.Text == option1 && listFiles.Count != listFormulas.Count)
                    {
                        MessageBox.Show("NO SE PUEDE INICIAR, EL NUMERO DE MESES NO ES IGUAL AL NUMERO DE FORMULAS INTERNAS POR CADA MES");
                    }
                    else
                    {
                        GUI_VISTA_ASIENTOS callToViewSits = new GUI_VISTA_ASIENTOS();
                        callToViewSits.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
                        callToViewSits.PathToCompany(companyOntime);
                        callToViewSits.orderGlobalOrLocal(comboBox1.Text);
                        callToViewSits.receiveArrayOfFilesAndFormulas(listFiles, listFormulas);
                        callToViewSits.ShowDialog();
                    }
                }
            }
        }

        private void buttonReturnProgram_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_INICIO callingPrincipalMenu = new GUI_MENU_INICIO();
            callingPrincipalMenu.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != threeLine && booleanCompany == true)
            {
                buttonGenerateSits.Visible = true;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
