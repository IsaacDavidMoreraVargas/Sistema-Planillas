using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_CREAR_EMPRESA : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_MENUS
    {

        public GUI_CREAR_EMPRESA()
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
        string configuration = "";
        string exclusiveData = "";
        string sits = "";
        string template = "";
        SpecificAndCorePaths startThePaths;
        TagsAndDefaultValues startTheTagsAndDefaults;
        FoldersInsideCompany startFoldersInsideCompany;
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
            //folders inside folders
            coreExtraConfiguration = startFoldersInsideCompany.isCoreExtraConfigurations;
            configuration = startFoldersInsideCompany.isConfiguration;
            exclusiveData = startFoldersInsideCompany.isExclusiveData;
            sits = startFoldersInsideCompany.isSits;
            template = startFoldersInsideCompany.isTemplate;
        }

        string menuOption;
        string name = "";
        private void GUI_CREAR_EMPRESA_Load(object sender, EventArgs e)
        {
            if (menuOption == "CREATE")
            {
                chargeDataCreateCase();
            }
            else if (menuOption == "EDIT")
            {
                chargeDataEditCase();
            }
        }

        string[] months = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        private void chargeDataCreateCase()
        {
            buttonGenerateCompany.Visible = false;
            comboBoxFrom.Text = threeLine;
            comboBoxTo.Text = threeLine;
            comboBoxChargeTemplate.Text = threeLine;

            foreach (string month in months)
            {
                comboBoxFrom.Items.Add(month);
                comboBoxTo.Items.Add(month);
            }

            string[] storageFiles = Directory.GetFiles(SpecificPathOfFolderConfigurationTemplates);

            foreach (string file in storageFiles)
            {
                string addItem = file.Replace("_", " ");
                if (addItem == "" || addItem == " " || addItem == "_")
                {
                    //do nothing
                }
                else 
                {
                    addItem = addItem.Replace(SpecificPathOfFolderConfigurationTemplates, "");
                    addItem = addItem.Replace(".txt", "");
                    comboBoxChargeTemplate.Items.Add(addItem);
                }
                
            }
            listView1.View = View.Details;
            listView1.Columns[0].Width = listView1.Width;
            listView1.Columns[0].Text = "DEPARTAMENTOS";
        }

        private void chargeDataEditCase()
        {
            //clear elements
            comboBoxFrom.Items.Clear();
            comboBoxTo.Items.Clear();
            comboBoxChargeTemplate.Items.Clear();
            listView1.Items.Clear();
            //set default data
            buttonGenerateCompany.Text = "Editar";
            textBoxNameCompany.Text = "";
            textBoxLegalID.Text = "";
            comboBoxFrom.Text = threeLine;
            comboBoxTo.Text = threeLine;
            comboBoxChargeTemplate.Text = threeLine;
            textBoxNameCompany.Text = name;
            //visible buttons
            buttoneEraseDepartment.Visible = true;
            departmentWasIntrouced = true;
            listView1.Visible = true;
            //
            listView1.View = View.Details;
            listView1.Columns[0].Width = listView1.Width;
            listView1.Columns[0].Text = "DEPARTAMENTOS";
            //set months
            foreach (string item in months)
            {
                comboBoxFrom.Items.Add(item);
                comboBoxTo.Items.Add(item);
            }
            
            name = name.Replace(" ","_");
            //reading ID
            string pathId = CorePathOfFolderCompaniesSistemaPlanillas + "\\" + name + "\\"+ coreExtraConfiguration + "\\" + exclusiveData + "\\" + "exclusive.txt";
            textBoxLegalID.Text = File.ReadAllText(pathId);
            
            string pathCompany = CorePathOfFolderCompaniesSistemaPlanillas + "\\" + name;
            string []deparments = Directory.GetDirectories(pathCompany);

            generalMethods callToGeneralMethods = new generalMethods();
            foreach (string item in deparments)
            {
                string changeString = item.Replace(pathCompany, "");
                changeString = changeString.Replace("_"," ");
                changeString = changeString.Replace("\\", " ");
                changeString = callToGeneralMethods.eraseFirstWhiteSpace(changeString);
                if (changeString!=coreExtraConfiguration)
                {
                    listView1.Items.Add(changeString);
                }

            }
            
            string pathTemplates = SpecificPathOfFolderConfigurationTemplates;
            string[] templates = Directory.GetFiles(pathTemplates);
            foreach (string item in templates)
            {
                string change = item.Replace(pathTemplates, "");
                change = change.Replace("_", " ");
                change = change.Replace("\\", " ");
                change = change.Replace(".txt", "");
                comboBoxChargeTemplate.Items.Add(change);
            }
            
        }

        private void buttonReturnProgram_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY callingMenuStart = new GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY();
            callingMenuStart.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        List<string> storageDeparments = new List<string>();
        private void buttonGenerateCompany_Click(object sender, EventArgs e)
        {
            if (textBoxNameCompany.Text == "" || textBoxNameCompany.Text == " ")
            {
                MessageBox.Show("NOMBRE COMPAÑIA VACIO");
            }
            else if (comboBoxFrom.Text == threeLine)
            {
                MessageBox.Show("FECHA DESDE VACIA");
            }
            else if (comboBoxTo.Text == threeLine)
            {
                MessageBox.Show("FECHA HASTA VACIA");
            }
            else if (comboBoxChargeTemplate.Text == threeLine || comboBoxChargeTemplate.Text == "")
            {
                MessageBox.Show("CARGAR PLANTILLA VACIA");
            }
            else if (departmentWasIntrouced == false)
            {
                MessageBox.Show("ESCRIBE ALGUN DEPARTAMENTO, EN CASO DE QUE NO EXISTAN, RECOMIENDO ESCRIBIR GENERAL");
            }
            else if (textBoxLegalID.Text == "")
            {
                MessageBox.Show("CEDULA JURIDICA VACIA");
            }
            else
            {

                if (menuOption == "CREATE")
                {
                    List<string> listFoldersCreate = new List<string>();
                    //get number days of months
                    string pathDays = SpecificPathOfFolderConfigurationDaysOfMoths + "days.txt";
                    string[] storageNumberDays = File.ReadAllLines(pathDays);
                    //getting the path to create company
                    string pathCompanyAndNameCompany = textBoxNameCompany.Text;
                    pathCompanyAndNameCompany = pathCompanyAndNameCompany.Replace(" ","_");
                    pathCompanyAndNameCompany = CorePathOfFolderCompaniesSistemaPlanillas + pathCompanyAndNameCompany;
                    listFoldersCreate.Add(pathCompanyAndNameCompany);
                    //add folder core configuration
                    string CompanyAndCoreConfiguration = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration;
                    listFoldersCreate.Add(CompanyAndCoreConfiguration);
                    //add folder core-configuration
                    string CompanyAndConfiguration = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" +configuration;
                    listFoldersCreate.Add(CompanyAndConfiguration);
                    //add folder core-exclusive data
                    string CompanyAndExclusiveData = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + exclusiveData;
                    listFoldersCreate.Add(CompanyAndExclusiveData);
                    //add folder core-sits data
                    string CompanyAndSits = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + sits;
                    listFoldersCreate.Add(CompanyAndSits);
                    //add folder core-template data
                    string CompanyAndTemplates = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + template;
                    listFoldersCreate.Add(CompanyAndTemplates);
                    //getting of month
                    List<string> storageMonths = new List<string>();
                    bool allowAdd = false;
                    for (int month = 0; month < months.Length; month++)
                    {
                        if (months[month] == comboBoxTo.Text)
                        {
                            storageMonths.Add(months[month]);
                            break;
                        }
                        else if (months[month] == comboBoxFrom.Text)
                        {
                            allowAdd = true;
                        }
                        if (allowAdd == true)
                        {
                            storageMonths.Add(months[month]);
                        }
                    }
                    List<string []> storageDays = new List<string[]>();
                    generalMethods callToGetFolders = new generalMethods();
                    for(int month=0; month<storageNumberDays.Length; month++)
                    {
                        foreach(string numbers in storageMonths)
                        {
                            if(storageNumberDays[month] == numbers)
                            {
                                ++month;
                                string[] dividedFolders = callToGetFolders.getFoldersOFWeeks(storageNumberDays[month]);
                                storageDays.Add(dividedFolders);
                            }
                        }
                    }
                    //add the deparments and months to the company
                    foreach (string deparment in storageDeparments)
                    {
                        foreach (string month in storageMonths)
                        {
                            string pathCompanyAndNameCompanyAndMonth = pathCompanyAndNameCompany + "\\" + deparment + "\\" + month;
                            listFoldersCreate.Add(pathCompanyAndNameCompanyAndMonth);
                        }
                    }
                    //create list of Files with for every week number to write the data of tempalte
                    List<string> listFilesCreate = new List<string>();
                    foreach (string deparment in storageDeparments)
                    {
                        for (int month = 0; month < storageMonths.Count; month++)
                        {
                            string[] storageDaysOfMonths = storageDays[month];
                            foreach (string days in storageDaysOfMonths)
                            {
                                string pathCompanyAndNameCompanyAndMonthAndDays = pathCompanyAndNameCompany + "\\" + deparment + "\\" + storageMonths[month]+ "\\" + days+".txt";
                                listFilesCreate.Add(pathCompanyAndNameCompanyAndMonthAndDays);
                            }
                        }
                    }
                    //path to get template
                    string templateName = comboBoxChargeTemplate.Text;
                    templateName = templateName.Replace(" ","_");
                    string pathTemplate = SpecificPathOfFolderConfigurationTemplates + "\\" + templateName+".txt";
                    string[] storageDataOfTemplate = File.ReadAllLines(pathTemplate);
                    //create all folders
                    foreach (string createThisDirectory in listFoldersCreate)
                    {
                        Directory.CreateDirectory(createThisDirectory);
                    }
                    //create all files
                    foreach (string createThisFile in listFilesCreate)
                    {
                        FileStream fstreamFile = new FileStream(createThisFile, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writerFile = new StreamWriter(fstreamFile);
                        foreach (string line in storageDataOfTemplate)
                        {
                            writerFile.WriteLine(line);
                        }
                        writerFile.Close();
                    }
                    //adding Id To File
                    string ID = textBoxLegalID.Text;
                    string pathId = pathCompanyAndNameCompany + "\\" +coreExtraConfiguration+ "\\" + exclusiveData + "\\" + "exclusive.txt";
                    FileStream fstreamId = new FileStream(pathId, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writerId = new StreamWriter(fstreamId);
                    writerId.WriteLine(ID);
                    writerId.Close();
                    //adding data To Template folder
                    string pathGetTemplate = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + template + "\\" + templateName+ ".txt";
                    FileStream fstreamTemplate = new FileStream(pathGetTemplate, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writerTemplate = new StreamWriter(fstreamTemplate);
                    foreach (string line in storageDataOfTemplate)
                    {
                        writerTemplate.WriteLine(line);
                    }
                    writerTemplate.Close();

                    //here ends the creation of company
                    setDataDefault();
                    MessageBox.Show("EMPRESA CREADA EXITOSAMENTE");
                }
                else if (menuOption == "EDIT")
                {
                   
                }
            }
        }

        private void setDataDefault()
        {
            textBoxNameCompany.Text = "";
            comboBoxFrom.Items.Clear();
            comboBoxFrom.Text = threeLine;
            comboBoxTo.Items.Clear();
            comboBoxTo.Text = threeLine;
            foreach (string month in months)
            {
                comboBoxFrom.Items.Add(month);
                comboBoxTo.Items.Add(month);
            }

            comboBoxChargeTemplate.Text = threeLine;
            
            textBoxLegalID.Text = "";
            listView1.Items.Clear();
            listView1.Columns[0].Width = listView1.Width;
            listView1.Columns[0].Text = "DEPARTAMENTOS";
            departmentWasIntrouced = false;
            buttonGenerateCompany.Visible = false;
            listView1.Visible = false;
            buttoneEraseDepartment.Visible = false;
            storageDeparments.Clear();
        }

        bool departmentWasIntrouced = false;
        private void buttonAddDeparment_Click(object sender, EventArgs e)
        {
            if (textBoxDepartment.Text != "" && textBoxDepartment.Text != " ")
            {
                buttonGenerateCompany.Visible = true;
                storageDeparments.Add(textBoxDepartment.Text);
                listView1.Items.Add(textBoxDepartment.Text);
                listView1.Visible = true;
                textBoxDepartment.Text = "";
                buttoneEraseDepartment.Visible = true;
                departmentWasIntrouced = true;
            }
            else
            { 
                MessageBox.Show("ESCIBE ALGO ANTES DE ANTES DE AÑADIR DEPARTAMENTO"); 
            }
        }
 
        int IndexViewList = 0;
        private void IndexChangeViewList(object sender, EventArgs e)
        {
            generalMethods callToMethods = new generalMethods();
            string compare = callToMethods.eraseFirstWhiteSpace(listView1.FocusedItem.Text);
            if (listView1.FocusedItem != null && compare != "DEPARTAMENTOS")
            {
                IndexViewList = listView1.FocusedItem.Index;
            }else
            {
                MessageBox.Show("SELECCION NO VALIDA");
            }

        }

        private void buttonEraseDepartment_Click(object sender, EventArgs e)
        {
            generalMethods callToMethods = new generalMethods();
            string compare = callToMethods.eraseFirstWhiteSpace(listView1.FocusedItem.Text);
            if (listView1.Items[IndexViewList].Text == "" || compare == "DEPARTAMENTOS")
            {
                MessageBox.Show("SELECCIONA UN DEPARTAMENTO VALIDO PARA ELIMINAR");
            }
            else
            {
                List<string> subList = new List<string>();
                foreach (string deparment in storageDeparments)
                {
                    if (deparment != listView1.Items[IndexViewList].Text)
                    {
                        subList.Add(deparment);
                    }
                }
                listView1.Items.RemoveAt(IndexViewList);
                listView1.Refresh();
                storageDeparments.Clear();
                storageDeparments = subList;
            }
           
        }

        public void optionCreateOrEdit(string option)
        {
            menuOption = option;
        }

        public void receivedNameCompany(string companyName)
        {
            name = companyName;
        }

        private void ReloadDataComboxTo(object sender, EventArgs e)
        {
            string avoidDate = comboBoxFrom.Text;
            comboBoxTo.Items.Clear();
            comboBoxTo.Text = "----";

            for (int dateStart = 0; dateStart < months.Length; dateStart++)
            {
                if (months[dateStart] == avoidDate)
                {
                    for (int dateEnd = ++dateStart; dateEnd < months.Length; dateEnd++)
                    {
                        comboBoxTo.Items.Add(months[dateEnd]);
                    }
                    dateStart = months.Length;
                    break;
                }
            }
        }

    }
}
