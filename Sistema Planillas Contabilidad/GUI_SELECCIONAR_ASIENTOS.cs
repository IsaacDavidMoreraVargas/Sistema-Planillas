using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Security.Policy;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_SELECCIONAR_ASIENTOS : Form
    {
        public GUI_SELECCIONAR_ASIENTOS()
        {
            InitializeComponent();
        }

        string opcion1 = "LOCAL";
        string opcion2 = "GLOBAL";
        string orderGlobalOrLocal = "";
        string orderAddOrEdit = "CREATE";
        bool clickOnListView1 = false;
        bool clickOnListView2 = false;
        int indexColumn = 0;

        string debit = "DEBE";
        string credit = "HABE";
        string pathListIn = "";
        string pathListMedium = "";
        string pathSit = "";
        string actualPath = "";

        string actual = Directory.GetCurrentDirectory();

        private void GUI_SELECCIONAR_ASIENTOS_Load(object sender, EventArgs e)
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
        string tagStartChargeFormula = "";
        string tagEndChargeFormula = "";
        string tagStartDebitFormula = "";
        string tagEndDebitFormula = "";
        string tagStartCreditFormula = "";
        string tagEndCreditFormula = "";
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
            tagStartChargeFormula = startTheTagsAndDefaults.tagStartChargeFormula;
            tagEndChargeFormula = startTheTagsAndDefaults.tagEndChargeFormula;
            tagStartDebitFormula = startTheTagsAndDefaults.tagStartDebitFormula;
            tagEndDebitFormula = startTheTagsAndDefaults.tagEndDebitFormula;
            tagStartCreditFormula = startTheTagsAndDefaults.tagStartCreditFormula;
            tagEndCreditFormula = startTheTagsAndDefaults.tagEndCreditFormula;
            //folders inside folders
            coreExtraConfiguration = startFoldersInsideCompany.isCoreExtraConfigurations;
            formula = startFoldersInsideCompany.isFormula;
            exclusiveData = startFoldersInsideCompany.isExclusiveData;
            sits = startFoldersInsideCompany.isSits;
            template = startFoldersInsideCompany.isTemplate;

        }


        private void loadDefaultData()
        {
            if (orderGlobalOrLocal == opcion1)
            {
                comboBox2.Items.Add(opcion1);
            }
            else if (orderGlobalOrLocal == opcion2)
            {
                comboBox2.Items.Add(opcion2);
            }
                comboBox4.Items.Add(debit);
                comboBox4.Items.Add(credit);
                comboBox1.Text = threeLine;
                comboBox3.Text = threeLine;

                if (orderGlobalOrLocal == opcion1)
                {
                    string pathReadFormula = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + sits + "\\" + "CORE-FORMULAS-SITS.txt";
                    if (File.Exists(pathReadFormula))
                    {
                        setData(pathReadFormula);
                    }
                    else
                    {
                        MessageBox.Show("NO ES POSIBLE CARGAR FORMULAS, ARCHIVO NO EXISTE");
                    }
                }
                else if (orderGlobalOrLocal == opcion2)
                {
                    string pathReadFormula = SpecificPathOfFolderConfigurationSits + "GLOBAL-FORMULAS-SITS.txt";
                    if (File.Exists(pathReadFormula))
                    {
                        setData(pathReadFormula);
                    }
                    else
                    {
                        MessageBox.Show("NO ES POSIBLE CARGAR FORMULAS, ARCHIVO NO EXISTE");
                    }
                }

            }

        private void setData(string pathReadFormula)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";

            listView1.View = View.Details;
            listView1.Columns.Add("DEBE");
            listView1.Columns[0].Width = listView1.Width;
            listView2.View = View.Details;
            listView2.Columns.Add("HABE");
            listView2.Columns[0].Width = listView1.Width;

            string[] storageFormulas = File.ReadAllLines(pathReadFormula);
            for (int formula = 0; formula < storageFormulas.Length; formula++)
            {
                if (storageFormulas[formula] == tagStartDebitFormula)
                {
                    ++formula;
                    for (int formulaPhase2 = formula; formulaPhase2 < storageFormulas.Length; formulaPhase2++)
                    {
                        if (storageFormulas[formulaPhase2] == tagEndDebitFormula)
                        {
                            break;
                        }
                        else if (storageFormulas[formulaPhase2] != tagStartFormula && storageFormulas[formulaPhase2] != tagEndFormula)
                        {
                            string[] storageGetHead = storageFormulas[formulaPhase2].Split('=');
                            Invoke(new Action(() => checkedListBox1.Items.Add(storageGetHead[0], false)));
                            comboBox3.Items.Add(storageGetHead[0]);
                            listView1.Items.Add(storageFormulas[formulaPhase2]);
                        }
                    }
                }

                if (storageFormulas[formula] == tagStartCreditFormula)
                {
                    ++formula;
                    for (int formulaPhase2 = formula; formulaPhase2 < storageFormulas.Length; formulaPhase2++)
                    {
                        if (storageFormulas[formulaPhase2] == tagEndCreditFormula)
                        {
                            break;
                        }
                        else if (storageFormulas[formulaPhase2] != tagStartFormula && storageFormulas[formulaPhase2] != tagEndFormula)
                        {
                            string[] storageGetHead = storageFormulas[formulaPhase2].Split('=');
                            Invoke(new Action(() => checkedListBox1.Items.Add(storageGetHead[0], false)));
                            comboBox3.Items.Add(storageGetHead[0]);
                            listView2.Items.Add(storageFormulas[formulaPhase2]);
                        }
                    }
                }
            }

            paint("WHITE", listView1);
            paint("WHITE", listView2);
            paint("COLOR", listView1);
            paint("COLOR", listView2);

            for (int formula = 0; formula < storageFormulas.Length; formula++)
            {
                if (storageFormulas[formula] == tagStartChargeFormula)
                {

                }
                else if (storageFormulas[formula] == tagEndChargeFormula)
                {
                    break;
                }
                else
                {
                    for (int head = 0; head < checkedListBox1.Items.Count; head++)
                    {
                        if (checkedListBox1.Items[head].ToString() == storageFormulas[formula])
                        {
                            checkedListBox1.SetItemChecked(head, true);
                            break;
                        }
                    }
                }
            }

            rewriteCheckList2();
        }
       
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ListView listToStudy = new ListView();
            if (clickOnListView1 == true)
            {
                listToStudy = listView1;
            }
            else if (clickOnListView2 == true)
            {
                listToStudy = listView2;
            }

            if (orderAddOrEdit == "EDIT")
            {
                if (textBox2.Text == "" || textBox2.Text == " ")
                {
                    MessageBox.Show("NO SE EDITARA, YA QUE EL ESPACIO DE FORMULA ESTA EN BLANCO");
                }
                else
                {
                    checkedListBox1.Items[indexColumn] = "";
                    checkedListBox1.Items[indexColumn] = textBox1.Text;
                    string sumString = textBox1.Text + "=" + textBox2.Text;
                    sumString = sumString.ToUpper();
                    listToStudy.Items[indexColumn].Text = sumString;
                    checkedListBox2.Items.Clear();
                }
                textBox2.Text = "";
                textBox1.Text = "";
                orderAddOrEdit = "CREATE";
                buttonCreate.Text = "CREAR ASIENTO";

            }else if(orderAddOrEdit == "CREATE")
            {
                if (textBox1.Text == "" || textBox1.Text == " ")
                {
                    MessageBox.Show("NOMBRE ASIENTO VACIO");
                }
                else if (textBox2.Text == " " || textBox2.Text == "")
                {
                    MessageBox.Show("FORMULA VACIA");
                }
                else if (comboBox2.Text == threeLine)
                {
                    MessageBox.Show("IMPOSIBLE CREAR ASIENTO, LOCACION NO VALIDA");
                }
                else if (comboBox4.Text == threeLine)
                {
                    MessageBox.Show("IMPOSIBLE CREAR ASIENTO, DEBE O HABE NO ELEGIDO PARA ASIENTO");
                }
                else
                {
                    if(comboBox4.Text==debit)
                    {
                        clickOnListView1 = true;
                        clickOnListView2 = false;
                    }
                    else if(comboBox4.Text==credit)
                    {
                        clickOnListView2 = true;
                        clickOnListView1 = false;
                    }

                    if (clickOnListView1 == true)
                    {
                        listToStudy = listView1;
                    }
                    else if (clickOnListView2 == true)
                    {
                        listToStudy = listView2;
                    }
                    string sumString = textBox1.Text + "=" + textBox2.Text;
                    sumString = sumString.ToUpper();
                    string[] storageHead = sumString.Split('=');
                    checkedListBox1.Items.Add(storageHead[0],true);

                    rewriteCheckList2();

                    comboBox3.Items.Add(storageHead[0]);
                    listToStudy.Items.Add(sumString);
                    textBox2.Text = "";
                    textBox1.Text = "";
                    paint("WHITE", listToStudy);
                    paint("COLOR", listToStudy);
                }
            }

            comboBox1.Text = threeLine;
            comboBox2.Text = threeLine;
            comboBox3.Text = threeLine;
            comboBox4.Text = threeLine;

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string path = "";
            if (orderGlobalOrLocal == opcion1)
            {
                path = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + sits + "\\" + "CORE-FORMULAS-SITS.txt";
            }
            else if (orderGlobalOrLocal == opcion2)
            {
                path = SpecificPathOfFolderConfigurationSits + "GLOBAL-FORMULAS-SITS.txt";
            }
            if (listView1.Items.Count == 0 && listView2.Items.Count == 0)
            {
                MessageBox.Show("NO PODRAS GUARGAR YA QUE NO HAS CARGADO NINGUNA FORMULA");
            }
            else
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                string sumString = tagStartChargeFormula + "?";
                for (int head = 0; head < checkedListBox2.Items.Count; head++)
                {
                    sumString += checkedListBox2.Items[head].ToString() + "?";
                }
                sumString += tagEndChargeFormula + "?";
                sumString += tagStartDebitFormula + "?";
                for (int formula = 0; formula < listView1.Items.Count; formula++)
                {
                    sumString += tagStartFormula + "?" + listView1.Items[formula].Text + "?" + tagEndFormula + "?";
                }
                sumString += tagEndDebitFormula + "?";
                sumString += tagStartCreditFormula + "?";
                for (int formula = 0; formula < listView2.Items.Count; formula++)
                {
                    sumString += tagStartFormula + "?" + listView2.Items[formula].Text + "?" + tagEndFormula + "?";
                }
                sumString += tagEndCreditFormula;
                generalMethodToWriteInFiles callToWrite = new generalMethodToWriteInFiles();
                callToWrite.writeInFiles(path,sumString);
                MessageBox.Show("GUARDADO EXITOSAMENTE");
            }
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            if (orderGlobalOrLocal == opcion1)
            {
                string path = "";

                if(comboBox2.Text==opcion1)
                {
                    path = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + sits + "\\" + "CORE-FORMULAS-SITS.txt";
                }
                else if (comboBox2.Text == opcion2)
                {
                    path = SpecificPathOfFolderConfigurationSits + "GLOBAL-FORMULAS-SITS.txt";
                }

                if (File.Exists(path))
                {
                    setData(path);
                }
                else
                {
                    MessageBox.Show("NO ES POSIBLE CARGAR FORMULAS, ARCHIVO NO EXISTE");
                }
            }
            else if (orderGlobalOrLocal == opcion1)
            {
                string pathReadFormula = SpecificPathOfFolderConfigurationSits + "GLOBAL-FORMULAS-SITS.txt";
                if (File.Exists(pathReadFormula))
                {
                    setData(pathReadFormula);
                }
                else
                {
                    MessageBox.Show("NO ES POSIBLE CARGAR FORMULAS, ARCHIVO NO EXISTE");
                }
            }
        }

        private void buttonGenerateSits_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1ValueChanged(object sender, EventArgs e)
        {

            textBox2.Text += comboBox1.Text;
        }

        private void buttonKey1_Click(object sender, EventArgs e)
        {
            //(
            textBox2.Text += "(";
        }

        private void buttonKey2_Click(object sender, EventArgs e)
        {
            //=
            textBox2.Text += "=";
        }

        private void buttonKey3_Click(object sender, EventArgs e)
        {
            //+
            textBox2.Text += "+";
        }

        private void buttonKey4_Click(object sender, EventArgs e)
        {
            //*
            textBox2.Text += "*";
        }

        private void buttonKey5_Click(object sender, EventArgs e)
        {
            //-
            textBox2.Text += "-";
        }

        private void buttonKey6_Click(object sender, EventArgs e)
        {
            // /
            textBox2.Text += "/";
        }

        private void buttonKey8_Click(object sender, EventArgs e)
        {
            textBox2.Text += "%";
        }

        private void buttonKey7_Click(object sender, EventArgs e)
        {
            //)
            textBox2.Text += ")";
        }

        private void buttonRecharge_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = threeLine;
            comboBox2.Text = threeLine;
            comboBox3.Text = threeLine;
            comboBox4.Text = threeLine;
        }

        private void comboBox3ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text += comboBox3.Text;
        }

        private void buttonEliminate_Click(object sender, EventArgs e)
        {
            string nameFormula = "";
            ListView listToStudy = new ListView();
            if(clickOnListView1==true)
            {
                listToStudy = listView1;
                nameFormula = listToStudy.Items[indexColumn].Text;
            }
            else if (clickOnListView2 == true)
            {
                listToStudy = listView2;
                nameFormula = listToStudy.Items[indexColumn].Text;
            }
            DialogResult eliminate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR LAS FORMULA: "+nameFormula+" ?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (eliminate)
            {
                case DialogResult.Yes:
                    string[] storageFormula = nameFormula.Split('=');
                    listToStudy.Items.RemoveAt(indexColumn);
                    for (int head = 0; head < checkedListBox1.Items.Count; head++)
                    {
                        if (checkedListBox1.Items[head].ToString() == storageFormula[0])
                        {
                            checkedListBox1.Items.RemoveAt(head);
                            break;
                        }
                    }

                    rewriteCheckList2();

                    MessageBox.Show("FORMULA ELIMINADA EXITOSAMENTE");
                    break;
                case DialogResult.No:
                break;
            }
                
        }

        private void comboCheckListValueChanged(object sender, ItemCheckEventArgs e)
        {
            rewriteCheckList2();
        }

        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            rewriteCheckList2();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rewriteCheckList2();
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

        public void rewriteCheckList2()
        {
            checkedListBox2.Items.Clear();
            for (int head = 0; head < checkedListBox1.Items.Count; head++)
            {
                if (checkedListBox1.GetItemChecked(head) == true)
                {
                    Invoke(new Action(() => checkedListBox2.Items.Add(checkedListBox1.Items[head], true)));
                }
            }
        }

        public void lisfOFHeads(List<string> listOfHeadsReceived)
        {
            foreach(string head in listOfHeadsReceived)
            {
                comboBox1.Items.Add(head);
            }
        }
        public void menuGlobalOrLocal(string orderReceiVed)
        {
            orderGlobalOrLocal = orderReceiVed;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clickOnListView1 = true;
            clickOnListView2 = false;
            indexColumn = listView1.FocusedItem.Index;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clickOnListView2 = true;
            clickOnListView1 = false;
            indexColumn = listView2.FocusedItem.Index;
        }

        private void buttonEditFormula_Click(object sender, EventArgs e)
        {
            buttonCreate.Text = "GUARDAR CAMBIO";
            orderAddOrEdit = "EDIT";
            ListView listToStudy = new ListView();
            if (clickOnListView1 == true)
            {
                listToStudy = listView1;
            }
            else if (clickOnListView2 == true)
            {
                listToStudy = listView2;
            }
            textBox2.Text = "";
            string[] storageFormula = listToStudy.Items[indexColumn].Text.Split('=');
            textBox1.Text = storageFormula[0];
            textBox2.Text= storageFormula[1];
        }

        private void paint(string order, ListView listToStudy)
        {
            int index = 0;
            foreach (ListViewItem item in listToStudy.Items)
            {
                if ((index % 2) == 0)
                {
                    if(order=="WHITE")
                    {
                        item.BackColor = Color.White;
                    }
                    else if (order == "COLOR")
                    {
                        item.BackColor = Color.LightBlue;
                    }   
                }
                ++index;
            }
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
