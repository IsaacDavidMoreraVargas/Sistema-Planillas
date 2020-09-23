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

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_CREAR_EDITAR_CODIGOS_DIASMES : Form
    {
        public GUI_CREAR_EDITAR_CODIGOS_DIASMES()
        {
            InitializeComponent();
        }
        string pathOfCompany = "";
        string SelectedCompany = "";

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

        string coreExtraConfiguration = "";
        string threeLine = "";
        string deparmentValue = "";
        string formula = "";
        string exclusiveData = "";
        string sits = "";
        string template = "";

        string startHead = "";
        string endHead = "";

        int indexColumn = 0;
        string orderSaveOfSaveFile = "SAVEFILE";
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
            //CorePathOfPicturesFolderSistemaPlanillas = startThePaths.CorePathOfPicturesFolderSistemaPlanillas;
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
            formula = startFoldersInsideCompanyReceived.isFormula;
            exclusiveData = startFoldersInsideCompanyReceived.isExclusiveData;
            sits = startFoldersInsideCompanyReceived.isSits;
            template = startFoldersInsideCompany.isTemplate;
            //default tags
            startHead = startTheTagsAndDefaultsReceived.isTagStartHead;
            endHead = startTheTagsAndDefaultsReceived.isTagEndHead;
        }

        string optionMenu = "";
        private void GUI_CREAR_EDITAR_CODIGOS_DIASMES_Load(object sender, EventArgs e)
        {
            startChargeData();
        }

        private void startChargeData()
        {
            string path = "";
            listView1.View = View.Details;
            if (optionMenu == "HEADS")
            {
                path = SpecificPathOfFolderConfigurationAvoidData + "avoid.txt";
                listView1.Columns.Clear();
                listView1.Columns.Add("CABEZALES");
                listView1.Columns[0].Width = listView1.Width;
                if (File.Exists(path))
                {
                    string[] storageData = File.ReadAllLines(path);
                    for (int data = 0; data < storageData.Length; data++)
                    {
                        listView1.Items.Add(storageData[data]);
                    }
                    paint(listView1, "COLOR");
                }
            }
            else if (optionMenu=="CODE")
            {
                path = SpecificPathOfFolderConfigurationCodesSits+ "codes.txt";
                listView1.Columns[0].Text = "NOMBRE";
                listView1.Columns[0].Width = listView1.Width / 2;
                listView1.Columns[1].Text = "CODIGO";
                listView1.Columns[1].Width = listView1.Width / 2;
                if (File.Exists(path))
                {
                    ListViewItem item;
                    string[] storageData = File.ReadAllLines(path);
                    for (int data=0;data<storageData.Length;data++)
                    {
                        item = new ListViewItem(storageData[data]);
                        try
                        {
                            ++data;
                            item.SubItems.Add(storageData[data]);
                            listView1.Items.Add(item);
                        }
                        catch (Exception) { }
                    }
                }
                paint(listView1, "COLOR");
            }
            else if(optionMenu=="DAYS")
            {
                path = SpecificPathOfFolderConfigurationDaysOfMoths + "days.txt";
                listView1.Columns[0].Text = "DIA";
                listView1.Columns[0].Width = listView1.Width / 2;
                listView1.Columns[1].Text = "CANTIDAD DIAS";
                listView1.Columns[1].Width = listView1.Width / 2;
                if (File.Exists(path))
                {
                    ListViewItem item;
                    string[] storageData = File.ReadAllLines(path);
                    for (int data = 0; data < storageData.Length; data++)
                    {
                        item = new ListViewItem(storageData[data]);
                        try
                        {
                            ++data;
                            item.SubItems.Add(storageData[data]);
                            listView1.Items.Add(item);
                        }
                        catch (Exception) { }
                    }
                }
                paint(listView1,"COLOR");
            }
        }

        public void menuCodeOrDay(string option)
        {
            optionMenu = option;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexColumn = listView1.FocusedItem.Index;
            if (optionMenu == "HEADS")
            {
                try
                {
                    textBox1.Text = listView1.Items[indexColumn].Text;
                    orderSaveOfSaveFile = "SAVECHANGE";
                    buttonUpdateTemplate.Text = "Editar columna";
                    paint(listView1, "WHITE");
                    paint(listView1, "COLOR");
                }
                catch (Exception) { }
            }
            else if (optionMenu == "CODE" || optionMenu == "DAYS")
            {
                try
                {
                    textBox1.Text = listView1.Items[indexColumn].Text + ">" + listView1.Items[indexColumn].SubItems[1].Text;
                    orderSaveOfSaveFile = "SAVECHANGE";
                    buttonUpdateTemplate.Text = "Editar columna";
                    paint(listView1, "WHITE");
                    paint(listView1, "COLOR");
                }
                catch (Exception) { }
            }
        }

        private void buttonUpdateTemplate_Click(object sender, EventArgs e)
        {
            if (orderSaveOfSaveFile == "SAVECHANGE")
            {
                if (optionMenu == "HEADS")
                {
                    listView1.Items[indexColumn].Text = textBox1.Text;
                }
                else if (optionMenu == "CODE" || optionMenu == "DAYS")
                {
                    if (!textBox1.Text.Contains(">"))
                    {
                        MessageBox.Show("NO SE EDITARA, NO CONTIENE LA ESTRUCTURA NECESARIA, EJEMPLO: DATO1>DATO2");
                    }
                    else
                    {
                        string data = textBox1.Text;
                        string[] storageData = data.Split('>');
                        listView1.Items[indexColumn].Text = storageData[0];
                        listView1.Items[indexColumn].SubItems[1].Text = storageData[1];
                    }
                }
                textBox1.Text = "";
                buttonUpdateTemplate.Text = "Guardar Plantilla";
                orderSaveOfSaveFile = "SAVEFILE";
                MessageBox.Show("EDITADO EXITOSAMENTE");
            }
            else if (orderSaveOfSaveFile == "SAVEFILE")
            {
                string path = "";
                if (optionMenu == "CODE")
                {
                    path = SpecificPathOfFolderConfigurationCodesSits + "codes.txt";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                else if (optionMenu == "DAYS")
                {
                    path = SpecificPathOfFolderConfigurationDaysOfMoths + "days.txt";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                else if (optionMenu == "HEADS")
                {
                    path = SpecificPathOfFolderConfigurationAvoidData + "avoid.txt";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                string sumString = "";
                if (optionMenu == "HEADS")
                {
                    for (int index = 0; index < listView1.Items.Count; index++)
                    {
                        sumString += listView1.Items[index].Text + "?";
                    }
                }
                else if (optionMenu == "CODE" || optionMenu == "DAYS")
                {
                    for (int index = 0; index < listView1.Items.Count; index++)
                    {
                        sumString += listView1.Items[index].Text + "?" + listView1.Items[index].SubItems[1].Text + "?";
                    }
                    
                }
                sumString = sumString.TrimEnd('?');
                generalMethodToWriteInFiles callToWrite = new generalMethodToWriteInFiles();
                callToWrite.writeInFiles(path,sumString);
                MessageBox.Show("ARCHIVO GUARDADO EXITOSAMENTE");
            }
        }

        private void buttonEraseColumn_Click(object sender, EventArgs e)
        {
            string data = "";
            if (optionMenu == "HEADS")
            {
                data = listView1.Items[indexColumn].Text;
            }
            else if (optionMenu == "CODE" || optionMenu == "DAYS")
            {
                data = listView1.Items[indexColumn].Text + ">" + listView1.Items[indexColumn].SubItems[1].Text;
            }
            DialogResult eliminate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR LA FORMULA: " + data + " ?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (eliminate)
            {
                case DialogResult.Yes:
                    listView1.Items.RemoveAt(indexColumn);
                    textBox1.Text = "";
                    MessageBox.Show("ELIMINAD0 EXITOSAMENTE");
                    break;
                case DialogResult.No:
                    break;
            }
        }
        
        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                MessageBox.Show("NO SE AÑADIRA, ESTA EN BLANCO");
            }else if (!textBox1.Text.Contains(">") && optionMenu == "CODE" || !textBox1.Text.Contains(">") && optionMenu == "DAYS")
            {
                MessageBox.Show("NO SE AÑADIRA, NO CONTIENE LA ESTRUCTURA NECESARIA, EJEMPLO: DATO1>DATO2");
            }
            else
            {
                string data = textBox1.Text.ToUpper();
                if (optionMenu == "HEADS")
                {
                    listView1.Items.Add(data);
                }
                else if (optionMenu == "CODE" || optionMenu == "DAYS")
                {
                    string[] storageData = data.Split('>');
                    ListViewItem item = new ListViewItem(storageData[0]);
                    item.SubItems.Add(storageData[1]);
                    listView1.Items.Add(item);
                }
                paint(listView1, "WHITE");
                paint(listView1, "COLOR");
                textBox1.Text = "";
            }
        }

        private void paint(ListView listToPaint, string orderColor)
        {
            int index = 0;
            foreach (ListViewItem item in listToPaint.Items)
            {
                if ((index % 2) == 0)
                {
                    if (orderColor == "WHITE")
                    {
                        item.BackColor = Color.White;
                    }
                    else if (orderColor == "COLOR")
                    {
                        item.BackColor = Color.LightBlue;
                    }
                }
                ++index;
            }
        }


        private void buttonReturnScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMoveBackColum_Click(object sender, EventArgs e)
        {
            if (indexColumn > 0)
            {
                textBox1.Text = "";
                buttonUpdateTemplate.Text = "Guardar Plantilla";
                orderSaveOfSaveFile = "SAVEFILE";
                int actualIndex = indexColumn;
                int afterIndex = indexColumn - 1;

                if (optionMenu == "HEADS")
                {
                    string actualDataPart1 = listView1.Items[actualIndex].Text;
                    string afterDataPart1 = listView1.Items[afterIndex].Text;
                    listView1.Items[actualIndex].Text = afterDataPart1;
                    listView1.Items[afterIndex].Text = actualDataPart1;
                }
                else if (optionMenu == "CODE" || optionMenu == "DAYS")
                {
                    string actualDataPart1 = listView1.Items[actualIndex].Text;
                    string actualDataPart2 = listView1.Items[actualIndex].SubItems[1].Text;
                    string afterDataPart1 = listView1.Items[afterIndex].Text;
                    string afterDataPart2 = listView1.Items[afterIndex].SubItems[1].Text;
                    listView1.Items[actualIndex].Text = afterDataPart1;
                    listView1.Items[actualIndex].SubItems[1].Text = afterDataPart2;
                    listView1.Items[afterIndex].Text = actualDataPart1;
                    listView1.Items[afterIndex].SubItems[1].Text = actualDataPart2;
                }
                --indexColumn;
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL INICIO");
            }
        }

        private void buttonMoveNextColumn_Click(object sender, EventArgs e)
        {
            if (indexColumn < listView1.Items.Count - 1)
            {
                textBox1.Text = "";
                buttonUpdateTemplate.Text = "Guardar Plantilla";
                orderSaveOfSaveFile = "SAVEFILE";
                int actualIndex = indexColumn;
                int afterIndex = indexColumn + 1;
                if (optionMenu == "HEADS")
                {
                    string actualDataPart1 = listView1.Items[actualIndex].Text;
                    string afterDataPart1 = listView1.Items[afterIndex].Text;
                    listView1.Items[actualIndex].Text = afterDataPart1;
                    listView1.Items[afterIndex].Text = actualDataPart1;
                }
                else if (optionMenu == "CODE" || optionMenu == "DAYS")
                {
                    string actualDataPart1 = listView1.Items[actualIndex].Text;
                    string actualDataPart2 = listView1.Items[actualIndex].SubItems[1].Text;
                    string afterDataPart1 = listView1.Items[afterIndex].Text;
                    string afterDataPart2 = listView1.Items[afterIndex].SubItems[1].Text;
                    listView1.Items[actualIndex].Text = afterDataPart1;
                    listView1.Items[actualIndex].SubItems[1].Text = afterDataPart2;
                    listView1.Items[afterIndex].Text = actualDataPart1;
                    listView1.Items[afterIndex].SubItems[1].Text = actualDataPart2;
                }
                ++indexColumn;
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
            }
        }
    }
}
