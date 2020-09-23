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

        string[] months = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"};
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
            List<string> subListDepartment = new List<string>();
            foreach (string item in deparments)
            {
                if (!item.Contains(coreExtraConfiguration))
                {
                    subListDepartment.Add(item);
                }
            }
            string[] storageDeparments = new string[subListDepartment.Count];
            int index = 0;
            foreach(string dept in subListDepartment)
            {
                storageDeparments[index] = dept;
                ++index;
            }

            deparments = storageDeparments;

            foreach (string item in deparments)
            {
                string[] storageMonths = Directory.GetDirectories(item);
                string add = "";
                for (int dept=0; dept<storageMonths.Length; dept++)
                {
                    string changeString = storageMonths[dept];
                    changeString = changeString.Replace(item,"");
                    changeString = changeString.Replace("\\", "");
                    storageMonths[dept] = changeString;
                }
                storageMonths = callToGeneralMethods.orderingMonth(storageMonths,months);
                comboBoxFrom.Text = storageMonths[0];
                int lastMonth = storageMonths.Length - 1;
                comboBoxTo.Text = storageMonths[lastMonth];
                break;
            }
            //reading all templates
            string pathCoreTemplates = SpecificPathOfFolderConfigurationTemplates;
            string[] templatesCore = Directory.GetFiles(pathCoreTemplates);
            foreach (string item in templatesCore)
            {
                string change = item.Replace(pathCoreTemplates, "");
                change = change.Replace("_", " ");
                change = change.Replace("\\", " ");
                change = change.Replace(".txt", "");
                comboBoxChargeTemplate.Items.Add(change);
            }
            //reading template of company
            string pathSpecificTemplates = CorePathOfFolderCompaniesSistemaPlanillas + name + "\\" + coreExtraConfiguration + "\\"+template;
            string[] templatesSpecific = Directory.GetFiles(pathSpecificTemplates);
            foreach (string item in templatesSpecific)
            {
                string change = item.Replace(pathSpecificTemplates, "");
                change = change.Replace("_", " ");
                change = change.Replace("\\", " ");
                change = change.Replace(".txt", "");
                comboBoxChargeTemplate.Text=change;
            }
            saveToEdit();
        }

        string remenberComboBoxTo = "";
        string remenberComboBoxFrom = "";
        string remenberComboBoxTemplate = "";
        List<string> saveListToEdit = new List<string>();
        private void saveToEdit()
        {
            generalMethods callGeneralMethods = new generalMethods();
            remenberComboBoxTemplate = comboBoxChargeTemplate.Text;
            remenberComboBoxTemplate=callGeneralMethods.eraseFirstWhiteSpace(remenberComboBoxTemplate);
            remenberComboBoxTemplate = remenberComboBoxTemplate.Replace(" ","_");
            remenberComboBoxTo = comboBoxTo.Text;
            remenberComboBoxFrom = comboBoxFrom.Text;
            string company = textBoxNameCompany.Text;
            company = company.Replace(" ","_");
            foreach (ListViewItem item in listView1.Items)
            {
                string companyAndDepartmentAndMonth = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + item.Text;
                saveListToEdit.Add(companyAndDepartmentAndMonth);
                bool allowAdd = false;
                for (int month = 0; month < months.Length; month++)
                {
                    if (months[month] == comboBoxTo.Text)
                    {
                        companyAndDepartmentAndMonth = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + item.Text+ "\\" + months[month];
                        saveListToEdit.Add(companyAndDepartmentAndMonth);
                        break;
                    }
                    else if (months[month] == comboBoxFrom.Text)
                    {
                        allowAdd = true;
                    }
                    if (allowAdd == true)
                    {
                        companyAndDepartmentAndMonth = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + item.Text + "\\" + months[month];
                        saveListToEdit.Add(companyAndDepartmentAndMonth);
                    }
                }
               
            }
        }
       
        List<string> storageDeparments = new List<string>();
        List<string> eraseDeparments = new List<string>();
        List<string> listNewDepartmentsEdit = new List<string>();
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
                    string pathCompanyAndNameCompany = textBoxNameCompany.Text.ToUpper();
                    pathCompanyAndNameCompany = pathCompanyAndNameCompany.Replace(" ","_");
                    pathCompanyAndNameCompany = CorePathOfFolderCompaniesSistemaPlanillas + pathCompanyAndNameCompany;
                    listFoldersCreate.Add(pathCompanyAndNameCompany);
                    //add folder core configuration
                    string CompanyAndCoreConfiguration = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration;
                    listFoldersCreate.Add(CompanyAndCoreConfiguration);
                    //add folder core-configuration
                    string CompanyAndConfiguration = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + formula;
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
                    for(int month=0; month<storageNumberDays.Length; month++)
                    {
                        foreach(string numbers in storageMonths)
                        {
                            if(storageNumberDays[month] == numbers)
                            {
                                ++month;
                                string[] dividedFolders = callToGeneralMethods.getFoldersOFWeeks(storageNumberDays[month]);
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
                    //adding formula
                    string pathFormula = SpecificPathOfFolderConfigurationFormulas;
                    string []storageFormulas = Directory.GetFiles(pathFormula);
                    foreach(string path in storageFormulas)
                    {
                        string pathReadFormula = path;
                        string nameFomula = path.Replace(pathFormula, "");
                        nameFomula = nameFomula.Replace("\\","");
                        string pathWriteFormula = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + formula + "\\" + nameFomula;
                        string[] storageData = File.ReadAllLines(pathReadFormula);
                        FileStream fstreamFormula = new FileStream(pathWriteFormula, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writerFormula = new StreamWriter(fstreamFormula);
                        foreach (string line in storageData)
                        {
                            writerFormula.WriteLine(line);
                        }
                        writerFormula.Close();
                    }
                    //adding Sits
                    string pathSits= SpecificPathOfFolderConfigurationSits;
                    string []storageSits = Directory.GetFiles(pathSits);
                    foreach (string path in storageSits)
                    {
                        string pathReadSits = path;
                        string nameSits = path.Replace(pathSits, "");
                        nameSits = nameSits.Replace("\\", "");
                        nameSits = nameSits.Replace("GLOBAL", "CORE");
                        string[] storageData = File.ReadAllLines(pathReadSits);
                        string pathWriteSits = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + sits + "\\" + nameSits;
                        FileStream fstreamSits = new FileStream(pathWriteSits, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writerSits = new StreamWriter(fstreamSits);
                        foreach (string line in storageData)
                        {
                            writerSits.WriteLine(line);
                        }
                        writerSits.Close();
                    }
                    //here ends the creation of company
                    setDataDefault();
                    MessageBox.Show("EMPRESA CREADA EXITOSAMENTE");
                }
                else if (menuOption == "EDIT")
                {
                    //get number days of months
                    string pathDays = SpecificPathOfFolderConfigurationDaysOfMoths + "days.txt";
                    string[] storageNumberDays = File.ReadAllLines(pathDays);
                    //path to get template
                    string templateName = comboBoxChargeTemplate.Text;
                    templateName = callToGeneralMethods.eraseFirstWhiteSpace(templateName);
                    templateName = templateName.Replace(" ", "_");
                    string pathTemplate = SpecificPathOfFolderConfigurationTemplates + "\\" + templateName + ".txt";
                    string[] storageDataOfTemplate = File.ReadAllLines(pathTemplate);
                    //
                    List<string> addFrom = new List<string>();
                    List<string> eraseFrom = new List<string>();
                    List<string> addTo = new List<string>();
                    List<string> eraseTo = new List<string>();
                    string montChangeFrom = callToGeneralMethods.eraseFirstWhiteSpace(comboBoxFrom.Text);
                    if (remenberComboBoxFrom != montChangeFrom)
                    {
                        bool foundFirstRound = false;
                        for (int monthPhase1 = 0; monthPhase1 < months.Length; monthPhase1++)
                        {
                            if (months[monthPhase1] == montChangeFrom)
                            {
                                for (int monthPhase2 = monthPhase1 ; monthPhase2 <months.Length; monthPhase2++)
                                {
                                    if(months[monthPhase2]==remenberComboBoxFrom)
                                    {
                                        foundFirstRound = true;
                                        break;
                                    }else
                                    {
                                        addFrom.Add(months[monthPhase2]);
                                    }
                                }
                                break;
                            }
                        }
                        if (foundFirstRound == false)
                        {
                            addFrom.Clear();
                            bool foundSecondRound = false;
                            for (int monthPhase1 = 0; monthPhase1 < months.Length; monthPhase1++)
                            {
                                if (months[monthPhase1] == remenberComboBoxFrom)
                                {
                                    for (int monthPhase2 = monthPhase1; monthPhase2 < months.Length; monthPhase2++)
                                    {
                                        if (months[monthPhase2] == montChangeFrom)
                                        {
                                            foundSecondRound = true;
                                            //eraseFrom.Add(months[monthPhase2]);
                                            break;
                                        }
                                        else
                                        {
                                            eraseFrom.Add(months[monthPhase2]);
                                        }
                                    }
                                    break;
                                }
                            }
                            if (foundSecondRound == false)
                            {
                                eraseFrom.Clear();
                            }
                        }
                    }

                    string montChangeTo = callToGeneralMethods.eraseFirstWhiteSpace(comboBoxTo.Text);
                    if (remenberComboBoxTo != montChangeTo)
                    {
                        bool foundFirstRound = false;
                        for (int monthPhase1 = 0; monthPhase1 < months.Length; monthPhase1++)
                        {
                            if (months[monthPhase1] == remenberComboBoxTo)
                            {
                                ++monthPhase1;
                                for (int monthPhase2 = monthPhase1; monthPhase2 < months.Length; monthPhase2++)
                                {
                                    if (months[monthPhase2] == montChangeTo)
                                    {
                                        addTo.Add(months[monthPhase2]);
                                        foundFirstRound = true;
                                        break;
                                    }
                                    else
                                    {
                                        addTo.Add(months[monthPhase2]);
                                    }
                                }
                                break;
                            }
                        }
                        if (foundFirstRound == false)
                        {
                            addTo.Clear();
                            bool foundSecondRound = false;
                            for (int monthPhase1 = 0; monthPhase1 < months.Length; monthPhase1++)
                            {
                                if (months[monthPhase1] == montChangeFrom)
                                {
                                    ++monthPhase1;
                                    ++monthPhase1;
                                    //++monthPhase1;
                                    for (int monthPhase2 = monthPhase1; monthPhase2 < months.Length; monthPhase2++)
                                    {
                                        if (months[monthPhase2] == remenberComboBoxTo)
                                        {
                                            eraseTo.Add(months[monthPhase2]);
                                            foundSecondRound = true;
                                            break;
                                        }
                                        else
                                        {
                                            eraseTo.Add(months[monthPhase2]);
                                        }
                                    }
                                    break;
                                }
                            }
                            if (foundSecondRound == false)
                            {
                                eraseTo.Clear();
                            }
                        }
                    }
                    List<string> subList = new List<string>();
                    List<string> eraseList = new List<string>();
                    foreach (string dept in saveListToEdit)
                    {
                        bool itsContainsDept = false;
                        bool itsContainsFrom= false;
                        bool itsContainsTo= false;
                        foreach (string erase in eraseDeparments)
                        {
                            if(dept.Contains(erase))
                            {
                                itsContainsDept = true;
                                break;
                            }
                        }
                        foreach (string erase in eraseFrom)
                        {
                            if (dept.Contains(erase))
                            {
                                itsContainsFrom = true;
                                break;
                            }
                        }
                        foreach (string erase in eraseTo)
                        {
                            if (dept.Contains(erase))
                            {
                                itsContainsTo = true;
                                break;
                            }
                        }
                        if (itsContainsDept == false && itsContainsFrom ==false && itsContainsTo == false)
                        {
                            subList.Add(dept);
                        }else
                        {
                            eraseList.Add(dept);
                        }
                    }
                    saveListToEdit = subList;
                    List<string> allowedMonth = new List<string>();                  
                    for (int month=0; month<months.Length; month++)
                    {
                        if(months[month]== montChangeFrom)
                        {
                            for (int monthPhase2 = 0; monthPhase2 < months.Length; monthPhase2++)
                            {
                                if (months[monthPhase2] == montChangeTo)
                                {
                                    allowedMonth.Add(months[monthPhase2]);
                                    break;
                                }else
                                {
                                    allowedMonth.Add(months[monthPhase2]);
                                }
                            }
                            break;
                        }
                    }
                    List<string> OnlyCompanies = new List<string>();
                    name = name.Replace(" ","_");
                    string pathCompanyAndNameCompany = CorePathOfFolderCompaniesSistemaPlanillas + name;
                    foreach (ListViewItem deparment in listView1.Items)
                    {
                        string change = callToGeneralMethods.eraseFirstWhiteSpace(deparment.Text);
                        string pathCompanyAndNameCompanyAndMonthAndDays = pathCompanyAndNameCompany + "\\" + change;
                        OnlyCompanies.Add(pathCompanyAndNameCompanyAndMonthAndDays);
                    }
                    List<string> listCreateNew = new List<string>();
                    foreach (string deparment in OnlyCompanies)
                    {
                        listCreateNew.Add(deparment);
                        foreach (string month in allowedMonth)
                        {
                            string pathCompanyAndNameCompanyAndMonthAndDays = deparment + "\\" + month;
                            listCreateNew.Add(pathCompanyAndNameCompanyAndMonthAndDays);
                        }
                    }

                    List<string> subListEdit = new List<string>();
                    List<string> subListNew = new List<string>();
                    foreach (string deparment in listCreateNew)
                    {
                        bool found = false;
                        foreach (string compare in saveListToEdit)
                        {
                            if(deparment == compare)
                            {
                                found = true;
                                break;
                            }
                        }
                        if(found==true)
                        {
                            subListEdit.Add(deparment);
                        }
                        else
                        {
                            subListNew.Add(deparment);
                        }
                    }
                    List<string> subListFilesEdit = new List<string>();
                    foreach(string path in subListEdit)
                    {
                        string []storageFiles=Directory.GetFiles(path);
                        foreach (string file in storageFiles)
                        {
                            subListFilesEdit.Add(file);
                        }
                    }
                    List<string> subListFilesNew= new List<string>();
                    string completeCompany = pathCompanyAndNameCompany;
                    foreach (string path in subListNew)
                    {
                        string change = path.Replace(completeCompany, "");
                        foreach (ListViewItem deparment in listView1.Items)
                        {
                            change = change.Replace(deparment.Text, "");
                        }
                        change = change.Replace("\\", "");
                        for (int month = 0; month < storageNumberDays.Length; month++)
                        {
                            if (storageNumberDays[month] == change)
                            {
                                ++month;
                                string[] folders = callToGeneralMethods.getFoldersOFWeeks(storageNumberDays[month]);
                                foreach(string folder in folders)
                                {
                                    subListFilesNew.Add(path + "\\" + folder+".txt");
                                }
                                break;
                            }
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////
                    
                    foreach(string path in eraseList)
                    {
                        if(Directory.Exists(path))
                        {
                            DirectoryInfo directory = new DirectoryInfo(path);
                            directory.Delete(true);
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////
                    foreach (string path in subListNew)
                    {
                        if(!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////
                    foreach (string path in subListFilesNew)
                    {
                        if (!File.Exists(path))
                        {
                            FileStream fstreamCreateTemplate = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writerReadTemplate = new StreamWriter(fstreamCreateTemplate);
                            foreach (string file in storageDataOfTemplate)
                            {
                                writerReadTemplate.WriteLine(file);
                            }
                            writerReadTemplate.Close();
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////
                    string changeString = callToGeneralMethods.eraseFirstWhiteSpace(comboBoxChargeTemplate.Text);
                    if (changeString != remenberComboBoxTemplate)
                    {
                        string sumDataPhase1 = "";
                        foreach (string line in storageDataOfTemplate)
                        {
                            sumDataPhase1 += line + "\n";
                        }
                        foreach (string path in subListFilesEdit)
                        {
                            if (File.Exists(path))
                            {
                                string sumDataPhase2 = "";
                                string []storageLines = File.ReadAllLines(path);
                                for(int linePhase1=0; linePhase1 < storageLines.Length; linePhase1++)
                                {
                                    if(storageLines[linePhase1]==tagEndHEad)
                                    {
                                        ++linePhase1;
                                        for (int linePhase2 = linePhase1; linePhase2 < storageLines.Length; linePhase2++)
                                        {
                                            sumDataPhase2 += storageLines[linePhase2] + "\n";
                                        }
                                        break;
                                    }
                                }
                                string finalSumData = sumDataPhase1 + sumDataPhase2;
                                string[] finalStorage = finalSumData.Split('\n');
                                File.Delete(path);
                                FileStream fstreamFinal = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter writerFinal = new StreamWriter(fstreamFinal);
                                foreach (string line in finalStorage)
                                {
                                    writerFinal.WriteLine(line);
                                   
                                }
                                writerFinal.Close();
                            }
                        }
                    }
                    //adding Id To File
                    string ID = textBoxLegalID.Text;
                    string pathId = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + exclusiveData + "\\" + "exclusive.txt";
                    if(File.Exists(pathId))
                    {
                        File.Delete(pathId);
                    }
                    FileStream fstreamId = new FileStream(pathId, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writerId = new StreamWriter(fstreamId);
                    writerId.WriteLine(ID);
                    writerId.Close();
                    //adding data To Template folder
                    string pathGetTemplate = pathCompanyAndNameCompany + "\\" + coreExtraConfiguration + "\\" + template + "\\" + templateName + ".txt";
                    if (File.Exists(pathGetTemplate))
                    {
                        File.Delete(pathGetTemplate);
                    }
                    FileStream fstreamTemplate = new FileStream(pathGetTemplate, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writerTemplate = new StreamWriter(fstreamTemplate);
                    foreach (string line in storageDataOfTemplate)
                    {
                        writerTemplate.WriteLine(line);
                    }
                    writerTemplate.Close();
                    

                    MessageBox.Show("EMPRESA EDITADA EXITOSAMENTE");
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
                storageDeparments.Add(textBoxDepartment.Text.ToUpper());
                listView1.Items.Add(textBoxDepartment.Text.ToUpper());
                listNewDepartmentsEdit.Add(textBoxDepartment.Text.ToUpper());
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
                eraseDeparments.Add(listView1.Items[IndexViewList].Text);
                foreach (string deparment in storageDeparments)
                {
                    if (deparment != listView1.Items[IndexViewList].Text)
                    {
                        subList.Add(deparment);
                    }
                }
                listView1.Refresh();
                storageDeparments.Clear();
                storageDeparments = subList;
                subList.Clear();
                foreach (string deparment in listNewDepartmentsEdit)
                {
                    if(deparment!= listView1.Items[IndexViewList].Text)
                    {
                        subList.Add(deparment);
                    }
                }
                listNewDepartmentsEdit.Clear();
                listNewDepartmentsEdit = subList;
                listView1.Items.RemoveAt(IndexViewList);
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
                comboBoxTo.Items.Add(months[dateStart]);
                /*
                if (months[dateStart] == avoidDate)
                {
                    for (int dateEnd = ++dateStart; dateEnd < months.Length; dateEnd++)
                    {
                         comboBoxTo.Items.Add(months[dateEnd]);
                    }
                    dateStart = months.Length;
                    break;
                }
                */
            }
        }

        private void buttonReturnProgram_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY callingMenuStart = new GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY();
            callingMenuStart.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
            callingMenuStart.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
