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
        string [] months = new string[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        
        public GUI_CREAR_EMPRESA()
        {
            InitializeComponent();
        }
        string FinalPath = "";
        string FinalPath1 = "";
        string FinalPath2 = "";
        string exclusive = "";
        string name = "";
        string avoid = "configuration";
        string avoid1 = "exclusiveData";
        string avoid2 = "Sits";
        string avoid3 = "DEPARTAMENTOS";
        List<string> deparmentsOntime = new List<string>();
        string[] templates;
        string[] deparments;
        bool menuOption;
        private void GUI_CREAR_EMPRESA_Load(object sender, EventArgs e)
        {
            if (menuOption == false)
            {
                chargeData();
            }
            else
            {
                buttonGenerateCompany.Text = "Editar";
                chargeDataEdit();
            }
        }

        
        private void chargeData()
        {
            buttonGenerateCompany.Visible = false;
            comboBoxFrom.Text = "----";
            comboBoxTo.Text = "----";
            foreach (string item in months)
            {
                comboBoxFrom.Items.Add(item);
                comboBoxTo.Items.Add(item);
            }
            FinalPath =Directory.GetCurrentDirectory();
            FinalPath = FinalPath.Replace("\\bin\\Debug", "\\Companies");
            FinalPath2 = Directory.GetCurrentDirectory();
            FinalPath2 = FinalPath2.Replace("\\bin\\Debug", "\\configuration");
            FinalPath1 = FinalPath2 + "\\Templates";
            string[] filename = Directory.GetFiles(FinalPath1);

            comboBoxChargeTemplate.Text = "----";
            foreach (string item in filename)
            {
                string addItem = item.Replace("_", " ");
                if (addItem == "" || addItem == " " || addItem == "_")
                {
                    //do nothing
                }
                else 
                {
                    string erase = FinalPath1 + "\\";
                    addItem = addItem.Replace(erase, "");
                    addItem = addItem.Replace(".txt", "");
                    comboBoxChargeTemplate.Items.Add(addItem);
                }
                
            }
            listView1.View = View.Details;
            listView1.Columns[0].Width = listView1.Width;
            listView1.Columns[0].Text = "DEPARTAMENTOS";
        }

        private void chargeDataEdit()
        {
            textBoxNameCompany.Text = "";
            textBoxLegalID.Text = "";
            comboBoxFrom.Items.Clear();
            comboBoxTo.Items.Clear();
            comboBoxChargeTemplate.Items.Clear();
            listView1.Items.Clear();
            comboBoxFrom.Text = "----";
            comboBoxTo.Text = "----";
            listView1.View = View.Details;
            listView1.Columns[0].Width = listView1.Width;
            listView1.Columns[0].Text = "DEPARTAMENTOS";
            foreach (string item in months)
            {
                comboBoxFrom.Items.Add(item);
                comboBoxTo.Items.Add(item);
            }
            textBoxNameCompany.Text = name;
            name = name.Replace(" ","_");
            buttoneEraseDepartment.Visible = true;
            departmentWasIntrouced = true;
            listView1.Visible = true;
            FinalPath = Directory.GetCurrentDirectory();
            FinalPath = FinalPath.Replace("\\bin\\Debug", "\\Companies");
            string pathId = FinalPath + "\\" + name + "\\" + "exclusiveData" + "\\" + "exclusive.txt";
            textBoxLegalID.Text = File.ReadAllText(pathId);
            string pathCompany = FinalPath + "\\" + name;
            deparments = Directory.GetDirectories(pathCompany);
            foreach (string item in deparments)
            {
                string change = item.Replace(pathCompany, "");
                change = change.Replace("_"," ");
                change = change.Replace("\\", " ");
                if (change.Contains(avoid) || change.Contains(avoid1) || change.Contains(avoid2))
                { 
                
                }else
                {
                    StringBuilder sb = new StringBuilder(change);
                    if (sb[0] == ' ')
                    {
                        string sum = "";
                        for (int letter = 1; letter < change.Length; letter++)
                        {

                            sum += change[letter];
                        }
                        change = sum;
                    }
                    listView1.Items.Add(change);
                    deparmentsOntime.Add(change);
                }
                
            }
            comboBoxChargeTemplate.Text = "----";
            FinalPath2 = Directory.GetCurrentDirectory();
            FinalPath2 = FinalPath2.Replace("\\bin\\Debug", "\\configuration");
            string pathTemplates = FinalPath2 + "\\Templates";
            templates = Directory.GetFiles(pathTemplates);
            foreach (string item in templates)
            {
                string change = item.Replace(pathTemplates, "");
                change = change.Replace("_", " ");
                change = change.Replace("\\", " ");
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
            if (menuOption == false)
            {
                if (textBoxNameCompany.Text == "" || textBoxNameCompany.Text == " ")
                {
                    MessageBox.Show("NOMBRE COMPAÑIA VACIO");
                }
                else if (comboBoxFrom.Text == "----")
                {
                    MessageBox.Show("FECHA DESDE VACIA");
                }
                else if (comboBoxTo.Text == "----")
                {
                    MessageBox.Show("FECHA HASTA VACIA");
                }
                else if (comboBoxChargeTemplate.Text == "----" || comboBoxChargeTemplate.Text == "")
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

                    //adding days of month to string
                    string pathDays = FinalPath2 + "\\" + "DaysOfMoths" + "\\days.txt";
                    string[] numberDays = File.ReadAllLines(pathDays);
                    //adding folder company
                    List<string> company = new List<string>();
                    string CreateDirectoryRoot = FinalPath;
                    company.Add(CreateDirectoryRoot);
                    //adding name company
                    string createCompany = CreateDirectoryRoot;
                    string nameCompany = textBoxNameCompany.Text;
                    nameCompany = nameCompany.Replace(" ", "_");
                    createCompany += "\\" + nameCompany;
                    company.Add(createCompany);
                    string configurationFolder = createCompany + "\\" + "configuration";
                    company.Add(configurationFolder);
                    exclusive = createCompany + "\\" + "exclusiveData";
                    company.Add(exclusive);
                    //adding deparments folders
                    string createDepartement = createCompany;
                    createDepartement += "\\";
                    List<string> allowDepartments = new List<string>();
                    foreach (string deparments in storageDeparments)
                    {
                        string depa = deparments.Replace(" ", "_");
                        depa = createDepartement + depa;
                        allowDepartments.Add(depa);
                    }
                    //adding monts allowed
                    List<string> allowMonths = new List<string>();
                    for (int startMoth = 0; startMoth < months.Length; startMoth++)
                    {
                        if (months[startMoth] == comboBoxFrom.Text)
                        {
                            for (int endMoth = startMoth; endMoth < months.Length; endMoth++)
                            {
                                if (months[endMoth] == comboBoxTo.Text)
                                {
                                    allowMonths.Add(months[endMoth]);
                                    startMoth = months.Length;
                                    break;
                                }
                                else
                                {
                                    allowMonths.Add(months[endMoth]);
                                }
                            }
                        }
                    }

                    string creatingPathDep = "";
                    List<string> pathWihTemplates = new List<string>();
                    for (int deparment = 0; deparment < allowDepartments.Count; deparment++)
                    {
                        company.Add(allowDepartments[deparment]);
                        for (int mont = 0; mont < allowMonths.Count; mont++)
                        {
                            for (int listMont = 0; listMont < months.Length; listMont++)
                            {
                                if (allowMonths[mont] == months[listMont])
                                {
                                    creatingPathDep = allowDepartments[deparment].ToString() + "\\" + allowMonths[mont];
                                    company.Add(creatingPathDep);
                                    string returnReceive = receivedFolder(numberDays[listMont]);
                                    string[] Folders = returnReceive.Split(',');
                                    string getTemplateNameForFolder = comboBoxChargeTemplate.Text;
                                    getTemplateNameForFolder = getTemplateNameForFolder.Replace(" ", "_");
                                    getTemplateNameForFolder += ".txt";
                                    for (int folder = 0; folder < Folders.Length; folder++)
                                    {
                                        creatingPathDep = allowDepartments[deparment].ToString() + "\\" + allowMonths[mont] + "\\" + Folders[folder];
                                        company.Add(creatingPathDep);
                                        creatingPathDep = allowDepartments[deparment].ToString() + "\\" + allowMonths[mont] + "\\" + Folders[folder] + "\\" + getTemplateNameForFolder;
                                        pathWihTemplates.Add(creatingPathDep);
                                    }
                                }
                            }
                        }
                    }

                    string getTemplateName = comboBoxChargeTemplate.Text;
                    getTemplateName = getTemplateName.Replace(" ", "_");
                    getTemplateName += ".txt";
                    string readPath = FinalPath1 + "\\" + getTemplateName;
                    string[] lines = File.ReadAllLines(readPath);
                    bool successTask = true;
                    foreach (string directory in company)
                    {
                        try
                        {
                            if (!Directory.Exists(directory))
                            {
                                //MessageBox.Show(directory);
                                Directory.CreateDirectory(directory);
                            }
                        }
                        catch (Exception)
                        {
                            successTask = false;
                        }
                    }

                    if (successTask == true)
                    {
                        foreach (string writePath in pathWihTemplates)
                        {
                            if (!File.Exists(writePath))
                            {
                                FileStream fs = new FileStream(writePath, FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter writer = new StreamWriter(fs);
                                foreach (string line in lines)
                                {
                                    writer.WriteLine(line);
                                }
                                writer.Close();
                            }
                        }
                        exclusive += "\\" + "exclusive.txt";
                        if (!File.Exists(exclusive))
                        {
                            FileStream fs = new FileStream(exclusive, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            writer.WriteLine(textBoxLegalID.Text);
                            writer.Close();
                        }
                        textBoxNameCompany.Text = "";
                        comboBoxFrom.Text = "----";
                        comboBoxTo.Text = "----";
                        comboBoxChargeTemplate.Text = "----";
                        listView1.Items.Clear();
                        listView1.Visible = false;
                        buttoneEraseDepartment.Visible = false;
                        storageDeparments.Clear();
                        MessageBox.Show("EMPRESA CREADA EXITOSAMENTE");
                    }
                    else
                    {
                        MessageBox.Show("SUCEDIO UN ERROR CREANDO EMPRESA");
                    }

                }
            }
            else
            {
                if (textBoxNameCompany.Text == "" || textBoxNameCompany.Text == " ")
                {
                    MessageBox.Show("NOMBRE COMPAÑIA VACIO");
                }
                else if (comboBoxFrom.Text == "----")
                {
                    MessageBox.Show("FECHA DESDE VACIA");
                }
                else if (comboBoxTo.Text == "----")
                {
                    MessageBox.Show("FECHA HASTA VACIA");
                }
                else if (comboBoxChargeTemplate.Text == "----" || comboBoxChargeTemplate.Text == "")
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
                    FinalPath = Directory.GetCurrentDirectory();
                    name = name.Replace(" ", "_");
                    FinalPath = FinalPath.Replace("\\bin\\Debug", "\\Companies");
                    string pathCompany = FinalPath + "\\" + name;// + "\\" + "exclusiveData" + "\\" + "exclusive.txt";
                    FinalPath2 = Directory.GetCurrentDirectory();
                    FinalPath2 = FinalPath2.Replace("\\bin\\Debug", "\\configuration");
                    string template = comboBoxChargeTemplate.Text;
                    string change = "";
                    
                    for(int letter=0; letter<template.Length; letter++)
                    {
                        if (template[letter] == ' '&&letter==0)
                        {

                        }
                        else
                        {
                            change += template[letter];
                        }
                    }
                    template = change;
                    template = template.Replace(" ", "_");
                    FinalPath1 = FinalPath2 + "\\Templates" + "\\"+ template;
                    string[] lines = File.ReadAllLines(FinalPath1);
                    List<string> DepartmentsErase = new List<string>();
                    List<string> DepartmentsAdd = new List<string>();
                    List<string> FilesAdd = new List<string>();
                    //List<string> MonthAdd = new List<string>();
                    foreach (ListViewItem item in listView1.Items)
                    {
                        change = item.Text;
                        if (change == avoid3 || change == " " || change == "")
                        {

                        }
                        else
                        {
                            bool found = false;
                            foreach (string dept in deparmentsOntime)
                            {
                                if (dept == change)
                                {
                                    found = true;
                                    break;
                                }
                            }
                            change = change.Replace(" ", "_");
                            change = change.ToUpper();
                            if (found == false)
                            {
                                string depa = FinalPath + "\\" + name + "\\" + change;
                                DepartmentsAdd.Add(depa);
                                for (int month = 0; month < months.Length; month++)
                                {
                                    if (months[month] == comboBoxFrom.Text)
                                    {
                                        for (int month2 = month; month2 < months.Length; month2++)
                                        {
                                            depa = FinalPath + "\\" + name + "\\" + change + "\\" + months[month2];
                                            if (months[month2] == comboBoxTo.Text)
                                            {
                                                DepartmentsAdd.Add(depa);
                                                string pathDays = FinalPath2 + "\\" + "DaysOfMoths" + "\\days.txt";
                                                string[] numberDays = File.ReadAllLines(pathDays);
                                                string returnReceive = receivedFolder(numberDays[month2]);
                                                string[] Folders = returnReceive.Split(',');
                                                for (int day = 0; day < Folders.Length; day++)
                                                {
                                                    depa = FinalPath + "\\" + name + "\\" + change + "\\" + months[month2] + "\\" + Folders[day];
                                                    DepartmentsAdd.Add(depa);
                                                    depa = FinalPath + "\\" + name + "\\" + change + "\\" + months[month2] + "\\" + Folders[day] + "\\" + template;
                                                    FilesAdd.Add(depa);
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                DepartmentsAdd.Add(depa);
                                                string pathDays = FinalPath2 + "\\" + "DaysOfMoths" + "\\days.txt";
                                                string[] numberDays = File.ReadAllLines(pathDays);
                                                string returnReceive = receivedFolder(numberDays[month2]);
                                                string[] Folders = returnReceive.Split(',');
                                                for (int day = 0; day < Folders.Length; day++)
                                                {
                                                    depa = FinalPath + "\\" + name + "\\" + change + "\\" + months[month2] + "\\" + Folders[day];
                                                    DepartmentsAdd.Add(depa);
                                                    depa = FinalPath + "\\" + name + "\\" + change + "\\" + months[month2] + "\\" + Folders[day] + "\\" + template;
                                                    FilesAdd.Add(depa);
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                /*
                                depa = FinalPath + "\\" + name + "\\" + change + "\\" + avoid;
                                DepartmentsAdd.Add(depa);
                                depa = FinalPath + "\\" + name + "\\" + change + "\\" + avoid1;
                                DepartmentsAdd.Add(depa);
                                depa = FinalPath + "\\" + name + "\\" + change + "\\" + avoid2;
                                DepartmentsAdd.Add(depa);
                                */
                            }
                        }
                    }
                    foreach (string dept in deparmentsOntime)
                    {
                        change = dept;
                        bool found = false;
                        foreach (ListViewItem item in listView1.Items)
                        {
                            if (change == avoid3 || change == " " || change == "")
                            {

                            }
                            else
                            {
                                if (item.Text == dept)
                                {
                                    found = true;
                                }
                            }

                        }
                        change = change.Replace(" ", "_");
                        if (found == false)
                        {
                            string depa = FinalPath + "\\" + name + "\\" + change;
                            DepartmentsErase.Add(depa);
                        }
                    }
                    
                    foreach (string item in DepartmentsErase)
                    {
                        Directory.Delete(item, true);
                    }

                    foreach (string item in DepartmentsAdd)
                    {
                        Directory.CreateDirectory(item);
                    }

                    foreach (string item in FilesAdd)
                    {
                        FileStream fs = new FileStream(item, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs);
                        foreach (string line in lines)
                        {
                            writer.WriteLine(line);
                        }
                        writer.Close();
                    }
                    chargeDataEdit();
                    MessageBox.Show("EMPRESA ACTUALIZADA EXITOSAMENTE");
                }
            }
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

        private void label2_Click(object sender, EventArgs e)
        {
            //DONOTHING
        }

        private string receivedFolder(string number) 
        {
            int maximun = Int32.Parse(number);
            int endWeek = 7;
            int limit =0;
            string maximunNumberFolder = "";

            for (int start = 1; start < maximun; start++)
            {
                if (start == endWeek)
                {
                    if (limit < 3)
                    {
                        maximunNumberFolder += start.ToString() + ",";
                        endWeek += 7;
                        ++limit;
                    }
                }
            }

            string[] storageStart = maximunNumberFolder.Split(',');
            string returnFolders = "";
            returnFolders += (Int32.Parse(storageStart[0]) - 6) + "-" + storageStart[0] + ",";
            returnFolders += (Int32.Parse(storageStart[1]) - 6) + "-" + storageStart[1] + ","; 
            returnFolders += (Int32.Parse(storageStart[2]) - 6) + "-" + storageStart[2] + ",";
            returnFolders += (Int32.Parse(storageStart[2])+1) + "-" + number;
            return returnFolders;
        }

        
        private void ReloadDataComboX(object sender, EventArgs e)
        {
            string avoidDate = comboBoxFrom.Text;
            comboBoxTo.Items.Clear();
            comboBoxTo.Text = "----";

            for (int dateStart = 0; dateStart < months.Length; dateStart++)
            {
                if (months[dateStart]== avoidDate)
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
        
        int IndexViewList = 0;
        private void IndexChangeViewList(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null) return;
            IndexViewList = listView1.FocusedItem.Index;
            
        }

        private void buttonEraseDepartment_Click(object sender, EventArgs e)
        {
            if (listView1.Items[IndexViewList].Text == "" || listView1.Items[IndexViewList].Text.Contains("DEPARTAMENTOS"))
            {
                MessageBox.Show("SELECCIONA UN DEPARTAMENTO VALIDO PARA ELIMINAR");
            }
            else
            {
                listView1.Items.RemoveAt(IndexViewList);
                listView1.Refresh();
            }
           
        }

        public void optionMenu(bool option)
        {
            menuOption = option;
        }

        public void receivedNameCompany(string companyName)
        {
            name = companyName;
        }

    }
}
