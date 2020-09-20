using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_CREATE_FORMULA : Form
    {
        public GUI_CREATE_FORMULA()
        {
            InitializeComponent();
        }

        string opcion1 = "LOCAL";
        string opcion2 = "GLOBAL";
        string orderGlobalOrLocal = "";
        string edit = "EDITAR";
        string orderAddOrEdit = "";
        int indexColumn = 0;

        private void GUI_CREATE_FORMULA_Load(object sender, EventArgs e)
        {
            loadDefaultData();
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
        string tagStartHEad = "";
        string tagEndHEad = "";
        string tagStartLine = "";
        string tagEndLine = "";
        string tagStartDataGrid1 = "";
        string tagEndDataGrid1 = "";
        string tagStartDataGrid2 = "";
        string tagEndDataGrid2 = "";
        string tagStartDataGrid3 = "";
        string tagEndDataGrid3 = "";
        string tagStartDataGrid4 = "";
        string tagEndDataGrid4 = "";
        string tagStartFormula = "";
        string tagEndFormula = "";
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
            tagStartHEad = startTheTagsAndDefaults.isTagStartHead;
            tagEndHEad = startTheTagsAndDefaults.isTagEndHead;
            tagStartLine = startTheTagsAndDefaults.isTagStartLine;
            tagEndLine = startTheTagsAndDefaults.isTagEndLine;
            tagStartDataGrid1 = startTheTagsAndDefaults.tagStartDataGrid1;
            tagEndDataGrid1 = startTheTagsAndDefaults.tagEndDataGrid1;
            tagStartDataGrid2 = startTheTagsAndDefaults.tagStartDataGrid2;
            tagEndDataGrid2 = startTheTagsAndDefaults.tagEndDataGrid2;
            tagStartDataGrid3 = startTheTagsAndDefaults.tagStartDataGrid3;
            tagEndDataGrid3 = startTheTagsAndDefaults.tagEndDataGrid3;
            tagStartDataGrid4 = startTheTagsAndDefaults.tagStartDataGrid4;
            tagEndDataGrid4 = startTheTagsAndDefaults.tagEndDataGrid4;
            tagStartFormula = startTheTagsAndDefaults.tagStartFormula;
            tagEndFormula = startTheTagsAndDefaults.tagEndFormula;
            //folders inside folders
            coreExtraConfiguration = startFoldersInsideCompany.isCoreExtraConfigurations;
            formula = startFoldersInsideCompany.isFormula;
            exclusiveData = startFoldersInsideCompany.isExclusiveData;
            sits = startFoldersInsideCompany.isSits;
            template = startFoldersInsideCompany.isTemplate;

        }

        private void loadDefaultData()
        {
            textBox1.Text = "";
            comboBoxCharge.Items.Clear();
            comboBoxSave.Items.Clear();
            comboBoxCharge.Items.Add(opcion1);
            comboBoxCharge.Items.Add(opcion2);
            comboBoxSave.Items.Add(opcion1);
            comboBoxSave.Items.Add(opcion2);

            if(orderGlobalOrLocal=="LOCAL")
            {
                listView1.View = View.Details;
                listView1.Columns.Add("FORMULAS");
                listView1.Columns[0].Width = listView1.Width;
                string pathReadFormula = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\"+deparment+ "\\" + month+ "\\" + "CORE-FORMULAS.txt";
                if (File.Exists(pathReadFormula))
                {
                    string[] storageFormulas = File.ReadAllLines(pathReadFormula);
                    foreach (string formula in storageFormulas)
                    {
                        if (formula != tagStartFormula && formula != tagEndFormula)
                        {
                            listView1.Items.Add(formula);
                        }
                    }
                    int index = 0;
                    foreach(ListViewItem item in listView1.Items)
                    {
                        if ((index % 2) == 0)
                        {
                            item.BackColor = Color.LightBlue;
                        }
                        ++index;
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (orderAddOrEdit == "EDITAR")
            {
                listView1.Items[indexColumn].Text = textBox1.Text;
                orderAddOrEdit = "";
                MessageBox.Show("EDITADO EXITOSAMENTE");
            }
            else
            {
                listView1.Items.Add(textBox1.Text);
            }
            textBox1.Text = "";
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBoxCharge.Items.Clear();
            comboBoxSave.Items.Clear();
            comboBoxCharge.Text=threeLine;
            comboBoxCharge.Items.Add(opcion1);
            comboBoxCharge.Items.Add(opcion2);
            comboBoxSave.Text = threeLine;
            comboBoxSave.Items.Add(opcion1);
            comboBoxSave.Items.Add(opcion2);
        }

        private void combox1Add(object sender, EventArgs e)
        {
            textBox1.Text += comboBox1.Text;
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            string path = "";
            if (comboBoxSave.Text == threeLine)
            {
                MessageBox.Show("IMPOSIBLE CARGAR, UBICACION CARGAR NO ELEGIDA");
            }
            else if (orderGlobalOrLocal == opcion1)
            {
                if (comboBoxSave.Text == opcion1)
                {
                    path = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + "CORE-FORMULAS.txt";
                    //MessageBox.Show(path);
                }
                else if (comboBoxSave.Text == opcion2)
                {
                    path = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + formula + "\\" + "GLOBAL-FORMULAS.txt";
                    //MessageBox.Show(path);
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                string addLines = "";
                foreach(ListViewItem formula in listView1.Items)
                {
                    addLines+=tagStartFormula+"?"+formula.Text+"?"+tagEndFormula+"?";
                }
                generalMethodToWriteInFiles callToWrite = new generalMethodToWriteInFiles();
                callToWrite.writeInFiles(path, addLines);
                MessageBox.Show("FORMULAS GUARDADAS EXITOSAMENTE");
            }
            else if (orderGlobalOrLocal == opcion2)
            {
                path = SpecificPathOfFolderConfigurationFormulas + "GLOBAL-FORMULAS.txt";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                string addLines = "";
                foreach (ListViewItem formula in listView1.Items)
                {
                    addLines += tagStartFormula + "?" + formula.Text + "?" + tagEndFormula + "?";
                }
                generalMethodToWriteInFiles callToWrite = new generalMethodToWriteInFiles();
                callToWrite.writeInFiles(path, addLines);
                MessageBox.Show("FORMULAS GUARDADAS EXITOSAMENTE");
            }
        }

        private void buttonKey1_Click(object sender, EventArgs e)
        {
            //(
            textBox1.Text += "(";
        }

        private void buttonKey2_Click(object sender, EventArgs e)
        {
            //=
            textBox1.Text += "=";
        }

        private void buttonKey3_Click(object sender, EventArgs e)
        {
            //+
            textBox1.Text += "+";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //x
            textBox1.Text += "*";
        }

        private void buttonKey5_Click(object sender, EventArgs e)
        {
            //-
            textBox1.Text += "-";
        }

        private void buttonKey6_Click_1(object sender, EventArgs e)
        {
            // /
            textBox1.Text += "/";
        }

        private void buttonKey6_Click(object sender, EventArgs e)
        {
            //)
            textBox1.Text += ")";
        }

        private void buttonNew_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            string path = "";
            
            if (comboBoxCharge.Text == threeLine)
            {
                MessageBox.Show("IMPOSIBLE CARGAR, UBICACION CARGAR NO ELEGIDA");
            }else if (orderGlobalOrLocal == opcion1)
            {
                if (comboBoxCharge.Text == opcion1)
                {
                    path = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + "CORE-FORMULAS.txt";
                    //MessageBox.Show(path);
                }
                else if(comboBoxCharge.Text == opcion2)
                {
                    path = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" +coreExtraConfiguration + "\\" + formula + "\\" + "GLOBAL-FORMULAS.txt";
                    //MessageBox.Show(path);
                }

                if(File.Exists(path))
                {
                    string[] storageFormulas = File.ReadAllLines(path);
                    listView1.Items.Clear();
                    listView1.View = View.Details;
                    listView1.Columns.Add("FORMULAS");
                    listView1.Columns[0].Width = listView1.Width;
                    foreach(string formula in storageFormulas)
                    {
                        if (formula != tagStartFormula && formula != tagEndFormula)
                        {
                            listView1.Items.Add(formula);
                        }
                    }
                    int index = 0;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if ((index % 2) == 0)
                        {
                            item.BackColor = Color.LightBlue;
                        }
                        ++index;
                    }
                }
                else
                {
                    MessageBox.Show("NO SE PUEDEN CARGAR FORMULAS, YA QUE NO EXISTE NINGUN ARCHIVO DE FORMULAS");
                }
            }else if (orderGlobalOrLocal == opcion2)
            {
                path = SpecificPathOfFolderConfigurationFormulas + "GLOBAL-FORMULAS.txt";
                if (File.Exists(path))
                {
                    string[] storageFormulas = File.ReadAllLines(path);
                    listView1.Items.Clear();
                    listView1.View = View.Details;
                    listView1.Columns.Add("FORMULAS");
                    listView1.Columns[0].Width = listView1.Width;
                    foreach (string formula in storageFormulas)
                    {
                        if (formula != tagStartFormula && formula != tagEndFormula)
                        {
                            listView1.Items.Add(formula);
                        }
                    }
                    int index = 0;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if ((index % 2) == 0)
                        {
                            item.BackColor = Color.LightBlue;
                        }
                        ++index;
                    }
                }
                else
                {
                    MessageBox.Show("NO SE PUEDEN CARGAR FORMULAS, YA QUE NO EXISTE NINGUN ARCHIVO DE FORMULAS");
                }
            }
            
        }


        private void buttonEliminate_Click(object sender, EventArgs e)
        {
            DialogResult eliminate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR LA FORMULA "+listView1.Items[indexColumn].Text+" ?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (eliminate)
            {
                case DialogResult.Yes:
                    listView1.Items.RemoveAt(indexColumn);
                break;
                case DialogResult.No:
                break;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexColumn = listView1.FocusedItem.Index;
        }

        public void lisftOfHeads(List<string> listReceived)
        {
            foreach (string head in listReceived)
            {
                comboBox1.Items.Add(head);
            }
        }

        string company = "";
        string deparment = "";
        string month = "";
        public void PathToCompany(string companyReceive, string deptReceive, string monthReceive)
        {
            company = companyReceive;
            deparment = deptReceive;
            month = monthReceive;
        }

        public void menuGlobalOrLocal(string orderReceiVed)
        {
            orderGlobalOrLocal = orderReceiVed;
        }

        private void buttonCloseProgram_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        /*
        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        */
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = listView1.Items[indexColumn].Text;
            orderAddOrEdit = "EDITAR";
        }
    }
}
